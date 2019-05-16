using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Product

    {
        //Prueba
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
