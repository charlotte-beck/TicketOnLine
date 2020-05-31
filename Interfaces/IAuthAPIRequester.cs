using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IAuthAPIRequester<TRegisterForm, TLoginForm, TResult>
    {
        TResult Login(TLoginForm loginForm);
        void Register(TRegisterForm registerForm);
    }
}
