using DiseasesDemoApp.Models;
using System;
using System.Linq;

namespace DiseasesDemoApp.AppDbContext
{
    public static class DbInitializer
    {
        public static void Initialize(DiseasesDbContext context)
        {
            if (context.Persons.Any())
            {
                return;
            }
            var persons = new Persons[]
            {
                new Persons{ Name = "Ants Mustikas", DateOfBirth = DateTime.Parse("01-01-1997"), Address = "Viru 10", Gender = "Male"},
                new Persons{ Name = "Tõnu Vaarikas", DateOfBirth = DateTime.Parse("02-02-1995"), Address = "Maardu 25", Gender = "Male"},
                new Persons{ Name = "Mari Maasikas", DateOfBirth = DateTime.Parse("03-03-1993"), Address = "Lepa 32", Gender = "Femmale"}
            };
            foreach(Persons p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();


            if (context.Diseases.Any())
            {
                return;
            }
            var diseases = new Diseases[]
            {
                new Diseases{ DiseaseName = "Diabetes", Description = "Diabetes is a lifelong condition that causes a person's blood glucose (sugar) level to become too high."},
                new Diseases{ DiseaseName = "Pollen allergie", Description = "An allergy is a reaction the body has to a particular substance."},
                new Diseases{ DiseaseName = "Asthma", Description = "Asthma is a common long-term condition that can cause coughing, wheezing, chest tightness and breathlessness."}
            };
            foreach (Diseases d in diseases)
            {
                context.Diseases.Add(d);
            }
            context.SaveChanges();



            if (context.DiseasesOfPerson.Any())
            {
                return;
            }
            var diseaseOfPerson = new PersonalDiseases[]
            {
                new PersonalDiseases{ DiseaseId = 1, PersonId = 3},
                new PersonalDiseases{ DiseaseId = 2, PersonId = 2},
                new PersonalDiseases{ DiseaseId = 3, PersonId = 1}
            };
            foreach (PersonalDiseases pd in diseaseOfPerson)
            {
                context.DiseasesOfPerson.Add(pd);
            }
            context.SaveChanges();
        }
    }
}
