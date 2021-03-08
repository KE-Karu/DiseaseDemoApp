using System;

namespace DiseasesDemoApp.Models
{
    public class PersonalDiseases : UniqueEntityData
    {
        public int DiseaseId { get; set; }
        public Diseases Disease { get; set; }
        public int PersonId { get; set; }
        public Persons Person { get; set; }
        //medicationId, symptoms, checkup, doctor
        public DateTime DateOfGetting { get; set; }
    }
}
