using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellNumber
{
    public class bllSpellNumber
    {

        /// <summary>
        /// Convert number to wordds
        /// </summary>
        /// <param name="number">123</param>
        /// <returns>One Hundred Twenty Three Only</returns>
        public String ConvertNumberToWords(String number)
        {
            string sCurrencyValue = ConfigurationManager.AppSettings["Currency"];
            String val = "", wholeNo = number, points = "", andStr = "", pointStr = "";
            String endStr = "Only";
            try
            {
                int decimalPlace = number.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = number.Substring(0, decimalPlace);
                    points = number.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";
                        if (sCurrencyValue== SpellNumberUtility.InrCurrency)
                        {
                            endStr = SpellNumberUtility.InrCurrency + endStr;
                        }
                        else
                        {
                            endStr = SpellNumberUtility.UsaCurrency + endStr;
                        }
                        
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }


        /// <summary>
        ///  Calculate no to digital place
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(Number));
                
                if (dblAmt > 0)
                {
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;
                    String digitPlace = "";
                    switch (numDigits)
                    {
                        case 1://ones' range

                            word = OnesPlace(Number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = TensPlace(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            digitPlace = SpellNumberUtility.DigitPlaceHundred;
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            digitPlace = SpellNumberUtility.DigitPlaceThousand;
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            digitPlace = SpellNumberUtility.DigitPlaceMillion;
                            break;
                        case 10://Billions's range
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            digitPlace = SpellNumberUtility.DigitPlaceBillion;
                            break;
                        case 13://Trillion's range
                        case 14:
                        case 15:

                            pos = (numDigits % 13) + 1;
                            digitPlace = SpellNumberUtility.DigitPlaceTrillion;
                            break;
                        //add extra case options for anything above Trillion, Quadrillion up to ... Centillion
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + digitPlace + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }                      
                    }                    
                    if (word.Trim().Equals(digitPlace.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        /// <summary>
        /// Find tensplace from given number
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private String TensPlace(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = TensPlace(Number.Substring(0, 1) + "0") + " " + OnesPlace(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        /// <summary>
        /// Find onesplace from given number
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private String OnesPlace(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        /// <summary>
        ///  Convert to decimal no
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = OnesPlace(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }
    }
}
