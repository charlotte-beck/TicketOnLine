using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb_ASPCore.Utils
{
    public class SessionManager : ISessionManager
    {
        private ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public User user
        {
            get
            {
                string json = _session.GetString(nameof(User));
                return (json is null) ? null : JsonConvert.DeserializeObject<User>(json);
            }
            set
            {
                _session.SetString(nameof(User), JsonConvert.SerializeObject(value));
            }
        }

        public void Logout()
        {
            _session.Clear();
        }
    }
}
