using DiseasesDemoApp.Models;
using DiseasesDemoApp.Repositories;
using GraphQL.Types;

namespace DiseasesDemoApp.Types
{
    public class PersonalDiseasesType : ObjectGraphType<PersonalDisease>
    {
        public PersonalDiseasesType(IDiseaseRepository diseaseRepository, IPersonRepository personRepository, IPersonalDiseasesRepository pdRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Personal Disease Id");
            Field(x => x.PersonId, type: typeof(IdGraphType)).Description("Person Id");
            Field(x => x.DiseaseId, type: typeof(IdGraphType)).Description("Disease Id");
            Field(x => x.DateOfGetting).Description("Date of Getting It");

            FieldAsync<DiseasesType, Disease>("disease", resolve: ctx =>
            {
                return diseaseRepository.GetById(ctx.Source.DiseaseId);
            });
                            
            FieldAsync<PersonsType, Person>("person", resolve: ctx =>
            {
                return personRepository.GetById(ctx.Source.PersonId);
            });
        }
    }
}
