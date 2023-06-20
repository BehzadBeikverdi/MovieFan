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
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Register User attempts for {userDTO.EmailAddress}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _unitOfWork.Users.RegisterUser(user);
                var saved = await _unitOfWork.Save();

                var response = new GenericResponseDTO
                {
                    IsSuccessful = saved > 0,
                    StatusCode = saved > 0 ? HttpStatusCode.OK : HttpStatusCode.NotAcceptable,
                    Result = saved > 0 ? $"Register user '{userDTO.EmailAddress}' successfully" : $"User '{userDTO.EmailAddress}' already exist!"
                };


                return Ok(response);
               
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Something went wrong in the {nameof(RegisterUser)}");

                var response = new GenericResponseDTO
                {
                    IsSuccessful = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Result = ex.Message
                };

                return BadRequest(response);
            }
        }

        [HttpPost]
        [ResponseType(typeof(User))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginUser([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Login User attempts for {userDTO.EmailAddress}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<User>(userDTO);
                bool result = await _unitOfWork.Users.LoginUser(user);

                var response = new GenericResponseDTO
                {
                    IsSuccessful = result,
                    StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.NotAcceptable,
                    Result = result ?  $"Login user '{userDTO.EmailAddress}' successfully" : $"Entered infoes not correct!"
                };


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Something went wrong in the {nameof(LoginUser)}");

                var response = new GenericResponseDTO
                {
                    IsSuccessful = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Result = ex.Message
                };

                return BadRequest(response);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Movie>> DeleteUser(string EmailAddress)
        {
            try
            {
                await _unitOfWork.Users.DeleteUser(EmailAddress);
                var saved = await _unitOfWork.Save();

                var response = new GenericResponseDTO
                {
                    IsSuccessful = saved > 0,
                    StatusCode = saved > 0 ? HttpStatusCode.OK : HttpStatusCode.NotAcceptable,
                    Result = saved > 0 ? $"Delete User {EmailAddress} Successfully." : $"Delete {EmailAddress} User Movie Failed!"
                };


                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new GenericResponseDTO
                {
                    IsSuccessful = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Result = ex.Message
                };


                return BadRequest(response);
            }
        }
    } 
}
