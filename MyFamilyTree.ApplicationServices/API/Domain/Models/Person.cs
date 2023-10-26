

using MyFamilyTree.DataAccess.Entities.Enums;

namespace MyFamilyTree.ApplicationServices.API.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public string? Surname { get; set; }

        public string? Description { get; set; }
        public EnumGender? PersonGender { get; set; }
    }

}
