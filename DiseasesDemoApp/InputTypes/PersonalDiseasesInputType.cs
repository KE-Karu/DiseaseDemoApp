using GraphQL.Types;

namespace DiseasesDemoApp.InputTypes
{
    public class PersonalDiseasesInputType : InputObjectGraphType
    {
        public PersonalDiseasesInputType()
        {
            Name = "AddPersonalDiseaseInput";
            Field<NonNullGraphType<IntGraphType>>("diseaseId");
            Field<NonNullGraphType<IntGraphType>>("personId");
            Field<DateGraphType>("dateOfGetting");
        }
    }
}
