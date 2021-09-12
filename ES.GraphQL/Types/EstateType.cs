using ES.DAL.Models;

using GraphQL.Types;

namespace ES.GraphQL.Types
{
    public class EstateType : ObjectGraphType<Estate>
    {
        public EstateType()
        {
            this.Field(x => x.Id);
            this.Field(x => x.SquareMeters);
        }
    }
}