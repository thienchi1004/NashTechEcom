using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Shared.ViewModels
{
	public class RatingVm
	{
        public int IdRating { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public int ProductID { get; set; }
        public DateTime DateRating { get; set; }
    }
}
