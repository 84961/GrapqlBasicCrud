using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLProject.Services
{
    public class MenuRepository : IMenuRepository
    {
        private readonly GraphQLDbContext dbContext;

        public MenuRepository(GraphQLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Menu> AddMenuAsync(Menu menu)
        {
            await dbContext.Menus.AddAsync(menu);
            await dbContext.SaveChangesAsync();
            return menu;
        }

        public async Task DeleteMenuAsync(int id)
        {
            var menuResult = await dbContext.Menus.FindAsync(id);
            dbContext.Menus.Remove(menuResult);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Menu>> GetAllMenuAsync()
        {
            return await dbContext.Menus.ToListAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(int id)
        {
            return await dbContext.Menus.FindAsync(id);
        }

        public async Task<Menu> UpdateMenuAsync(int id, Menu menu)
        {
            var menuResult = await dbContext.Menus.FindAsync(id);
            menuResult.Name = menu.Name;
            menuResult.Description = menu.Description;
            menuResult.Price = menu.Price;
            await dbContext.SaveChangesAsync();
            return menu;
        }
    }
}
