using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api_ASPCore.Helpers;
using Api_ASPCore.Models;
using Api_ASPCore.Models.Mappers;
using Api_ASPCore.Repository.Services;
using Global;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Api_ASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private AuthService _authRepository;
        private IAuthRepository<RegisterForm, LoginForm, User> _authRepository;

        public AuthController(AuthService authService)
        {
            //_authRepository = new AuthService(IAuthRepository<RegisterForm, LoginForm, User>, IOptions<AppSettings>);
            _authRepository = authService;
        }

        [Route("api/auth/register/")]
        [HttpPost]
        public HttpResponseMessage Register(RegisterForm registerForm)
        {
            if (!(registerForm is null) && ModelState.IsValid)
            {
                try
                {
                    _authRepository.Register(registerForm);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }

            HttpContent content = (!(registerForm is null))
                ? new StringContent(JsonConvert.SerializeObject(ModelState))
                : new StringContent("There is no Data!!");

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = content };
        }

        [Route("api/auth/login/")]
        [HttpPost]
        public HttpResponseMessage Login(LoginForm loginForm)
        {
            if (!(loginForm is null) && ModelState.IsValid)
            {
                try
                {
                    User user = _authRepository.Login(loginForm);

                    if (user is null)
                    {
                        return new HttpResponseMessage(HttpStatusCode.NoContent);
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(user)) };
                    }
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }

            HttpContent content = (!(loginForm is null))
                ? new StringContent(JsonConvert.SerializeObject(ModelState))
                : new StringContent("There is no Data!!");

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = content };
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Auth([FromBody]LoginForm model)
        {
            User user = _authRepository.Authenticate(model.Email, model.Passwd);

            if (user == null)
            {
                return BadRequest(new { message = "Nom d'utilisateur ou mot de passe incorrect" });
            }
            return Ok(user);
        }

        [HttpGet("auth/user")]
        public IActionResult GetAll()
        {
            return Ok(UserService.Instance.GetAllUser());
        }
    }
}
