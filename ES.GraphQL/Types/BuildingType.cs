using ES.DAL.Models;

using GraphQL.Types;

namespace ES.GraphQL.Types
{
    public class BuildingType : ObjectGraphType<Building>
    {
        public BuildingType()
        {
            this.Field(x => x.Id);
            this.Field(x => x.Name);
        }
    }
}