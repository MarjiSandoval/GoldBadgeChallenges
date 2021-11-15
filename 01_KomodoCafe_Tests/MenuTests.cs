using _01_KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class MenuTests
    {
        private MenuRepository _mRepo;
        private Menu MenuItem;
        [TestInitialize]
        public void init()
        {
            _mRepo = new MenuRepository();
            MenuItem = new Menu("Jameson Burger", "A burger marinated in Jameson", "Ground beef, lettuce, tomato, cheese, horseradish", 10.00d);
            _mRepo.AddToMenu(MenuItem);
        }

        [TestMethod]
        public void AddMenuItemsToMenu_ShouldReturnTrue()
        {
            
            bool expected = true;
            bool actual = _mRepo.AddToMenu(MenuItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnMenu()
        {
           List<Menu> menuItems = _mRepo.GetMenu();
            int expected = 1;

            Assert.AreEqual(expected, menuItems.Count);

        }

        [TestMethod]
        public void GetMenuByMealID_ShoudReturnTrue()
        {
            Menu retrievedMenu =  _mRepo.GetMenuByMealID(1);
           
            string expected = "Jameson Burger";
            Assert.AreEqual(expected, retrievedMenu.MealName);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            
            Assert.IsTrue( _mRepo.DeleteExistingMenuItem(1));
            
            

        }
    }
}
