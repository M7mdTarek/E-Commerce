using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile file { get; set; }

        [ForeignKey("Person")]
        public int? PersonId { get; set; }

        [ForeignKey("Cart")]
        public int? CartId { get; set; }
    }
}
