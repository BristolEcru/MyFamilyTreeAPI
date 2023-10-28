﻿
using MyFamilyTree.DataAccess.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyFamilyTree.DataAccess.Entities
{
   
    public class Person : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string? Surname { get; set; }

        public string? Description { get; set; }
        public EnumGender? PersonGender { get; set; }
        public short? LifespanInYears { get; set; }
        [MaxLength(250)]
        public string? PlaceOfBirth { get; set; }
        [MaxLength(250)]
        public string? PlaceOfDeath { get; set; }
        [MaxLength(250)]
        public string? PlaceOfLiving { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public int? Parent1Id { get; set; }
        public int? Parent2Id { get; set; }

       

        [InverseProperty("Children")]
        public List<Person> Parents { get; set; }

        [InverseProperty("Parents")]
        public List<Person> Children { get; set; }

        //[InverseProperty("Spouse")]
        //public List<Person> Spouses { get; set; }


        //[InverseProperty("Parents")]
        //public List<Person> Siblings { get; set; }

    }
}

