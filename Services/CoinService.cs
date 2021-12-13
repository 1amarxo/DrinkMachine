using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Services
{
    public class CoinService : ICoinService
    {
        private readonly CoinDbContext context;
        public CoinService(CoinDbContext context)
        {
            this.context = context;
        }
        public async Task AddCoinAsync(Coins coins)
        {
            context.Coins.Add(coins);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCoinAsync(int Id)
        {
            var coins = context.Coins.Where(x => x.Id == Id).FirstOrDefault();
            context.Coins.Remove(coins);
            await context.SaveChangesAsync();
        }

        public async Task EditCoinAsync(Coins coins)
        {
            context.Coins.Update(coins);
            await context.SaveChangesAsync();
        }

        public async Task<Coins> FindCoinByIdAsync(int Id)
        {
            return context.Coins.Where(x => x.Id == Id).FirstOrDefault();
        }

        public async Task<CoinResult> GetCoinsAsync(int page = 1)
        {
            var news =  context.Coins.ToList();
            double totalPages = Math.Ceiling(news.Count() / 5.0);
            return  new CoinResult { Coins = news, TotalPages = totalPages };
        }
    }
}
