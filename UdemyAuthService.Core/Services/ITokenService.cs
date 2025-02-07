using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthService.Core.Configuration;
using UdemyAuthService.Core.Dtos;
using UdemyAuthService.Core.Entities;

namespace UdemyAuthService.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}
