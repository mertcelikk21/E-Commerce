using eTicaret.Core.DbModels.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTicaret.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
