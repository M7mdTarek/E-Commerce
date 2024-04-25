using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Cart
    {

        public int Id { get; set; }


        [ForeignKey("Person")]
        public int PersonId { get; set; }


        public int Total { get; set; }

        
        public List<Product> Products { get; set; }

        
    }
}
