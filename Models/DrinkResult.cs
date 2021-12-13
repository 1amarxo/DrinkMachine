using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class DrinkResult
    {
        public virtual IEnumerable<Drink> News { get; set; }
        public double TotalPages { get; set; }

    }
}
