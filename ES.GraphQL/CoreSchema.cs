using ES.DAL;

using GraphQL.Types;

namespace ES.GraphQL
{
    public class CoreSchema : Schema
    {
        public CoreSchema(ESDbContext esDbContext)
        {
            this.Query = new Query(esDbContext);
            this.Mutation = new Mutation(esDbContext);
        }
    }
}