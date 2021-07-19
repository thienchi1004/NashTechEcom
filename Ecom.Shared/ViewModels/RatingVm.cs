using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Shared.ViewModels
{
	public class RatingVm
	{
        [BindNever]
        public int IdRating { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public int ProductID { get; set; }
        [BindNever]
        public DateTime DateRating { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }

    }
}
