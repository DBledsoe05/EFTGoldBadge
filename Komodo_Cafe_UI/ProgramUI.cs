using MenuItems;
using MenuItems.Cafe_Enums;
using MenuItems_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_UI
{
    class ProgramUI
    {
        private readonly MealsRepo _mealRepo = new MealsRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Welcome To MEAL CREATOR please enter a valid number:\n" +
"----------------------------------------------------\n" +
                    "1. Create New Meal\n" +
                    "2. View All Meals\n" +
                    "3. Delete A Meal\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        ViewAllMeals();
                        break;
                    case "3":
                        DeleteMeal();
                        break;
                    case "4":
                        Console.WriteLine("Enjoy your meals!!!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sir/Mam please press the valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create Meals
        private void CreateMenuItem()
        {
            Console.Clear();
            Meals newMeals = new Meals();

            Console.WriteLine("Enter meal number:");
            string mealID = Console.ReadLine();
            newMeals.MealNumber = int.Parse(mealID);

            Console.WriteLine("Enter Meal's name:");
            newMeals.MealName = Console.ReadLine();

            Console.WriteLine("Enter description for the meal:");
            newMeals.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the ingrediant number you would like to add:\n" +
                "1. Tomatoes\n" +
                "2. Lettece\n" +
                "3. Mayo\n" +
                "4. AmericanCheese\n" +
                "5. Ham\n" +
                "6. Turkey\n" +
                "7. RoastBeef");

            string ingrediantString = Console.ReadLine();
            int ingrediantInt = int.Parse(ingrediantString);
            newMeals.Ingrediants = (Ingrediant)ingrediantInt;

            Console.WriteLine("Enter price for meal:");
            string mealInt = Console.ReadLine();
            newMeals.Price = int.Parse(mealInt);

            _mealRepo.AddMealToList(newMeals);
        }
        //View all Meals
        private void ViewAllMeals()
        {
            Console.Clear();
            List<Meals> listOfMeals = _mealRepo.GetMeals();

            foreach(Meals meals in listOfMeals)
            {
                Console.WriteLine($"Meal Number: {meals.MealNumber}\n" +
                    $"Name: {meals.MealName}\n" +
                    $"Description: {meals.MealDescription}\n" +
                    $"Ingrediants: {meals.Ingrediants}\n" +
                    $"Price: {meals.Price}\n");
            }
        }
        //Delete Meals
        private void DeleteMeal()
        {
            Console.Clear();
            ViewAllMeals();
            Console.WriteLine("\nEnter meal's name that you want thrown in the trash:");
            string input = Console.ReadLine();
            bool mealDeleted = _mealRepo.RemoveMealsItems(input);

            if (mealDeleted)
            {
                Console.WriteLine("Meal deleted.");
            }
            else
            {
                Console.WriteLine("Meal not deleted.");
            }
        }
    }
}
