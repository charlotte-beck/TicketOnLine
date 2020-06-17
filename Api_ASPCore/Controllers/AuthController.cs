using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api_ASPCore.Helpers;
using Api_ASPCore.Repository.Services;
using Global;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
//using Repositories.Data;
using Repositories.Data.Forms;

namespace Api_ASPCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository<RegisterForm, LoginForm, User> _authRepository;

        public AuthController(IAuthRepository<RegisterForm, LoginForm, User> authService)
        {
            _authRepository = authService;
        }

        //[Route("api/auth/register/")]
        //[HttpPost]
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterForm registerForm)
        {
            if (!(registerForm is null))
            {

                _authRepository.Register(registerForm);
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        //[Route("api/auth/login/")]
        //[HttpPost]
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginForm loginForm)
        {
            if (!(loginForm is null))
            {
                User user = _authRepository.Login(loginForm);
                user = _authRepository.Authenticate(user);
                if (user.UserId == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(user);
                }
        
                //try
                //{
                //    User user = _authRepository.Login(loginForm);
                //    user = _authRepository.Authenticate(user);

                //    if (user is null)
                //    {
                //        return NoContent();
                //    }
                //    else
                //    {
                //        return Ok(user);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    return BadRequest();
                //}
            }
            else
            {
                return BadRequest();
            }

            //return (!(loginForm is null)) ? BadRequest(ModelState) : BadRequest("No Data!");
        }
    }
}
