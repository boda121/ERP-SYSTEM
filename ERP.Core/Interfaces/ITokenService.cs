using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Users user);

    }
}
