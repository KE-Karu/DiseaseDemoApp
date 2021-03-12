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
            var persons = new Person[]
            {
                new Person{ NatIdNr = "34501234215 " , Name = "Ants Mustikas", DateOfBirth = DateTime.Parse("03-01-1945"), Address = "Viru 10", Gender = "Male"},
                new Person{ NatIdNr = "39502114232" , Name = "Tõnu Vaarikas", DateOfBirth = DateTime.Parse("11-02-1995"), Address = "Maardu 25", Gender = "Male"},
                new Person{ NatIdNr = "49403136515" , Name = "Mari Maasikas", DateOfBirth = DateTime.Parse("13-03-1994"), Address = "Lepa 32", Gender = "Femmale"}
            };
            foreach(Person p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();


            if (context.Diseases.Any())
            {
                return;
            }
            var diseases = new Disease[]
            {
                new Disease{ DiseaseName = "Diabetes", Description = "Diabetes is a lifelong condition that causes a person's blood glucose (sugar) level to become too high."},
                new Disease{ DiseaseName = "Pollen allergie", Description = "An allergy is a reaction the body has to a particular substance."},
                new Disease{ DiseaseName = "Asthma", Description = "Asthma is a common long-term condition that can cause coughing, wheezing, chest tightness and breathlessness."}
            };
            foreach (Disease d in diseases)
            {
                context.Diseases.Add(d);
            }
            context.SaveChanges();



            if (context.DiseasesOfPerson.Any())
            {
                return;
            }
            var diseaseOfPerson = new PersonalDisease[]
            {
                new PersonalDisease{ DiseaseId = 1, PersonId = 3},
                new PersonalDisease{ DiseaseId = 2, PersonId = 2},
                new PersonalDisease{ DiseaseId = 3, PersonId = 1}
            };
            foreach (PersonalDisease pd in diseaseOfPerson)
            {
                context.DiseasesOfPerson.Add(pd);
            }
            context.SaveChanges();
        }
    }
}
