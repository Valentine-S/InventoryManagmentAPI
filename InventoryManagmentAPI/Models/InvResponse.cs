using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InventoryManagmentAPI.Models
{
    public class InvResponse
    {
        public List<Inventory> inventoryData { get; set; } = new List<Inventory>();
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
    }
}
