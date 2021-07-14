using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Models
{
	public class Rating
	{
        [Key]
        public int IdRating { get; set; }

        public int Value { get; set; }
        public string Comment { get; set; }
        public int ProductID { get; set; }

        public DateTime DateRating { get; set; }

        public Product Product { get; set; }
    }
}
