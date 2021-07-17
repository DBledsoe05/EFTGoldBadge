using MenuItems.Cafe_Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems
{
    public class Meals
    {

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public Ingrediant Ingrediants { get; set; }
        public int Price { get; set; }

        public Meals() { }

        public Meals(int mealNumber, string mealName, string mealDescription, Ingrediant ingrediant, int price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Price = price;
        }
    }
}
