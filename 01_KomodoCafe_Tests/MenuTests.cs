using _01_KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void AddMenuItemsToMenu_ShouldReturnMealName()
        {
            Menu MenuItem = new Menu();

            Menu.mealName = "Jameson Burger";

            string expected = "Jameson Burger";
            string actual = Menu.mealName;

            Assert.AreEqual(expected, actual); 
    }
}
