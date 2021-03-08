using GraphQL.Types;
using DiseasesDemoApp.Queries;
using System;
using GraphQL.Utilities;
using DiseasesDemoApp.Mutations;

namespace DiseasesDemoApp.Schemas
{
    public class PersonsDiseaseSchema : Schema
    {
        public PersonsDiseaseSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<PersonsDiseaseQuery>();
            Mutation = provider.GetRequiredService<PersonsDiseaseMutation>();
        }
    }
}
