/**
 * Program to calculate sum of letters used to represent numbers in Words
 * Author: BG
 **/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersCountInNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int startNumber = 1, endNumber = 1000;

            WordFormOfNumber userChoice = new WordFormOfNumber();
            
            for(int i = startNumber ; i <= endNumber ; i++)
            {
                sum += userChoice.GetStringForUserChoice(i).Length;
                //Console.WriteLine(userChoice.GetStringForUserChoice(i) + " "+ userChoice.GetStringForUserChoice(i).Length +" " +sum);
            }
            
            Console.WriteLine("sum of numbers from {0} to {1} is {2}", startNumber, endNumber, sum);
            Console.ReadLine();
        }
    }

    class WordFormOfNumber
    {
        // Dictionary maintains word forms of numbers which will be used during conversion of number to equivalent Word Form 
        Dictionary<int, string> NumberList = new Dictionary<int, string>()
        {
            { 0,"ZERO" }, { 1, "ONE" }, { 2, "TWO" }, { 3, "THREE" },
            { 4, "FOUR" }, { 5, "FIVE" }, { 6, "SIX" }, { 7,"SEVEN" },
            { 8, "EIGHT" }, { 9, "NINE" }, {10, "TEN" },{ 11, "ELEVEN" },
            { 12,"TWELVE" }, { 13, "THIRTEEN" }, { 14,"FOURTEEN" },{ 15,"FIFTEEN" },
            { 16, "SIXTEEN" },{ 17,"SEVENTEEN" }, {18, "EIGHTEEN" }, { 19, "NINETEEN" },
            { 20,"TWENTY" },{ 30,"THIRTY" },{ 40,"FORTY" }, { 50,"FIFTY" },{ 60, "SIXTY" },
            { 70,"SEVENTY" },{ 80,"EIGHTY" }, { 90,"NINETY" },{ 100, "HUNDRED" },  {1000, "ONETHOUSAND" }
        };

        private string GetWordForNumber(int number)
        {
            return NumberList[number]; //returns Word Form from dictionary for number passed as argument
        }

        // Method returns Word Form of either single or double digit number passed as an argument
        private string GetTwoDigitLetterInWords(int twoDigitNumber)
        {
            string wordForTwoDigitNumber = "";

            if (twoDigitNumber < 20 || twoDigitNumber % 10 == 0)
                wordForTwoDigitNumber = GetWordForNumber(twoDigitNumber);
            else
            {

                int digitInUnitPlace = twoDigitNumber % 10, digitInTenPlace = twoDigitNumber / 10;
                wordForTwoDigitNumber = GetWordForNumber(digitInTenPlace * 10) + GetWordForNumber(digitInUnitPlace);
            }
            return wordForTwoDigitNumber;
        }

        public string GetStringForUserChoice(int inputNumber)
        {
            const int HUNDRED = 100, THOUSAND = 1000;

            int digitInHundredPlace = inputNumber / 100;
            int lastTwoDigitNumbers = inputNumber % 100;
            string stringforUserChoice = "";

            if (inputNumber >= 100)
            {
                if (inputNumber % 100 != 0)
                {

                    stringforUserChoice = GetWordForNumber(digitInHundredPlace) + GetWordForNumber(HUNDRED) + "AND" +
                        GetTwoDigitLetterInWords(lastTwoDigitNumbers);

                }
                else
                {
                    if (inputNumber != 1000)
                        stringforUserChoice = GetWordForNumber(digitInHundredPlace) + GetWordForNumber(HUNDRED);
                    else
                        stringforUserChoice = GetWordForNumber(THOUSAND);
                }
            }
            else
                stringforUserChoice = GetTwoDigitLetterInWords(inputNumber);

            return stringforUserChoice;
        }

    }
}