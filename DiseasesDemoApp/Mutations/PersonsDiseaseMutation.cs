using DiseasesDemoApp.InputTypes;
using DiseasesDemoApp.Models;
using DiseasesDemoApp.Repositories;
using DiseasesDemoApp.Types;
using GraphQL;
using GraphQL.Types;

namespace DiseasesDemoApp.Mutations
{
    //A way to change the data (Edit/Delete/Add)
    public class PersonsDiseaseMutation : ObjectGraphType<object>
    {
        public PersonsDiseaseMutation(IPersonRepository personRepository, IDiseaseRepository diseaseRepository, IPersonalDiseasesRepository pdRepository)
        {
            Name = "PersonsDiseaseMutation";

            #region Person
            FieldAsync<PersonsType>(
                "createPerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonsInputType>> { Name = "person" }
                    ),
                resolve: async context =>
                {
                    var personInput = context.GetArgument<Person>("person");
                    await personRepository.Add(personInput);
                    return $"Person has been created succesfully.";
                }
            );

            FieldAsync<PersonsType>(
                "updatePerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonsInputType>> { Name = "person" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personId" }
                    ),
                resolve: async context =>
                {
                    var personInput = context.GetArgument<Person>("person");
                    var personId = context.GetArgument<int>("personId");

                    var personInfoRetrived = await personRepository.GetById(personId);
                    if (personInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Person info."));
                        return null;
                    }
                    personInfoRetrived.Name = personInput.Name;
                    personInfoRetrived.DateOfBirth = personInput.DateOfBirth;
                    personInfoRetrived.Address = personInput.Address;
                    personInfoRetrived.Gender = personInput.Gender;
                    await personRepository.Update(personInfoRetrived);
                    return $"Person ID {personId} with Name {personInfoRetrived.Name} has been updated succesfully.";
                }
            );

            FieldAsync<StringGraphType>(
                "deletePerson",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personId" }),
                resolve: async context =>
                {
                    var personId = context.GetArgument<int>("personId");

                    var personInfoRetrived = await personRepository.GetById(personId);
                    if (personInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Person info."));
                        return null;
                    }
                    await personRepository.Delete(personId);
                    return $"Person ID {personId} with Name {personInfoRetrived.Name} has been deleted succesfully.";
                }
            );
            #endregion


            #region Disease
            FieldAsync<DiseasesType>(
                "createDisease",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DiseasesInputType>> { Name = "disease" }
                    ),
                resolve: async context =>
                {
                    var diseaseInput = context.GetArgument<Disease>("disease");
                    await diseaseRepository.Add(diseaseInput);
                    return $"Disease has been created succesfully.";
                }
            );

            FieldAsync<DiseasesType>(
                "updateDisease",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DiseasesInputType>> { Name = "disease" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "diseaseId" }
                    ),
                resolve: async context =>
                {
                    var diseaseInput = context.GetArgument<Disease>("disease");
                    var diseaseId = context.GetArgument<int>("diseaseId");

                    var diseaseInfoRetrived = await diseaseRepository.GetById(diseaseId);
                    if (diseaseInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Disease info."));
                        return null;
                    }
                    diseaseInfoRetrived.DiseaseName = diseaseInput.DiseaseName;
                    diseaseInfoRetrived.Description = diseaseInput.Description;

                    await diseaseRepository.Update(diseaseInfoRetrived);
                    return $"Disease ID {diseaseId} has been updated succesfully.";
                }
            );

            FieldAsync<StringGraphType>(
                "deleteDisease",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "diseaseId" }),
                resolve: async context =>
                {
                    var diseaseId = context.GetArgument<int>("diseaseId");

                    var diseaseInfoRetrived = await diseaseRepository.GetById(diseaseId);
                    if (diseaseInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Disease info."));
                        return null;
                    }
                    await diseaseRepository.Delete(diseaseId);
                    return $"Disease ID {diseaseId} with Name {diseaseInfoRetrived.DiseaseName} has been deleted succesfully.";
                }
            );
            #endregion

            #region Personal Diseases
            FieldAsync<PersonalDiseasesType>(
                "addPersonalDisease",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PersonalDiseasesInputType>> { Name = "personalDisease" }),
                resolve: async context =>
                {
                    var personalDisease = context.GetArgument<PersonalDisease>("personalDisease");
                    await pdRepository.Add(personalDisease);
                    return $"Personal disease has been created succesfully.";
                }
            );

            FieldAsync<PersonalDiseasesType>(
                "updatePersonalDisease",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DiseasesInputType>> { Name = "personalDisease" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personalDiseaseId" }
                    ),
                resolve: async context =>
                {
                    var pdInput = context.GetArgument<PersonalDisease>("personalDisease");
                    var pdId = context.GetArgument<int>("personalDiseaseId");

                    var pdInfoRetrived = await pdRepository.GetById(pdId);
                    if (pdInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Personal Disease info."));
                        return null;
                    }
                    pdInfoRetrived.DiseaseId = pdInput.DiseaseId;
                    pdInfoRetrived.PersonId = pdInput.PersonId;
                    pdInfoRetrived.DateOfGetting = pdInput.DateOfGetting;

                    await pdRepository.Update(pdInfoRetrived);
                    return $"Personal Disease ID {pdId} has been updated succesfully.";
                }
            );

            FieldAsync<StringGraphType>(
                "deletePersonalDisease",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personalDisease" }),
                resolve: async context =>
                {
                    var pdId = context.GetArgument<int>("personalDisease");

                    var pdInfoRetrived = await pdRepository.GetById(pdId);
                    if (pdInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Personal Disease info."));
                        return null;
                    }
                    await pdRepository.Delete(pdId);
                    return $"Personal Disease ID {pdId} has been deleted succesfully.";
                }
            );
            #endregion
        }
    }
}