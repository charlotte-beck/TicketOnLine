using Api_ASPCore.Helpers;
using Global;
using Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repositories.Data.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api_ASPCore.Repository.Services
{
    public class AuthService : IAuthRepository<RegisterForm, LoginForm, User>
    {
        //private static IAuthRepository<RegisterForm, LoginForm, User> _instance;
        //public static IAuthRepository<RegisterForm, LoginForm, User> Instance
        //{
        //    get
        //    {
        //        return _instance ?? (_instance = new AuthService(IOptions<AppSettings>));
        //    }
        //}

        private SqlConnection _connection;
        private readonly AppSettings _appSettings;
        public AuthService(IOptions<AppSettings> app)
        {
            //_instance = authRepository;
            _appSettings = app.Value;
            _connection = new SqlConnection(@"Data Source=FORMA-VDI1106\TFTIC;Initial Catalog=DatabaseTicketOnLine;Integrated Security=True");
            //_connection = new SqlConnection(
            //    ConfigurationManager.ConnectionStrings["DatabaseTicketOnLine"].ConnectionString);
            _connection.Open();
        }

        public User Login(LoginForm loginForm)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_LoginUser";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("Email", loginForm.Email);
            command.Parameters.AddWithValue("Passwd", loginForm.Passwd);
            User user = new User();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    user.UserId = (int)dr["UserId"];
                    user.FirstName = dr["FirstName"].ToString();
                    user.LastName = dr["LastName"].ToString();
                    user.Email = dr["Email"].ToString();
                    //user.Passwd = dr["Passwd"].ToString();
                }
            }
            return user;
        }

        public void Register(RegisterForm registerForm)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SP_RegisterUser";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("LastName", registerForm.LastName);
            command.Parameters.AddWithValue("FirstName", registerForm.FirstName);
            command.Parameters.AddWithValue("Email", registerForm.Email);
            command.Parameters.AddWithValue("Passwd", registerForm.Passwd);
            command.ExecuteNonQuery();
        }

        public User Authenticate(User user)
        {
            //User user = UserService.Instance.GetAllUser().SingleOrDefault(x => x.Email == email && x.Passwd == passwd);

            if (user == null) return null;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
    }
}