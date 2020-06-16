using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb_ASPCore.Utils
{
    public interface ISessionManager
    {
        User user { get; set; }

        void Logout();
    }
}
