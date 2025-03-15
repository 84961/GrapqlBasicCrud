using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenuRepository menuRepository)
        {
            Field<MenuType>("CreateMenu")
                .Arguments(new QueryArgument<MenuInputType> { Name = "menu" })
                .ResolveAsync(async context =>
                {
                    return await menuRepository.AddMenuAsync(context.GetArgument<Menu>("menu"));
                });

            Field<MenuType>("UpdateMenu")
                .Arguments(new QueryArgument<IntGraphType> { Name = "menuId" },
                           new QueryArgument<MenuInputType> { Name = "menu" })
                .ResolveAsync(async context =>
                {
                    var menu = context.GetArgument<Menu>("menu");
                    var menuId = context.GetArgument<int>("menuId");
                    return await menuRepository.UpdateMenuAsync(menuId, menu);
                });

            Field<StringGraphType>("DeleteMenu")
                .Arguments(new QueryArgument<IntGraphType> { Name = "menuId" })
                .ResolveAsync(async context =>
                {
                    var menuId = context.GetArgument<int>("menuId");
                    await menuRepository.DeleteMenuAsync(menuId);
                    return $"The menu with Id {menuId} has been deleted";
                });
        }
    }
}
