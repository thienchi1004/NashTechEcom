using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Models
{
	public class Cart
	{
		public string CartID { get; set; }

		public string UserID { get; set; }

		public ICollection<CartDetail> CartDetails { get; set; }
	}
}
