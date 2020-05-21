using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertNumbertToWords();
        }

        public static void ConvertNumbertToWords()
        {
            string isNegative = "";
            try
            {
                bllSpellNumber objBllSpellNumber = new bllSpellNumber();
                Console.WriteLine("Enter a number to convert to word");
                string number = Console.ReadLine();
                number = Convert.ToDouble(number).ToString();

                if (number.Contains("-"))
                {
                    isNegative = "Minus ";
                    number = number.Substring(1, number.Length - 1);
                }
                if (number == "0")
                {
                    Console.WriteLine("The number in words fomat is \nZero Only");
                }
                else
                {
                    Console.WriteLine("The number in words fomat is \n{0}", isNegative + objBllSpellNumber.ConvertNumberToWords(number));
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
