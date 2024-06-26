using CalorieCountingApp.Data;
using CalorieCountingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalorieCountingApp.Controllers
{
    public class SumCalorieCalculatorController : Controller
    {
        private readonly AppDbContext _context;

        public SumCalorieCalculatorController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString) {
            ViewBag.CurrentFilter = searchString;
            var foodItems = from f in _context.FoodItems select f;

            if (!string.IsNullOrEmpty(searchString)) {
                foodItems = foodItems.Where(f => f.Name.Contains(searchString));
            }
            return View(await foodItems.AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public IActionResult Calculate(int[] foodItemIds, int[] weights) {
            double totalCalories = 0;
            double totalFats = 0;
            double totalProteins = 0;
            List<FoodItem> selectedItems = new List<FoodItem>();

            for (int i = 0; i < foodItemIds.Length; i++) {
                var foodItem = _context.FoodItems.Find(foodItemIds[i]);
                if (foodItem != null) {
                    totalCalories += (foodItem.Calories / 100.0) * weights[i];
                    totalFats += (foodItem.Fats / 100.0) * weights[i];
                    totalProteins += (foodItem.Proteins / 100.0) * weights[i];
                    selectedItems.Add(new FoodItem {
                        Id = foodItem.Id,
                        Name = foodItem.Name,
                        Calories = foodItem.Calories,
                        Fats = foodItem.Fats,
                        Proteins = foodItem.Proteins
                    });
                }
            }

            ViewBag.TotalCalories = totalCalories;
            ViewBag.TotalFats = totalFats;
            ViewBag.TotalProteins = totalProteins;
            ViewBag.SelectedItems = selectedItems;

            return View("Result");
        }
    }
}
