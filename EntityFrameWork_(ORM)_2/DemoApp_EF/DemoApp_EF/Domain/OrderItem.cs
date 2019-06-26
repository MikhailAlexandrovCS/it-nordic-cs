using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoApp_EF.Domain
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public Product Product { get; set; }

        public int NumberOfItems { get; set; }
    }
}
