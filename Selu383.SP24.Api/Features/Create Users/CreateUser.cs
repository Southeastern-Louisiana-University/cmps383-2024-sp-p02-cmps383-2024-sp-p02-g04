﻿namespace Selu383.SP24.Api.Features.Create_Users
{
    public class CreateUser
    { 
        public string UserName { get; set; }
        public string[] Roles { get; set; }
        public string Password { get; set; }
    }
}