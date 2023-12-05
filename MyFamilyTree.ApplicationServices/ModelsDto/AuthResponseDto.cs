using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyTree.ApplicationServices.ModelsDto
{
    public class AuthResponseDto : UserDto
    {
        public string JwtToken { get; set; }
    }
}
