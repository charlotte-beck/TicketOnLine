﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Forms;
using Global;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api_ASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthRepository<RegisterForm, LoginForm, User> _authRepository;

        public AuthController()
        {
            _authRepository = new AuthRepository();
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
    }
}