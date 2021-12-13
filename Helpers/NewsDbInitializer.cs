using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NewsWeb.Models;
using NewsWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Helpers
{
    public static class NewsDbInitializer
    {
        public static void Init(IApplicationBuilder app)
        {
           using var services= app.ApplicationServices.CreateScope();
           var context = services.ServiceProvider.GetRequiredService<NewsDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { Name = "Sparkling" });
                context.Categories.Add(new Category { Name = "Soda" });
                context.Categories.Add(new Category { Name = "Milk" });
                context.Categories.Add(new Category { Name = "Soft drinks" });
                context.Categories.Add(new Category { Name = "Wine" });
                context.Categories.Add(new Category { Name = "Beer" });
                
            }
           
            context.SaveChanges();
        }
    }
}
