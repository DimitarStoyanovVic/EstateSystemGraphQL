using ES.DAL;
using ES.DAL.Models;
using ES.GraphQL.MutationInput;
using ES.GraphQL.Types;

using GraphQL;
using GraphQL.Types;

namespace ES.GraphQL.Mutations
{
    public static class BuildingMutation
    {
        public static void AddBuilding(Mutation mutation, ESDbContext esDbContext)
        {
            mutation.Field<BuildingType>("createBuilding", arguments: new(new QueryArgument<NonNullGraphType<BuildingInputType>>
                                         {
                                             Name = "building"
                                         }),
                                         resolve: context =>
                                         {
                                             Building building = context.GetArgument<Building>("building");
                                             esDbContext.Buildings.Add(building);
                                             esDbContext.SaveChanges();
                                             return building;
                                         });
        }
    }
}