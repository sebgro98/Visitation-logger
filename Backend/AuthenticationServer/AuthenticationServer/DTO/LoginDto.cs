﻿namespace AuthenticationServer.DTO
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}