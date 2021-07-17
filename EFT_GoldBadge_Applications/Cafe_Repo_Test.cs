using MenuItems;
using MenuItems.Cafe_Enums;
using MenuItems_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EFT_GoldBadge_Applications
{
    [TestClass]
    public class Cafe_Repo_Test
    {
        private readonly MealsRepo _repo = new MealsRepo();

        [TestInitialize]
        public void Arrang()
        {
            Meals meals = new Meals(1, "Big Monster", "Only Roast Beef for the hungry out there.", Ingrediant.RoastBeef, 5);
            _repo.AddMealToList(meals);
        }

        [TestMethod]
        public void RemoveMealsItem_MealDoesNotExist_ReturnsFalse()
        {
            string mealGone = "Gone";

            bool result = _repo.RemoveMealsItems(mealGone);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveMealsItem_MealDoesExist_ReturnsTrue()
        {
            string mealGone = "Gone";

            bool result = _repo.RemoveMealsItems(mealGone);

            Assert.IsFalse(result);
        }
    }
}