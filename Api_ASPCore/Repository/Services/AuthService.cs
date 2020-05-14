using Api_ASPCore.Models.Data;
using Api_ASPCore.Models.Mappers;
using Forms;
using Interfaces;
using Repositories.GlobalRepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ASPCore.Repository.Services
{
    public class AuthService : IAuthRepository<RegisterForm, LoginForm, User>
    {
        private static IAuthRepository<RegisterForm, LoginForm, User> _instance;
        public static IAuthRepository<RegisterForm, LoginForm, User> Instance
        {
            get { return _instance ?? (_instance = new AuthService()); }
        }
        public User Login(LoginForm loginForm)
        {
            return AuthRepository_Global.Instance.Login(loginForm).ToLocal();
        }

        public void Register(RegisterForm registerForm)
        {
            AuthRepository_Global.Instance.Register(registerForm);
        }
    }
}
