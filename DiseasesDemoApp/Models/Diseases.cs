using System.Collections.Generic;

namespace DiseasesDemoApp.Models
{
    public class Diseases : UniqueEntityData
    {
        public string DiseaseName { get; set; }
        public string Description { get; set; }
        //medicationId
        public ICollection<PersonalDiseases> Persons { get; set; }
    }
}
