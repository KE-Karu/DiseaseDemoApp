using System;

namespace DiseasesDemoApp.Models
{
    public class PersonalDisease : UniqueEntityData
    {
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        //medicationId, symptoms, checkup, doctor
        public DateTime DateOfGetting { get; set; }
    }
}
