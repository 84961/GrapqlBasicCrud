using GraphQLProject.Models;
using System.Threading.Tasks;

namespace GraphQLProject.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllMenuAsync();
        Task<Menu> GetMenuByIdAsync(int id);
        Task<Menu> AddMenuAsync(Menu menu);
        Task<Menu> UpdateMenuAsync(int id, Menu menu);
        Task DeleteMenuAsync(int id);
    }
}
