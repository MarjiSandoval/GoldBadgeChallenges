using _03_BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_BadgesTests
{
    [TestClass]
    public class BadgeTests
    {
        private BadgeRepository _badge;
        private Badge badge1;
        private Badge badge2;
        private Badge badge3;
        [TestInitialize]
        public void Init()
        {
            _badge = new BadgeRepository();
            badge1 = new Badge(12345, new List<string> { "A7" });
            badge2 = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            badge3 = new Badge(32345, new List<string> { "A4","A5" }); 

            _badge.AddBadge(badge1);
            _badge.AddBadge(badge2);
            _badge.AddBadge(badge3);
        }
        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            Badge badgeA = new Badge(44875, new List<string> { "A7" });

            bool expected = true;
            bool actual = _badge.AddBadge(badgeA);

           Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GiveMeOneBadge_ShouldReturnBadge()
        {
            Badge badge4 = new Badge(42345, new List<string> { "A1", "A4", "B1", "B2" });
            _badge.AddBadge(badge4);
            int expected = 42345;
            Badge actual = _badge.GiveMeOneBadge(42345);

            Assert.AreEqual(expected, actual.BadgeNumber);

        }
        [TestMethod]
        public void AddDoor_ShouldReturnTrue()
        {
            var success = _badge.AddDoor(32345, "D6");
            foreach (var item in badge3.Doors)
            {
                Console.WriteLine(item);
                
            }
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void RemoveDoor_ShouldReturnTrue()
        {
            var success = _badge.RemoveDoor(32345, "A5");
            foreach (var item in badge3.Doors)
            {
                Console.WriteLine(item);
            }
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void RemoveBadge_ShouldReturnTrue()
        {
            var success = _badge.RemoveBadge(badge3);
            foreach (var item in _badge.GetAllBadges())
            {
                Console.WriteLine(item.Value.BadgeNumber);
            }
            Assert.AreEqual(true, success);
        }
    }
}
