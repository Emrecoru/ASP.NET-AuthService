﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAuthService.Core.Dtos
{
    public class CreateUserDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
