using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class MeetingRepositoryTest
    {
        [TestMethod]
        public void MeetingRepositoryCreationCategoriesTypeTest()
        {
           
            MeetingRepository meetingRepository = new MeetingRepository( new MeetingMapper(),new ContextDB());
            Assert.IsInstanceOfType(meetingRepository.Meetings, typeof(DataBaseRepository<Meeting, MeetingDto>));
        }
    }
}