using GraphQL.Types;

namespace DiseasesDemoApp.InputTypes
{
    public class PersonsInputType : InputObjectGraphType
    {
        public PersonsInputType()
        {
            Name = "AddPersonInput";
            Field<NonNullGraphType<StringGraphType>>("natIdNr");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<DateGraphType>("dateOfBirth");
            Field<StringGraphType>("address");
            Field<StringGraphType>("gender");
        }
    }
}
