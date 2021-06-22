using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicNumberGuesser.Tests
{
    [TestClass]
    public class WinCheckerTest
    {
        WinChecker wincheckertest = new WinChecker();
        Player playertest = new Player();
        NumberGenerator numgentest = new NumberGenerator();

        //test determines if the returned number is indeed in the 0-10 range
        [TestMethod]
        public void WinCheckTest()
        {
            numgentest.GenerateCorrectNum();
            int num = numgentest.GetCorrectNum();
            playertest.SetGuess(num);
            wincheckertest.CheckWin(playertest, numgentest);
            bool result = wincheckertest.GetVictory();

            Assert.IsTrue(result);

        }
    }
}
