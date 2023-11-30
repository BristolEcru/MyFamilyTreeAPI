

using MyFamilyTree.Domain.Entities.Enums;

namespace MyFamilyTree.ApplicationServices.ModelsDto
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
    }
}
