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
using System.Web.Http.Description;

namespace MovieFan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        GenericResponse responseGeneric = new GenericResponse();

        public UserController(IUnitOfWork unitOfWork,
            ILogger<UserController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ResponseType(typeof(User))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO, GenericResponse responseGeneric)
        {
            _logger.LogInformation($"Add User attempts for {userDTO.EmailAddress}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<User>(userDTO);
                responseGenericContent = GenericResponse(true, HttpStatusCode.OK, "");
                await _unitOfWork.Users.AddUser(user, responseGenericContent);
                await _unitOfWork.Save();

                return Ok("Message Added!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Something went wrong in the {nameof(AddUser)}");
                return HttpStatusCode.;
            }
        }
    } 
}
