using MyFamilyTree.Domain.Entities.Enums;

namespace MyFamilyTree.ApplicationServices.ModelsDto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Surname { get; set; }

        public string? Description { get; set; }
        public EnumGender? PersonGender { get; set; }
    }

}
