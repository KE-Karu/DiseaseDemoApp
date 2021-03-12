using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiseasesDemoApp.Models
{
    public class Person : UniqueEntityData
    {
        [Required]
        public string NatIdNr { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public ICollection<PersonalDisease> Diseases { get; set; }
    }
}
