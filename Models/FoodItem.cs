namespace CalorieCountingApp.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Calories { get; set; }
        public string Type { get; set; } = string.Empty; // Продукт или Блюдо
    }
}
