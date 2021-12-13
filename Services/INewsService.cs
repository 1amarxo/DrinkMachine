using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Services
{
    public interface INewsService
    {
        Task<Drink> FindNewsByIdAsync(int Id);
        Task<DrinkResult> GetNewsAsync(int page=1);
        Task<DrinkResult> GetNewsAsync(int CategoryId, int page = 1);
        Task AddNewsAsync(Drink news); 
        Task EditNewsAsync(Drink news); 
        Task DeleteNewsAsync(int Id1);
        Task AddCategoryAsync(Category category);

        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
