using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class FoodItemsController: ControllerBase
{
    private readonly DataContext _context;
    public FoodItemsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
    {
         return await _context.FoodItems.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoodItem>> GetFoodItem(int id)
    {
        var foodItem = await _context.FoodItems.FindAsync(id);

        return foodItem;
    }

}