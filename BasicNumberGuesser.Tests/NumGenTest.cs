using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicNumberGuesser.Tests
{
    [TestClass]
    public class NumberGeneratorTest
    {
        NumberGenerator numgentest = new NumberGenerator();
        [TestMethod]
        //test determines if the returned number is indeed in the 0-10 range
        public void TestNumberGenerationEQreturn()
        {
            numgentest.GenerateCorrectNum();
            
            bool result = false;
            if (numgentest.GetCorrectNum() >= 0 && numgentest.GetCorrectNum() <= 10)
            { 
                result = true; 
            }
            Assert.IsTrue(result);
        }
    }
}
