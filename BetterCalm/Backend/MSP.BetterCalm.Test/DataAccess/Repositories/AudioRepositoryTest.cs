using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AudioRepositoryTest
    {
        [TestMethod]
        public void AudioRepositoryCreationCategoriesTypeTest()
        {
            AudioRepository audioRepository = new AudioRepository(new AudioMapper(),new ContextDB());
            Assert.IsInstanceOfType(audioRepository.Audios, typeof(DataBaseRepository<Audio, AudioDto>));
        }
    }
}