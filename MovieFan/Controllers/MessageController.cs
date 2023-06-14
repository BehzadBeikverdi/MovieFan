using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieFan.Data;
using MovieFan.IRepository;
using MovieFan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieFan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MessageController> _logger;
        private readonly IMapper _mapper;

        public MessageController(IUnitOfWork unitOfWork,
            ILogger<MessageController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddMessage([FromBody] MessageDTO messageDTO)
        {
            _logger.LogInformation($"Add Message attempts for {messageDTO.EmailAddress}");
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var message = _mapper.Map<Message>(messageDTO);
                await _unitOfWork.Messages.SendMessage(message);
                var saved = await _unitOfWork.Save();

                var response = new GenericResponseDTO
                {
                    IsSuccessful = saved > 0,
                    StatusCode = saved > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                    Result = saved > 0 ? "Messagae sent Successfully." : "Messagae sent Failed!"
                };


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Something went wrong in the {nameof(AddMessage)}");
                var response = new GenericResponseDTO
                {
                    IsSuccessful = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Result = "Messagae sent Failed!"
                };


                return Ok(response);
            }
        }
    }
}
