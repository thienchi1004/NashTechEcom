using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Shared.ViewModels
{
	public class ProductDetailVm : ProductVm
	{
        public string ProductDescription { get; set; }
        public float RateStar { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Value { get; set; }
    }
}
