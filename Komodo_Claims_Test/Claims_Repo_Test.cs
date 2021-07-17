using Claim_Poco;
using Claim_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_Claims_Test
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private readonly ClaimRepo _claimsRepo = new ClaimRepo();

        [TestInitialize]
        public void Arrange()
        {
            Claims claims = new Claims(23132, "House", "Tree fall on house.", 3131, new DateTime (10/12/2021), new DateTime (10/15/2021), true);
            _claimsRepo.AddClaimsToList(claims);
        }
        [TestMethod]
        public void UpdateClaims_ClaimDoesNotExist_ReturnsFalse()
        {
            string claimType = "Car";
            Claims updatedClaims = new Claims();

            bool result = _claimsRepo.UpdateExistingClaims(claimType, updatedClaims);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Delete_MovieDoesNot_Exist()
        {
            string deleteClaim = "delete";

            bool result = _claimsRepo.RemoveClaimsFromList(deleteClaim);
            Claims claims = _claimsRepo.GetClaimsByClaimType(deleteClaim);

            Assert.IsNull(claims);
            Assert.IsFalse(result);
        }
    }
}