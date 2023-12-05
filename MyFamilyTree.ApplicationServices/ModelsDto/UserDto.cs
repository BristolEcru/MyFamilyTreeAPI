
using MyFamilyTree.Domain.Entities.Enums;

namespace MyFamilyTree.ApplicationServices.ModelsDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public EnumRole Role { get; set; }
    }
}