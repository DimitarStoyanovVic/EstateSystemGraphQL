using System.Linq;

using ES.DAL;
using ES.DAL.Models;
using ES.GraphQL.Types;

using GraphQL;
using GraphQL.Types;

namespace ES.GraphQL.Queries
{
    public static class BuildingQuery
    {
        public static void GetBuildings(Query query, ESDbContext esDbContext)
        {
            // query.Connection<BuildingType>()
            //      .Name("buildingsPaged")
            //      .PageSize(10)
            //      .Bidirectional();
            // .Resolve(context =>
            // {
            //     return context.GetPaged(esDbContext.Buildings);
            // });

            query.Field<ListGraphType<BuildingType>>("buildings", resolve: _ => esDbContext.Buildings);

            query.Field<BuildingType>("buildingById", arguments: new(new QueryArgument<NonNullGraphType<IntGraphType>>
                                      {
                                          Name = "Id"
                                      }),
                                      resolve: context =>
                                      {
                                          int id = context.GetArgument<int>("Id");
                                          Building building = esDbContext.Buildings.FirstOrDefault(x => x.Id == id);
                                          return building;
                                      });

            query.Field<BuildingType>("buildingByName", arguments: new(new QueryArgument<NonNullGraphType<StringGraphType>>
                                      {
                                          Name = "Name"
                                      }),
                                      resolve: context =>
                                      {
                                          string name = context.GetArgument<string>("Name");
                                          Building building = esDbContext.Buildings.FirstOrDefault(x => x.Name == name);
                                          return building;
                                      });
        }
    }
}