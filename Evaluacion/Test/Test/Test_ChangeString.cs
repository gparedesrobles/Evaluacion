using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evaluacion;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Test_ChangeString
    {

        [TestMethod]
        public void test1_ChangeString()
        {
            ChangeString oChangeString = new ChangeString();
            string texto = "123 abcd*3";
            string resultado = oChangeString.build(texto);
            Assert.AreEqual("123 bcde*3", resultado);
            

            texto = "## InterFaz 52";
            resultado = oChangeString.build(texto);
            Assert.AreEqual("## JñufsGba 52", resultado);

        }

        [TestMethod]
        public void test2_ChangeString()
        {
            ChangeString oChangeString = new ChangeString();
            string texto = "**Casa 52";
            string resultado = oChangeString.build(texto);
            Assert.AreEqual("**Dbtb 52", resultado);



            texto = "## InterFaz 52";
            resultado = oChangeString.build(texto);
            Assert.AreEqual("## JñufsGba 52", resultado);

        }


        [TestMethod]
        public void test3_ChangeString()
        {
            ChangeString oChangeString = new ChangeString();
            string texto = "## InterFaz 52";
            string resultado = oChangeString.build(texto);
            Assert.AreEqual("## JñufsGba 52", resultado);

        }

    }
}
