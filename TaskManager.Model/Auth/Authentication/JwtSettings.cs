using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Model.Auth.Authentication
{
    public class JwtSettings
    {
        [Required]
        public string SecretKey { get; set; }

        [Required]
        public string Issuer { get; set; }

        [Required]
        public string Audience { get; set; }

        [Required]
        public int Expires { get; set; }
    }
}
