using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D = Repositories.Data.Forms;

namespace PresentationWeb_ASPCore.Models.Mappers
{
    public static class MappersForm
    {
        public static RegisterForm ToASP(this D.RegisterForm rf)
        {
            return new RegisterForm
            {
                LastName = rf.LastName,
                FirstName = rf.FirstName,
                Email = rf.Email,
                Passwd = rf.Passwd
            };
        }

        public static LoginForm ToASP(this D.LoginForm lf)
        {
            return new LoginForm
            {
                Email = lf.Email,
                Passwd = lf.Passwd
            };
        }
    }
}
