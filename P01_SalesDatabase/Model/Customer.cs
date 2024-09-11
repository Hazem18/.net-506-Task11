using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CreaditCardNumber  { get; set; } = null!;
        public ICollection<Sale> Sales { get;} = new List<Sale>();

    }
}
