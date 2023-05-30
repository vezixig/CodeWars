﻿using NUnit.Framework;

/*
Write a function which calculates the average of the numbers in a given list.
Note: Empty arrays should return 0.
 */

namespace CodeWars.Kyu8
{
    internal class CalculateAverage
    {
        public static double FindAverage(double[] numbers)
            => numbers.Any() ? numbers.Average() : 0;
    }

    [TestFixture]
    public class CalculateAverageTests
    {
        [Test]
        public void ExampleTest()
        {
            double[] array = new double[] { 17, 16, 16, 16, 16, 15, 17, 17, 15, 5, 17, 17, 16 };
            Assert.AreEqual(200.0 / 13.0, CalculateAverage.FindAverage(array));

            // Should return 0 on empty array
            Assert.AreEqual(0, CalculateAverage.FindAverage(new double[] { }));
        }
    }
}
