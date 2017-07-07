using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evaluacion;
namespace Test
{
    [TestClass]
    public class Test_MoneyParts
    {
        [TestMethod]
        public void test1_MoneyParts()
        {
            MoneyParts oMoneyParts = new MoneyParts();
            string[] array = oMoneyParts.build("0.1");
            string[] resultado = {"0.05,0.05","0.1" };

            CollectionAssert.AreEqual(resultado, array); 
        }

      

    }
}
