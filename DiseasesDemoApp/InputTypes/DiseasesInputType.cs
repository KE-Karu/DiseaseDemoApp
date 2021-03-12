using GraphQL.Types;

namespace DiseasesDemoApp.InputTypes
{
    public class DiseasesInputType : InputObjectGraphType
    {
        public DiseasesInputType()
        {
            Name = "AddDiseaseInput";
            Field<StringGraphType>("diseaseName");
            Field<StringGraphType>("description");
        }
    }
}
