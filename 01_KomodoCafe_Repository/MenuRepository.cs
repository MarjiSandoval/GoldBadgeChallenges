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
        int Count = 0;

        //Create
        public bool AddToMenu(Menu menu)
        {
            if (menu is null)
            {
                return false;
            }
            else
            {
                Count++;
                menu.ID = Count;
                _menu.Add(menu);

                return true;
            }


            
        }

        //Read - Get all

        public List<Menu> GetMenu()
        {
            return _menu;
        }

        // Get one
        public Menu GetMenuByMealID(int ID)
        {
            foreach (Menu Meal in _menu)  
            {
                if (Meal.ID == ID)
                {
                    return Meal;
                }
            }
            return null;
        }

        //Update
        //public bool UpdateExistingMenuItems(int ID, Menu newMealData)
        //{
        //    Menu oldItem = GetMenuByMealID(ID);
        //    if (oldItem != null)
        //    {
        //        oldItem.MealName = newMealData.MealName;
        //        oldItem.Price = newMealData.Price;
        //        oldItem.ID = newMealData.ID;

        //        return true;


        //    }
        //    else
        //        return false;
        //}
        
        // Delete

        public bool DeleteExistingMenuItem(int ID)
        {
            foreach (var item in _menu)
            {
                if (item.ID == ID)
                {
                    _menu.Remove(item);
                    return true;
                }
            }
            return false;
            
        }



    }
}
