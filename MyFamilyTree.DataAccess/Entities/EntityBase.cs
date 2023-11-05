using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyFamilyTree.Domain.Entities
{

    [Index("Id", IsUnique = true)]
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
