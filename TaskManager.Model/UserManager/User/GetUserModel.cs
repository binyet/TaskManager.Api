using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.Model.UserManager.User
{
    [AutoMap(typeof(TMUser), ReverseMap = true)]
    public class GetUserModel
    {
        [Required]
        public int ID { get; set; }
        [Description]
        [Required]
        public string UserAccount { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
