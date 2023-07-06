/*
https://www.codewars.com/kata/561c20edc71c01139000017c
You are organizing a soccer tournament, so you need to build a matches table.

The tournament is composed by 20 teams. It is a round-robin tournament (all-play-all), so it has 19 rounds, and each team plays once per round. Each team confront the others once in the tournament (each match does not repeat in the tournament).

Your mission is to implement a function buildMatchesTable that receives the number of teams (always a positive and even number) and returns a matrix.

Each line of the matrix represents one round. Each column of the matrix represents one match. The match is represented as an array with two teams. Each team is represented as a number, starting from 1 until the number of teams.

Example:

BuildMatchesTable(4)

Should return a matrix of tuples like that:
{
  new []{(1,2), (3, 4)},  // first round:  1 vs 2, 3 vs 4
  new []{(1,3), (2, 4)},  // second round: 1 vs 3, 2 vs 4
  new []{(1,4), (2, 3)}   // third round:  1 vs 4, 2 vs 3
}

You should not care about the order of the teams in the match, nor the order of the matches in the round. You should just care about the rules of the tournament.

Good luck!

Hint: you may use the preloaded function "Helper.PrintTable()" to debug your results.

*/
namespace CodeWars.Kyu4
{
    internal class OrganizeRoundRobinTournament
    {
        #region Methods

        public static (int, int)[][] BuildMatchesTable(int numberOfTeams)
        {
            var teams = Enumerable.Range(1, numberOfTeams).ToArray();
            var game = new List<(int, int)[]>();

            for (var roundNumber = 0; roundNumber < numberOfTeams - 1; roundNumber++)
            {
                var round = new List<(int, int)>();
                for (var teamIterator = 0; teamIterator < numberOfTeams; teamIterator += 2)
                    round.Add((teams[teamIterator], teams[numberOfTeams - teamIterator - 1]));

                var newList = new List<int> { teams[0] };
                if (numberOfTeams > 2) newList.AddRange(teams[2..numberOfTeams]);
                newList.Add(teams[1]);

                teams = newList.ToArray();
                game.Add(round.ToArray());
            }

            return game.ToArray();
        }

        #endregion
    }

    [TestFixture]
    public class SolutionTest
    {
        #region Methods

        [Test]
        public void Test2Teams()
        {
            var expected = new[] { new[] { (1, 2) } };
            var actual = OrganizeRoundRobinTournament.BuildMatchesTable(2);
            Assert.That(actual, Has.Length.EqualTo(1), "Should have 1 round");
            Assert.That(actual[0], Has.Length.EqualTo(1), "The round should have 1 match");
            if (actual[0][0].Item1 > actual[0][0].Item2) (actual[0][0].Item1, actual[0][0].Item2) = (actual[0][0].Item2, actual[0][0].Item1);
            Assert.AreEqual(expected, actual, "The match should be team 1 vs team 2");
        }

        [Test]
        public void Test4Teams()
        {
            var teamsExpected = Enumerable.Range(1, 4).ToList();
            var matchesExpected = new HashSet<(int, int)>
            {
                (1, 2), (3, 4),
                (1, 3), (2, 4),
                (1, 4), (2, 3)
            };

            var actual = OrganizeRoundRobinTournament.BuildMatchesTable(4);
            Assert.That(actual, Has.Length.EqualTo(3), "Should have 3 rounds");
            foreach (var round in actual)
            {
                var teamsByRound = new List<int>();
                Assert.That(round, Has.Length.EqualTo(2), "Each round should have 2 matches");
                foreach (var game in round)
                {
                    Assert.That(game, Is.InstanceOf(typeof((int, int))), "Each match is a tupple of 2 teams");
                    teamsByRound.Add(game.Item1);
                    teamsByRound.Add(game.Item2);
                    Assert.True(
                        matchesExpected.Remove(game.Item1 > game.Item2 ? (game.Item2, game.Item1) : (game.Item1, game.Item2)),
                        $"{game} is a duplicate or doesn't exist");
                }

                teamsByRound.Sort();
                Assert.AreEqual(teamsExpected, teamsByRound, "Each round should have matches with every team");
            }

            Assert.IsEmpty(matchesExpected, "At least one match isn't scheduled");
        }

        #endregion
    }
}