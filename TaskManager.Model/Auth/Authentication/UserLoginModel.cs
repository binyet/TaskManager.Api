using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Model.Auth.Authentication
{
    public class UserLoginModel
    {
        public string Details { get; set; }
        public int LoginResult { get; set; }
        public string Token { get; set; }
    }
}
