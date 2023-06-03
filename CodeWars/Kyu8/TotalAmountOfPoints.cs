using NUnit.Framework;
using System.Text.RegularExpressions;

/*
https://www.codewars.com/kata/5bb904724c47249b10000131
Our football team has finished the championship.

Our team's match results are recorded in a collection of strings. Each match is represented by a string in the format "x:y", where x is our team's score and y is our opponents score.

For example: ["3:1", "2:2", "0:1", ...]

Points are awarded for each match as follows:

    if x > y: 3 points (win)
    if x < y: 0 points (loss)
    if x = y: 1 point (tie)

We need to write a function that takes this collection and returns the number of points our team (x) got in the championship by the rules given above.

Notes:

    our team always plays 10 matches in the championship
    0 <= x <= 4
    0 <= y <= 4
 */

namespace CodeWars.Kyu8
{
    internal partial class TotalAmountOfPoints
    {
        public static int CalculateTotalPoints(string[] games)
        {
            if(games == null) throw new ArgumentNullException(nameof(games));

            if (games.Length == 0) return 0;

            if (games.Any(o => PointsInputRegex().IsMatch(o) == false))
                throw new ArgumentException("The list of games contains an invalid value.");

            var totalPoints = games.Sum(o =>
            {
                 var points = o.Split(':').Select(o => int.Parse(o));
                 return points.First() > points.Last() ? 3
                         : points.First() == points.Last() ? 1
                             : 0;
            });
            return totalPoints;
        }

        [GeneratedRegex("^[0-9]*:[0-9]*$")]
        private static partial Regex PointsInputRegex();
    }

    [TestFixture]
    public class TotalAmountOfPointsTests
    {
        [Test]
        public void TestInvalidInput() => Assert.Throws<ArgumentException>(() => TotalAmountOfPoints.CalculateTotalPoints(new string[] { "sefwef" }));

        [Test]
        public void TestNullInput() => Assert.Throws<ArgumentNullException>(() => TotalAmountOfPoints.CalculateTotalPoints(null));

        [Test]
        public void TestEmpty() =>
            Test(Array.Empty<string>(), 0);

        [Test]
        public void Test1() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "3:1", "4:1", "3:2", "4:2", "4:3" }, 30);

        [Test]
        public void Test2() =>
            Test(new[] { "1:1", "2:2", "3:3", "4:4", "2:2", "3:3", "4:4", "3:3", "4:4", "4:4" }, 10);

        [Test]
        public void Test3() =>
            Test(new[] { "0:1", "0:2", "0:3", "0:4", "1:2", "1:3", "1:4", "2:3", "2:4", "3:4" }, 0);

        [Test]
        public void Test4() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "1:3", "1:4", "2:3", "2:4", "3:4" }, 15);

        [Test]
        public void Test5() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:4", "2:2", "3:3", "1:4", "2:3", "2:4", "3:4" }, 12);

        private void Test(string[] input, int expectedOutput) =>
            Assert.AreEqual(expectedOutput, TotalAmountOfPoints.CalculateTotalPoints(input));
    }
}