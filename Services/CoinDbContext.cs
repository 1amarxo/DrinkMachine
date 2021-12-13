using Microsoft.EntityFrameworkCore;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Services
{
    public class CoinDbContext : DbContext
    {
        public CoinDbContext(DbContextOptions<CoinDbContext> options) : base(options)
        {
        }

        public DbSet<Coins> Coins { get; set; }
    }
}
