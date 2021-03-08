using GraphQL.Types;

namespace DiseasesDemoApp.InputTypes
{
    public class DiseaseInputType : InputObjectGraphType
    {
        public DiseaseInputType()
        {
            Name = "AddDiseaseInput";
            Field<StringGraphType>("diseaseName");
            Field<StringGraphType>("description");
        }
    }
}
