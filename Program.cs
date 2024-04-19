using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    internal class Program
    {
        static string CheckForHex()
        {
            string userInput;
            while (true)
            {
                Console.WriteLine("Please enter the hexadecimal number: ");

                userInput = Console.ReadLine();

                bool error = false;

                if (userInput.Length > 13)
                {
                    Console.WriteLine("The program can only do 13 digit hexadecimals!!!");
                    Console.WriteLine("-----------------------------------------------------");
                    continue;
                }

                for (int i = 0; i < userInput.Length; i++)
                {
                    if (userInput[i] == '0' ||
                        userInput[i] == '1' ||
                        userInput[i] == '2' ||
                        userInput[i] == '3' ||
                        userInput[i] == '4' ||
                        userInput[i] == '5' ||
                        userInput[i] == '6' ||
                        userInput[i] == '7' ||
                        userInput[i] == '8' ||
                        userInput[i] == '9' ||
                        userInput[i] == 'A' ||
                        userInput[i] == 'B' ||
                        userInput[i] == 'C' ||
                        userInput[i] == 'D' ||
                        userInput[i] == 'E' ||
                        userInput[i] == 'F')
                    {
                        continue;
                    }
                    else
                    {
                        error = true;
                        break;
                    }
                }
                if (error == true)
                {
                    Console.WriteLine("This is not a hexadecimal number!!");
                    Console.WriteLine("-----------------------------------------------------");
                    continue;
                }
                if (error == false)
                {
                    break;
                }
            }
            return userInput;
        }
        static long CheckForDec()
        {
            long userInput;
            string userInputString;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the decimal number: ");

                    userInputString = Console.ReadLine();

                    if (userInputString.Length > 18)
                    {
                        Console.WriteLine("The program can only do 18 digit decimals!!!");
                        Console.WriteLine("-----------------------------------------------------");
                        continue;
                    }

                    userInput = long.Parse(userInputString);
                }
                catch (Exception)
                {
                    Console.WriteLine("This is not a decimal number!!");
                    Console.WriteLine("-----------------------------------------------------");
                    continue;
                }
                break;
            }

            return userInput;
        }
        static string CheckForBi()
        {
            string userInput;
            while (true)
            {
                Console.WriteLine("Please enter the binary number: ");
                
                userInput = Console.ReadLine();

                bool error = false;

                if (userInput.Length > 53)
                {
                    Console.WriteLine("The program can only do 53 digit binary code!!!");
                    Console.WriteLine("-----------------------------------------------------");
                    continue;
                }

                for (int i = 0; i < userInput.Length; i++)
                {
                    if (userInput[i] == '0' ||
                        userInput[i] == '1')
                    {
                        continue;
                    }
                    else
                    {
                        error = true;
                        break;
                    }
                }
                if (error == true)
                {
                    Console.WriteLine("This is not a binary number!!");
                    Console.WriteLine("-----------------------------------------------------");
                    continue;
                }
                else if (error == false)
                {
                    break;
                }
            }
            return userInput;
        }
        static long HTD(string userHex)
        {
            string hexNumber;
            long result = 0;
            List<long> lettersConvert = new List<long>();
            hexNumber = userHex;
            int i = hexNumber.Length;
            int e = 0;


            while (i != e)
            {
                if (Char.IsNumber(hexNumber[e]) == true)
                {
                    lettersConvert.Add(long.Parse(hexNumber[e].ToString()));
                }
                else if (hexNumber[e].Equals('A') == true)
                {
                    lettersConvert.Add(10);
                }
                else if (hexNumber[e].Equals('B') == true)
                {
                    lettersConvert.Add(11);
                }
                else if (hexNumber[e].Equals('C') == true)
                {
                    lettersConvert.Add(12);
                }
                else if (hexNumber[e].Equals('D') == true)
                {
                    lettersConvert.Add(13);
                }
                else if (hexNumber[e].Equals('E') == true)
                {
                    lettersConvert.Add(14);
                }
                else if (hexNumber[e].Equals('F') == true)
                {
                    lettersConvert.Add(15);
                }
                else { Console.WriteLine("This is not a hexadecimal!!!"); }

                e++;
            }

            e = 0;
            int a = i - 1;

            while (i != e)
            {
                result = (long)(Math.Pow(16, (a)) * lettersConvert[e] + result);
                e++;
                a--;
            }
            return result;
        }
        static string DTH(long userDec)
        {
            string result = "";
            string hexRemainder = "";
            long decNumber = userDec;

            int i = 0;
            int e = decNumber.ToString().Length;

            while (decNumber != 0)
            {
                long remainder = decNumber % 16;
                if (remainder.ToString().Length == 1)
                {
                    hexRemainder = remainder.ToString();
                }
                else if (remainder == 10)
                {
                    hexRemainder = "A";
                }
                else if (remainder == 11)
                {
                    hexRemainder = "B";
                }
                else if (remainder == 12)
                {
                    hexRemainder = "C";
                }
                else if (remainder == 13)
                {
                    hexRemainder = "D";
                }
                else if (remainder == 14)
                {
                    hexRemainder = "E";
                }
                else if (remainder == 15)
                {
                    hexRemainder = "F";
                }

                result = hexRemainder + result;

                double dividedecNumber = decNumber / 16;

                decNumber = (long)Math.Floor(dividedecNumber);

                long newdecNumber = decNumber;

                i++;
                e--;
            }
            return result;
        }
        static long BTD(string userBi)
        {
            long result = 0;
            int i = userBi.Length;
            int e = 0;
            int a = i - 1;

            while (i > e)
            {
                result = (long)(Math.Pow(2, (a--)) * (long)Char.GetNumericValue(userBi[e++]) + result);
            }

            return result;

        }
        static string DTB(long userDec)
        {
            string result = "";
            string biRemainder;
            long decNumber = userDec;

            while (decNumber != 0)
            {
                long remainder = decNumber % 2;
                biRemainder = remainder.ToString();

                result = biRemainder + result;

                double dividedecNumber = decNumber / 2;

                decNumber = (long)Math.Floor(dividedecNumber);
            }

            return result;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello and welcome to the hexadecimal and binary converter!");
                Console.WriteLine("-----------------------------------------------------");
                string choice = "Hallo";

                while (true)
                {
                    Console.WriteLine("Type HtD for hexadecimal to decimal!");
                    Console.WriteLine("Type DtH for decimal to hexadecimal!");
                    Console.WriteLine("Type BtD for binary to decimal!");
                    Console.WriteLine("Type DtB for decimal to binary!");
                    Console.WriteLine("Type HtB for hexadecimal to binary!");
                    Console.WriteLine("Type BtH for binary to hexadecimal!");
                    Console.WriteLine("Type E for exit!");

                    choice = Console.ReadLine().ToLower();

                    if (choice == "htd" || choice == "dth" || choice == "btd" || choice == "dtb" || choice == "htb" || choice == "bth" || choice == "e")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("WRONG INPUT!");
                        Console.WriteLine("-----------------------------------------------------");
                    }
                }

                if (choice == "htd")
                {
                    Console.WriteLine("As a decimal number it is : " + HTD(CheckForHex()));
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                }

                else if (choice == "dth")
                {
                    Console.WriteLine("As a hexadecimal number it is: " + DTH(CheckForDec()));
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                }

                else if (choice == "btd")
                {
                    Console.WriteLine("As decimal number it is: " + BTD(CheckForBi()));
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                }

                else if (choice == "dtb")
                {
                    Console.WriteLine("As a binary number it is: " + DTB(CheckForDec()));
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                }

                else if (choice == "htb")
                {
                    Console.WriteLine("As a binary number it is: " + DTB(HTD(CheckForHex())));
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                }

                else if (choice == "bth")
                {
                    Console.WriteLine("As a hexadecimal number it is: " + DTH(BTD(CheckForBi())));
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------");
                }

                else
                {
                    Console.WriteLine("Goodbye!!");
                    break;
                }
            }
        }
    }
}
