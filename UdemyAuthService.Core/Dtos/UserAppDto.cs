﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAuthService.Core.Dtos
{
    public class UserAppDto
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string City { get; set; }
    }
}
