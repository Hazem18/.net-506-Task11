using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Model
{
     
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Quantity { get; set; }
        public double Price { get; set; }
        public ICollection<Sale> Sales { get;} = new List<Sale>();
        public string Description { get; set; } = null!;
    }
}
