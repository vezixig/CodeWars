using NUnit.Framework;

/*
https://www.codewars.com/kata/5a2be17aee1aaefe2a000151
I'm new to coding and now I want to get the sum of two arrays... Actually the sum of all their elements. I'll appreciate for your help.
P.S. Each array includes only integer numbers. Output is a number too.
*/

namespace CodeWars.Kyu8
{
    internal class ArrayPlusArray
    {
        public static int CalculateArraySum(int[] array1, int[] array2)
            => array1.Sum() + array2.Sum();
    }

    [TestFixture]
    public class ArrayPlusArrayTests
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(21, ArrayPlusArray.CalculateArraySum(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));
            Assert.AreEqual(-21, ArrayPlusArray.CalculateArraySum(new int[] { -1, -2, -3 }, new int[] { -4, -5, -6 }));
            Assert.AreEqual(15, ArrayPlusArray.CalculateArraySum(new int[] { 0, 0, 0 }, new int[] { 4, 5, 6 }));
            Assert.AreEqual(2100, ArrayPlusArray.CalculateArraySum(new int[] { 100, 200, 300 }, new int[] { 400, 500, 600 }));
        }
    }
}