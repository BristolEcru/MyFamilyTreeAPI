
using MyFamilyTree.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyFamilyTree.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public EnumRole Role { get; set; }

    }
}
