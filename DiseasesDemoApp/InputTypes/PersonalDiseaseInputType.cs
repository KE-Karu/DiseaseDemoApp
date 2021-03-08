using GraphQL.Types;

namespace DiseasesDemoApp.InputTypes
{
    public class PersonalDiseaseInputType : InputObjectGraphType
    {
        public PersonalDiseaseInputType()
        {
            Name = "AddPersonalDiseaseInput";
            Field<NonNullGraphType<IntGraphType>>("diseaseId");
            Field<NonNullGraphType<IntGraphType>>("personId");
            Field<DateGraphType>("dateOfGetting");
        }
    }
}
