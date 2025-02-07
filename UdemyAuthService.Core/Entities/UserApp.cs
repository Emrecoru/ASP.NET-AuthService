
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAuthService.Core.Entities
{
    public class UserApp : IdentityUser
    {
        public string? City { get; set; }
    }
}
