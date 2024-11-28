using System.ComponentModel.DataAnnotations;

public class FoodItem
{
    [Key]
    public int Id{get; set;}
    [Required(ErrorMessage = "Name is required")]
    public required string Name {get; set;}
    [Range(0, 100, ErrorMessage = "Enter value 0 to 100")]
    public int NutritionValue{get; set;}
}