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
using Repositories.Data.Forms;

namespace Api_ASPCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private AuthService _authRepository;
        private IAuthRepository<RegisterForm, LoginForm, User> _authRepository;

        public AuthController(IAuthRepository<RegisterForm, LoginForm, User> authService)
        {
            //_authRepository = new AuthService(IAuthRepository<RegisterForm, LoginForm, User>, IOptions<AppSettings>);
            _authRepository = authService;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public string Get()
        //{
        //    return "coucou";
        //}
        //[Route("api/auth/register/")]
        //[HttpPost]
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterForm registerForm)
        {
            //return Ok();
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
        public IActionResult Login(LoginForm loginForm)
        {
            if (!(loginForm is null))
            {
                try
                {
                    User user = _authRepository.Login(loginForm);
                    user = _authRepository.Authenticate(user);

                    if (user is null)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return Ok(user);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }

            return (!(loginForm is null)) ? BadRequest(ModelState) : BadRequest("No Data!");
        }

        //[AllowAnonymous]
        //[Route("api/auth/login/")]
        //[HttpPost("auth")]
        //public IActionResult Login([FromBody]LoginForm loginForm)
        //{
        //    User user = _authRepository.Authenticate(loginForm.Email, loginForm.Passwd);

        //    if (user == null)
        //    {
        //        return BadRequest(new { message = "Nom d'utilisateur ou mot de passe incorrect" });
        //    }
        //    return Ok(user);
        //}
    }
}
