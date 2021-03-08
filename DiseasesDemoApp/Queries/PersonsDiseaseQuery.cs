using DiseasesDemoApp.Repositories;
using DiseasesDemoApp.Types;
using GraphQL;
using GraphQL.Types;

namespace DiseasesDemoApp.Queries
{
    //A Query class that can only fetch the data.
    public class PersonsDiseaseQuery : ObjectGraphType
    {
        public PersonsDiseaseQuery(IPersonRepository personRepository, IDiseaseRepository diseaseRepository, IPersonalDiseasesRepository pdRepository)
        {
            Name = "PersonsDiseaseQuery";

            Field<PersonsType>(
                "person",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }), 
                resolve: context => personRepository.GetById(context.GetArgument<int>("Id"))
                );

            Field<ListGraphType<PersonsType>>(
                "persons", "Returns list of persons",
                resolve: context => personRepository.GetAll()
                );

            Field<DiseasesType>(
                "disease",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
                resolve: context => diseaseRepository.GetById(context.GetArgument<int>("Id"))
                );

            Field<ListGraphType<DiseasesType>>(
                "diseases", "returns list of disease",
                resolve: context => diseaseRepository.GetAll()
                );

            Field<ListGraphType<PersonalDiseasesType>>(
                "personsDiseases", "returns list of all persons with diseases",
                resolve: context => pdRepository.GetAll()
                );

        }
    }
}
