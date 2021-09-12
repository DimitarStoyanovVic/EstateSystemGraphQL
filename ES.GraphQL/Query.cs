using ES.DAL;
using ES.GraphQL.Queries;

using GraphQL.Types;

namespace ES.GraphQL
{
    public class Query : ObjectGraphType<object>
    {
        public Query(ESDbContext esDbContext)
        {
            BuildingQuery.GetBuildings(this, esDbContext);
        }
    }
}