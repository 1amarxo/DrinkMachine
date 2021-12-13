using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Services
{
    public interface ICoinService
    {
        Task<Coins> FindCoinByIdAsync(int Id);
        Task<CoinResult> GetCoinsAsync(int page=1);
        Task AddCoinAsync(Coins coins);
        Task EditCoinAsync(Coins coins);
        Task DeleteCoinAsync(int ID);
    }
}
