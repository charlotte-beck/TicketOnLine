using Api_ASPCore.Models;
using Global;
using Interfaces;
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
            get
            {
                return _instance ?? (_instance = new AuthService());
            }
        }

        private SqlConnection _connection;

        public AuthService()
        {
            _connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["DatabaseTicketOnLine"].ConnectionString);
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
                    user.Passwd = dr["Passwd"].ToString();
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
    }
}