using MyFamilyTree.Domain.Entities.Enums;

namespace MyFamilyTree.ApplicationServices.ModelsDto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? SurnameAtBirth { get; set; }
        public string? Description { get; set; }
        public EnumGender? PersonGender { get; set; }
    }

}
