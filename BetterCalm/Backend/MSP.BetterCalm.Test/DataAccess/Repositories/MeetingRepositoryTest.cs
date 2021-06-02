using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class MeetingRepositoryTest
    {
        [TestMethod]
        public void MeetingRepositoryCreationCategoriesTypeTest()
        {
           
            MeetingRepository meetingRepository = new MeetingRepository( new MeetingMapper(),new ContextDb());
            Assert.IsInstanceOfType(meetingRepository.Meetings, typeof(DataBaseRepository<Meeting, MeetingDto>));
        }
    }
}