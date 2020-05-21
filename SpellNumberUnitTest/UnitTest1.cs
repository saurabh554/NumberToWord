using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpellNumberUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodWithNull()
        {            
            SpellNumber.bllSpellNumber obj = new SpellNumber.bllSpellNumber();
            obj.ConvertNumberToWords(null);
            Assert.Fail("Fails");
        }

        [TestMethod]
        public void TestMethodWithZero()
        {
            //First  
            SpellNumber.bllSpellNumber obj = new SpellNumber.bllSpellNumber();
            obj.ConvertNumberToWords("0");

        }
        [TestMethod]
        public void TestMethodWithNumber()
        {
            //First  
            SpellNumber.bllSpellNumber obj = new SpellNumber.bllSpellNumber();
            obj.ConvertNumberToWords("123546");

        }
        [TestMethod]
        public void TestMethodWithEqual()
        {
            SpellNumber.bllSpellNumber obj = new SpellNumber.bllSpellNumber();
            string res = obj.ConvertNumberToWords("145");
            Assert.AreEqual(res, "One Hundred Fourty Five  Only");

        }
        [TestMethod]
        public void TestMethodWithWord()
        {
            //First  
            var result1 = "";
            SpellNumber.bllSpellNumber obj = new SpellNumber.bllSpellNumber();
            try
            {                
                obj.ConvertNumberToWords("10");
                result1 = "Ten";
            }
            catch (Exception ex) { }

             obj.ConvertNumberToWords("12");
            var result2 = "Twelve";

            var expected = new Object[] { "Ten", "Ten" };
            var actual = new Object[] { result1, result2 };
            Assert.AreEqual(expected, actual);
        }

       // One Hundred Fourty Five  Only
    }
}
