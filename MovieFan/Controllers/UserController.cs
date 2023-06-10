using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Add User attempts for {userDTO.EmailAddress}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _unitOfWork.Users.AddUser(user);
                var saved = await _unitOfWork.Save();

                var response = new GenericResponseDTO
                {
                    IsSuccessful = saved > 0,
                    StatusCode = HttpStatusCode.OK,
                    Result = saved > 0 ? $"Add user {userDTO.EmailAddress} successfully" : $"User {userDTO.EmailAddress} already exist!"
                };


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Something went wrong in the {nameof(AddUser)}");

                var response = new GenericResponseDTO
                {
                    IsSuccessful = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Result = $"Sth went wrong!"
                };

                return NotFound(response);
            }
        }
    } 
}
