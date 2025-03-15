using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuRepository menuRepository)
        {
            Field<ListGraphType<MenuType>>("Menus")
                .ResolveAsync(async context =>
                {
                    return await menuRepository.GetAllMenuAsync();
                });

            Field<MenuType>("Menu")
                .Arguments(new QueryArgument<IntGraphType> { Name = "menuId" })
                .ResolveAsync(async context =>
                {
                    return await menuRepository.GetMenuByIdAsync(context.GetArgument<int>("menuId"));
                });
        }
    }
}
