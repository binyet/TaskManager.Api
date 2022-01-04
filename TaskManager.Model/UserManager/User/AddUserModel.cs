using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.Model.UserManager.User
{
    [AutoMap(typeof(TMUser), ReverseMap =true)]
    public class AddUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserAccount { get; set; }

    }
}
