using _02a_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02a_Claims_UnitTests
{
    

    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepository _claims;
        [TestInitialize]
        public void init()
        {
            _claims = new ClaimsRepository();
            Claims claim1 = new Claims(1, Claims.ClaimType.Car, "Car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            Claims claim2 = new Claims(2, Claims.ClaimType.Home, "House fire in Kitchen", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claims claim3 = new Claims(3, Claims.ClaimType.Theft, "stolen pancakes", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            //need to add the claims to repository after creation
            _claims.NewClaim(claim1);
            _claims.NewClaim(claim3);
            _claims.NewClaim(claim2);
        }

        [TestMethod]
        public void CreateNewClaim_ShouldReturnTrue()
        {
            bool expected = true;
            bool actual = _claims.NewClaim(;

            Assert.AreEqual(expected, actual)
        }
    }
}
