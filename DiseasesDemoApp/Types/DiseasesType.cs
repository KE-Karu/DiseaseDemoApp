using DiseasesDemoApp.Models;
using DiseasesDemoApp.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace DiseasesDemoApp.Types
{
    public class DiseasesType : ObjectGraphType<Diseases>
    {
        public DiseasesType(IDiseaseRepository diseaseRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Disease Id");
            Field(x => x.Description).Description("Description of a disease");
            Field(x => x.DiseaseName).Description("Name of the Disease");

            FieldAsync<ListGraphType<PersonalDiseasesType>, IReadOnlyCollection<PersonalDiseases>>(
                "personsWithDisease", "returns list of persons with this disease",
                resolve: context =>
                {
                    return diseaseRepository.GetPersonsByDiseaseId(context.Source.Id);
                });
        }
    }
}
