using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentAPI.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public int InventoryId { get; set; }
        public string DatePurchased { get; set; }
        public double RetailPrice { get; set; }
        public double TaxAndFee { get; set; }
        public double FullPurchasePrice { get; set; }
        public string DateSold { get; set; }
        public double SalePrice { get; set; }
        public double SalePriceAfterFee { get; set; }
        public double Profit { get; set; }
    }
}
