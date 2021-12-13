using Microsoft.EntityFrameworkCore;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Services
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext( DbContextOptions<NewsDbContext> options) : base(options)
        {

        }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Drink> News { get; set; }
    }
}
