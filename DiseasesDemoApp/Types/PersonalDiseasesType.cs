﻿using DiseasesDemoApp.Models;
using DiseasesDemoApp.Repositories;
using GraphQL.Types;

namespace DiseasesDemoApp.Types
{
    public class PersonalDiseasesType : ObjectGraphType<PersonalDiseases>
    {
        public PersonalDiseasesType(IDiseaseRepository diseaseRepository, IPersonRepository personRepository, IPersonalDiseasesRepository pdRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Personal Disease Id");
            Field(x => x.DiseaseId, type: typeof(IdGraphType)).Description("Disease Id");
            FieldAsync<DiseasesType, Diseases>("disease", resolve: ctx =>
            {
                return diseaseRepository.GetById(ctx.Source.DiseaseId);
            });
                        Field(x => x.PersonId, type: typeof(IdGraphType)).Description("Person Id");
            FieldAsync<PersonsType, Persons>("person", resolve: ctx =>
            {
                return personRepository.GetById(ctx.Source.PersonId);
            });
            Field(x => x.DateOfGetting).Description("Date of Getting It");

        }
    }
}
