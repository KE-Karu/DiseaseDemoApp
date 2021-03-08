using DiseasesDemoApp.Models;
using DiseasesDemoApp.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace DiseasesDemoApp.Types
{
    public class PersonsType : ObjectGraphType<Persons>
    {

        public PersonsType(IPersonRepository personRepository)
        {
            //Field(x => x.PersonId).Description("Persons Id");
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Persons Id");
            Field(x => x.Name).Description("Persons Name");
            Field(x => x.DateOfBirth).Description("Persons Date of Birth");
            Field(x => x.Address).Description("Persons Current Address");
            Field(x => x.Gender).Description("Gender of the Person");

            FieldAsync<ListGraphType<PersonalDiseasesType>, IReadOnlyCollection<PersonalDiseases>>(
                "personalDiseases", "returns list of personal diseases",
                //arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "personId" }),
                resolve: context =>
                {
                    return personRepository.GetDiseasesByPersonId(context.Source.Id);
                });
        }
    }
}
