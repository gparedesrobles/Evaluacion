using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evaluacion;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Test_CompleteRange
    {
        [TestMethod]
        public void test1_CompleteRange()
        {
            CompleteRange oCompleteRange = new CompleteRange();
            List<int> resultado = oCompleteRange.build(new List<int> { 2, 1, 4, 5 });
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 },resultado);
            
        }

        [TestMethod]
        public void test2_CompleteRange()
        {
            CompleteRange oCompleteRange = new CompleteRange();
            List<int> resultado = oCompleteRange.build(new List<int> { 4, 2, 9 });
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },resultado);

        }

        [TestMethod]
        public void test3_CompleteRange()
        {
            CompleteRange oCompleteRange = new CompleteRange();
            

            List<int> resultado = oCompleteRange.build(new List<int> { 58, 60, 55 });

            List<int> resultado_esperado = new List<int>();
            for (int i = 1; i <= 60 ; i++)
            {
                resultado_esperado.Add(i);
            }

            CollectionAssert.AreEqual( resultado_esperado, resultado);

        }
    }
}
