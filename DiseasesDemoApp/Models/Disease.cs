using System.Collections.Generic;

namespace DiseasesDemoApp.Models
{
    public class Disease : UniqueEntityData
    {
        public string DiseaseName { get; set; }
        public string Description { get; set; }
        //medicationId
        public ICollection<PersonalDisease> Persons { get; set; }
    }
}
