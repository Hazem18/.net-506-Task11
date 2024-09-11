using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Model
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; } = null!;
        public int CustomerId { get; set; }
        public Product Product { get;} = null!;
        public int ProductId { get; set; }
        public Store Store { get; set; } = null!;
        public int StoreId { get; set; }
    }
}
