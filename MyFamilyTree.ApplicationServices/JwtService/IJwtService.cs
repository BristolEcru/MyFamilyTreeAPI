using MyFamilyTree.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyTree.ApplicationServices.JwtService
{
    public interface IJwtService
    {
        string GenerateJWTToken(User user);
    }
}
