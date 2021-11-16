using _02a_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02a_Claims_UnitTests
{
    

    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepository _claims;
        private Claims claim1;
        private Claims claim2;
        private Claims claim3;

        [TestInitialize]
        public void Init()
        {
            _claims = new ClaimsRepository();
             claim1 = new Claims(1, Claims.ClaimType.Car, "Car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
             claim2 = new Claims(2, Claims.ClaimType.Home, "House fire in Kitchen", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
             claim3 = new Claims(3, Claims.ClaimType.Theft, "stolen pancakes", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            //need to add the claims to repository after creation
            _claims.NewClaim(claim1);
            _claims.NewClaim(claim2);
            _claims.NewClaim(claim3);
        }

        [TestMethod]
        public void CreateNewClaim_ShouldReturnTrue()
        {
            bool expected = true;
            bool actual = _claims.NewClaim(claim1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClaims_ShouldReturnTrue()
        {
           
            Queue<Claims> queue = _claims.GetClaims();
            int expected = 3;

            Assert.AreEqual(expected, queue.Count);
        }

        [TestMethod]
        public void SeeWhosNextInLine_ShouldReturnNext()
        {
            Claims nextClaim = _claims.SeeWhosNextInLine();

            Claims expected = claim1;
            
            Assert.AreEqual(expected, nextClaim);
        }
        [TestMethod]
        public void DeleteExistingClaim_ShouldReturnDeleted()
        {
            Assert.IsTrue(_claims.DeleteExistingClaims());
        }
    }
}
