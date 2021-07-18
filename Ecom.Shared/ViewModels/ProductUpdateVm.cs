using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Shared.ViewModels
{
	public class ProductUpdateVm
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public float Price { get; set; }
		public string ProductDescription { get; set; }
		public string Image { get; set; }
		public int? CategoryID { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
