using Badge_Poco;
using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Badge_System_Test
{
    [TestClass]
    public class Badge_Repository_Test
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        [TestInitialize]
        public void Arrange()
        {
            Badge badge = new Badge();
            _badgeRepo.AddBadgesToList(badge);
        }
        [TestMethod]
        public void Badges_CreatedIsNotNull_ReturnsTrue()
        {

            Badge badge = new Badge();
            BadgeRepo repo = new BadgeRepo();
            bool result = repo.AddBadgesToList(badge);
        }
        [TestMethod]
        public void UpdateBadge_BadgeDoesNotExists_ReturnFalse()
        {

            int originalID = 2;
            Badge updateBadge = new Badge();

            bool result = _badgeRepo.UpdateExistingBadges(originalID, updateBadge);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void UpdateBadge_BadgeDoesExists_Return()
        {
            int originalID = 2;
            Badge updateBadge = new Badge();

            bool result = _badgeRepo.UpdateExistingBadges(originalID, updateBadge);

            Assert.IsFalse(result);
        }
    }
}
