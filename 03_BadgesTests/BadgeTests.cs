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
            Badge badge1 = new Badge(12345, new List<string> { "A7" });
            Badge badge2 = new Badge(22345, new List<string> { "A1, A4, B1, B2" });
            Badge badge3 = new Badge(32345, new List<string> { "A4, A5" }); 

            _badge.AddBadge(badge1);
            _badge.AddBadge(badge2);
            _badge.AddBadge(badge3);
        }
        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            bool expected = true;
            bool actual = _badge.AddBadge(badge1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GiveMeOneBadge_ShouldReturnTrue()
        {
            Dictionary<Badge, doors> dict = _badge.GiveMeOneBadge(???);
            int expected = _badge.GiveMeOneBadge()

        }
    }
}
