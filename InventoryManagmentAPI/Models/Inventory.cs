using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace InventoryManagmentAPI.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public string ItemName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string SKU { get; set; }
        public string Condition { get; set; }
        public string Brand { get; set; }
    }
}
