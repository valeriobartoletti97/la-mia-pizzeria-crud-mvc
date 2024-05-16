using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Data
{
    public class Pizza
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Description { get; set; }
        public string? Image { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public decimal Price { get; set; }

        public Pizza(string name, string description, string image, decimal price)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }

        public Pizza()
        {

        }
    }
}
