
using MyFamilyTree.Domain.Entities.Enums;

namespace MyFamilyTree.ApplicationServices.ModelsDto
{
    public class CreateUserDto
    {

        //private EnumRole _role = EnumRole.User;

        //public EnumRole Role
        //{
        //    get { return _role; }
        //    set { _role = value; }
        //}


        public CreateUserDto()
        {
            Role = EnumRole.User;
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
    }
}