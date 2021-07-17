using MenuItems;
using MenuItems.Cafe_Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems_Repository
{
    public class MealsRepo
    {
        private readonly List<Meals> _mealItemsList = new List<Meals>();

        //Create
        public void AddMealToList(Meals mealList)
        {
            _mealItemsList.Add(mealList);
        }

        //Read
        public List<Meals> GetMeals()
        {
            return _mealItemsList;
        } 

        //Delete
        public bool RemoveMealsItems(string mealName)
        {
            Meals mealList = GetMealsByMealName(mealName);

            if (mealList == null)
            {
                return false;
            }

            int initialCount = _mealItemsList.Count;
            _mealItemsList.Remove(mealList);

            if(initialCount > _mealItemsList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public Meals GetMealsByMealName(string mealName)
        {
            foreach(Meals mealList in _mealItemsList)
            {
                if (mealList.MealName.ToLower() == mealName.ToLower())
                {
                    return mealList;
                }
            }
            return null;
        }
    }
}
