/*
There are pillars near the road. The distance between the pillars is the same and the width of the pillars is the same. Your function accepts three arguments:

    number of pillars (≥ 1);
    distance between pillars (10 - 30 meters);
    width of the pillar (10 - 50 centimeters).

Calculate the distance between the first and the last pillar in centimeters (without the width of the first and last pillar).
 */

namespace CodeWars.Kyu8
{
    public class Pillars
    {
        private const int CentimeterInMeter = 100;

        public static int CalculateDistanceBetweenPillars(int pillarCount, int distanceBetweenPillars, int pillarWidth)
        {
            if (pillarCount <= 1) return 0;
            var totalDistance = (pillarCount - 1) * distanceBetweenPillars * CentimeterInMeter;
            var totalInnerPillarWidth = (pillarCount - 2) * pillarWidth;
            return totalDistance + totalInnerPillarWidth;
        }
    }

    [TestFixture]
    public class PillarsTests
    {
        [Test]
        public void BasicTest1()
        {
            Assert.AreEqual(0, Pillars.CalculateDistanceBetweenPillars(1, 10, 10), "Testing for number of pillars: 1, distance: 10 m and width: 10 cm");
        }

        [Test]
        public void BasicTest2()
        {
            Assert.AreEqual(2000, Pillars.CalculateDistanceBetweenPillars(2, 20, 25), "Testing for number of pillars: 2, distance: 20 m and width: 25 cm");
        }

        [Test]
        public void BasicTest3()
        {
            Assert.AreEqual(15270, Pillars.CalculateDistanceBetweenPillars(11, 15, 30), "Testing for number of pillars: 11, distance: 15 m and width: 30 cm");
        }
    }
}