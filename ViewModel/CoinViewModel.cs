using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.ViewModel
{
    public class CoinViewModel
    {
        public IEnumerable<Coins> Coins { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
