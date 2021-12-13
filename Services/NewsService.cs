using Microsoft.EntityFrameworkCore;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Services
{
    public class NewsService : INewsService
    {
        private readonly NewsDbContext context;

        public NewsService(NewsDbContext context)
        {
            this.context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task AddNewsAsync(Drink news)
        {
            context.News.Add(news);
            await context.SaveChangesAsync();
        }

        public async Task DeleteNewsAsync(int Id)
        {
            var news = context.News.Where(x => x.Id == Id).FirstOrDefault();
            
            if (news != null)
            {
                context.News.Remove(news);
            }
            await context.SaveChangesAsync();
        }

        public async Task EditNewsAsync(Drink news)
        {
            context.News.Update(news);
            await context.SaveChangesAsync();
        }

        public async Task<Drink> FindNewsByIdAsync(int id)
        {
            return await context.News.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<DrinkResult> GetNewsAsync(int page = 1)
        {
            int skip = 5 * (page - 1);
            int take = 5;
            var news = await context.News.ToListAsync();
            double totalPages = Math.Ceiling(news.Count() / 5.0);
            return new DrinkResult { News = news.Skip(skip).Take(take), TotalPages = totalPages };
        }

        public async Task<DrinkResult> GetNewsAsync(int CategoryId, int page = 1)
        {
            int skip = 5 * (page - 1);
            int take = 5;
            var news = await context.News.Where(x => x.CategoryId == CategoryId).ToListAsync();
            double totalPages = Math.Ceiling(news.Count() / 5.0);
            return new DrinkResult { News = news.Skip(skip).Take(take), TotalPages = totalPages };
        }


    }
}
