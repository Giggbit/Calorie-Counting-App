namespace CalorieCountingApp.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Calories { get; set; }
        public string Type { get; set; } = string.Empty; // Продукт или Блюдо
        public double Fats { get; set; }
        public double Proteins { get; set; }
    }
}
