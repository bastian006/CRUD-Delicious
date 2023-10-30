#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    
    [Required(ErrorMessage = "Dish Name is required.")]
    [MaxLength(45)]
    [Display(Name="Dish Name:")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Chef Name is required.")]
    [MaxLength(45)]
    [Display(Name="Chef Name:")]
    public string Chef { get; set; }

    [Required(ErrorMessage = "Tastiness Rating is required.")]
    [Range(1, 5)]
    [Display(Name="Tastiness Rating:")]
    public int? Tastiness { get; set; }

    [Required(ErrorMessage = "Calorie Amount is required.")]
    [Range(1, 2000, ErrorMessage = "Calories must be between 1 and 2000.")]
    [Display(Name="Total Calories:")]
    public int? Calories { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [MaxLength(255)]
    [Display(Name="Description:")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
