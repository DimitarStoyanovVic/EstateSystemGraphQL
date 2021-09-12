using GraphQL.Types;

namespace ES.GraphQL.MutationInput
{
    public class BuildingInputType : InputObjectGraphType
    {
        public BuildingInputType()
        {
            // this.Name = "BuildingInput";
            this.Field<StringGraphType>("name");
        }
    }
}