using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRoutes.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [ProdName(MinimLength = 6, MaximLength = 10, ErrorMessage = "Product Name min = 6, max = 10")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
    }

}