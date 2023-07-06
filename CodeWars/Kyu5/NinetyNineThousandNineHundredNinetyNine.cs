/*
https://www.codewars.com/kata/5463c8db865001c1710003b2
Write a method that takes a number and returns a string of that number in English.

Your method should be able to handle any number between 0 and 99999. If the given number is outside of that range or not an integer, the method should return an empty string.
Examples

0      -->  "zero"
27     -->  "twenty seven"
100    -->  "one hundred"
7012   -->  "seven thousand twelve"
99205  -->  "ninety nine thousand two hundred five"
*/

namespace CodeWars.Kyu5
{
    internal class NinetyNineThousandNineHundredNinetyNine
    {
        #region Fields

        private static readonly Dictionary<int, string> SimpleNumbers = new()
        {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" },
            { 100, "hundred" },
            { 1000, "thousand" }
        };

        #endregion

        #region Methods

        public static string NumberToEnglish(int number)
        {
            if (number is < 0 or > 99999) return "";
            if (number == 0) return SimpleNumbers[0];

            var english = "";

            if (number >= 1000)
            {
                english = $"{TwoDigitNumberToEnglish(number / 1000)} {SimpleNumbers[1000]}";
                number %= 1000;
            }

            if (number >= 100)
            {
                english = $"{english} {TwoDigitNumberToEnglish(number / 100)} {SimpleNumbers[100]}";
                number %= 100;
            }

            return $"{english} {TwoDigitNumberToEnglish(number)}".Trim();
        }

        private static string TwoDigitNumberToEnglish(int number)
        {
            var english = "";
            if (number > 20)
            {
                english = $"{english} {SimpleNumbers[number - number % 10]} ";
                number %= 10;
            }

            if (number > 0) english += SimpleNumbers[number];

            return english.Trim();
        }

        #endregion
    }

    [TestFixture]
    internal class Tests
    {
        #region Methods

        [TestCase(1000, "one thousand")]
        [TestCase(-4, "")]
        [TestCase(0, "zero")]
        [TestCase(1340, "one thousand three hundred forty")]
        [TestCase(7, "seven")]
        [TestCase(11, "eleven")]
        [TestCase(20, "twenty")]
        [TestCase(47, "forty seven")]
        [TestCase(100, "one hundred")]
        [TestCase(305, "three hundred five")]
        [TestCase(4002, "four thousand two")]
        [TestCase(20005, "twenty thousand five")]
        [TestCase(6800, "six thousand eight hundred")]
        [TestCase(14111, "fourteen thousand one hundred eleven")]
        [TestCase(3892, "three thousand eight hundred ninety two")]
        [TestCase(99999, "ninety nine thousand nine hundred ninety nine")]
        public void BasicTest(int n, string expected)
            => Assert.That(NinetyNineThousandNineHundredNinetyNine.NumberToEnglish(n), Is.EqualTo(expected));

        #endregion
    }
}