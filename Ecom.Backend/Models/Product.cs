using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Models
{
	public class Product
	{
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string ProductDescription { get; set; }
        public string Image { get; set; }
        public float RateStar { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [ForeignKey("Category")]
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public int Value { get; set; }
    }
}
