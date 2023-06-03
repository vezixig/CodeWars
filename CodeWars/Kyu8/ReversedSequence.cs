using NUnit.Framework;

/*
https://www.codewars.com/kata/5a00e05cc374cb34d100000d/train/csharp
Build a function that returns an array of integers from n to 1 where n>0.

Example : n=5 --> [5,4,3,2,1]

What I leanred: Enumerable.Range() is another apporach to create a filled list
*/

namespace CodeWars.Kyu8
{
    internal class ReversedSequence
    {
        public static int[] ReverseSeq(int sequenceLength)
        {
            var array = new int[sequenceLength];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = sequenceLength--;
            }
            return array;
        }
    }

    [TestFixture]
    public class ReversedSequenceTests
    {
        [Test]
        public void SampleTest()
        {
            Assert.That(ReversedSequence.ReverseSeq(5), Is.EqualTo(new int[] { 5, 4, 3, 2, 1 }));
        }
    }
}