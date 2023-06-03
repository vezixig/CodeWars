/*
https://www.codewars.com/kata/55f9b48403f6b87a7c0000bd
Your classmates asked you to copy some paperwork for them. You know that there are 'n' classmates and the paperwork has 'm' pages.

Your task is to calculate how many blank pages do you need. If n < 0 or m < 0 return 0.
Example:

n= 5, m=5: 25
n=-5, m=5:  0
*/

namespace CodeWars.Kyu8
{
    internal class BeginnerSeries1SchoolPaperwork
    {
        public static int Paperwork(int classmateCount, int pageCount)
        => classmateCount > 0 && pageCount > 0
                ? classmateCount * pageCount
                : 0;
    }

    [TestFixture]
    public class BeginnerSeries1SchoolPaperworkTests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(25, BeginnerSeries1SchoolPaperwork.Paperwork(5, 5));
            Assert.AreEqual(0, BeginnerSeries1SchoolPaperwork.Paperwork(5, -5));
            Assert.AreEqual(0, BeginnerSeries1SchoolPaperwork.Paperwork(-5, -5));
            Assert.AreEqual(0, BeginnerSeries1SchoolPaperwork.Paperwork(-5, 5));
            Assert.AreEqual(0, BeginnerSeries1SchoolPaperwork.Paperwork(5, 0));
        }
    }
}