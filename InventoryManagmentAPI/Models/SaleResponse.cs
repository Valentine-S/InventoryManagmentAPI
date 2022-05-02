using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagmentAPI.Models
{
    public class SaleResponse
    {
        public List<Sale> saleData { get; set; } = new List<Sale>();
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
    }
}
