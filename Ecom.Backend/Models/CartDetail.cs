using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Models
{
	public class CartDetail
	{
        public string CartDetailID { get; set; }

        public int Quantity { get; set; }

        public string CartID { get; set; }

        public Cart Cart { get; set; }

        public string ProductID { get; set; }

        public Product Product { get; set; }
    }
}
