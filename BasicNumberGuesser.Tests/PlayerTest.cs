using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicNumberGuesser.Tests
{
    [TestClass]
    public class PlayerTest
    {
        Player playertest = new Player();
        [TestMethod]
        //test determines if the returned number is indeed in the 0-10 range
        public void TestLostChancesOfPlayer()
        {
            playertest.SetChances(5);
            playertest.LoseChance();
            Assert.AreEqual(4, playertest.GetChances());

        }
    }
}
