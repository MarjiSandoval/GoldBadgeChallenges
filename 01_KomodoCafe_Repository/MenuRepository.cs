using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _01_KomodoCafe_Repository.Menu;

namespace _01_KomodoCafe_Repository
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menu = new List<Menu>();

        //Create
        public bool AddToMenu(Menu menu)
        {
            int menuItem = _menu.Count;
            _menu.Add(menu);

            bool wasSuccessful = (_menu.Count > menuItem) ? true : false;
            return wasSuccessful;
        }

        //Read - Get all

        public List<Menu> GetMenu()
        {
            return _menu;
        }

        // Get one
        public Menu GetMenuByMealName(string mealName)
        {
            foreach (Menu MealName in _menu)  
            {
                if (Menu.MealName == mealName)
                {
                    return MealName;
                }
            }
            return null;
        }

        //Update
        public bool UpdateExistingMenuItems(string newItem)
        {
            Menu oldItem = GetMenuByMealName(mealName);
            if (MealName != null)
            {
                oldItem.MealName = newItem.MealName;
                oldItem.Price = newItem.Price;
                oldItem.ID = newItem.ID;

                return true;


            }
            else
                return false;
        }
        
        // Delete

        public List<Menu> DeleteExistingMenuItem(string MealName)
        {
            return DeleteExistingMenuItem(GetMenuByMealName(mealName));
        }



    }
}
