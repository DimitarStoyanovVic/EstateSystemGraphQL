using ES.DAL;
using ES.GraphQL.Mutations;

using GraphQL.Types;

namespace ES.GraphQL
{
    public class Mutation : ObjectGraphType<object>
    {
        public Mutation(ESDbContext esDbContext)
        {
            BuildingMutation.AddBuilding(this, esDbContext);
        }
    }
}