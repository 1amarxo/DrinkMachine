using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class CoinResult
    {
        public virtual IEnumerable<Coins> Coins { get; set; }
        public double TotalPages { get; set; }
    }
}
