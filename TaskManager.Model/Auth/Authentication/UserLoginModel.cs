using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Model.Auth.Authentication
{
    public class UserLoginModel
    {
        [Required]
        public string Details { get; set; }
        [Required]
        public int LoginResult { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
