using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace skilleo.tests
{
    [TestClass]
    public class RockPaperScissorTournament
    {
        [TestMethod]
        public void RockPaperScissors_WithFourQualifyingPlayers_ShouldReturnCorrectWinner()
        {
            const string input = "Paul-P, Dave-S, Jane-R, Mike-P";

            // Build players dictionary.
            var players = input.Split(',')
                .Select(player => player.Split('-'))
                .ToDictionary(playerMove => playerMove[0].Trim(), playerMove => playerMove[1].Trim());

            // Find the winner.
            var winner = new challenges.RockPaperScissorTournament().PlayTournament(players);

            Assert.AreEqual("Dave", winner);
        }

        [TestMethod]
        public void RockPaperScissors_WithoutEnoughPlayers_ShouldReturnNoTournamentMessage()
        {
            const string input = "Paul-P";

            // Build players dictionary.
            var players = input.Split(',')
                .Select(player => player.Split('-'))
                .ToDictionary(playerMove => playerMove[0].Trim(), playerMove => playerMove[1].Trim());

            // Find the winner.
            var winner = new challenges.RockPaperScissorTournament().PlayTournament(players);

            Assert.AreEqual(challenges.RockPaperScissorTournament.NoTournamentString, winner);
        }

        [TestMethod]
        public void RockPaperScissors_WithOddNumberOfPlayers_ShouldReturnCorrectWinner()
        {
            const string input = "Paul-P, Dave-S, Jane-R, Mike-P, Louis-S";

            // Build players dictionary.
            var players = input.Split(',')
                .Select(player => player.Split('-'))
                .ToDictionary(playerMove => playerMove[0].Trim(), playerMove => playerMove[1].Trim());

            // Find the winner.
            var winner = new challenges.RockPaperScissorTournament().PlayTournament(players);

            Assert.AreEqual("Dave", winner);
        }

        [TestMethod]
        public void RockPaperScissors_TieMatch_ShouldReturnFirstPlayer()
        {
            const string input = "Paul-P, Dave-P";

            // Build players dictionary.
            var players = input.Split(',')
                .Select(player => player.Split('-'))
                .ToDictionary(playerMove => playerMove[0].Trim(), playerMove => playerMove[1].Trim());

            // Find the winner.
            var winner = new challenges.RockPaperScissorTournament().PlayTournament(players);

            Assert.AreEqual("Paul", winner);
        }

        [TestMethod]
        public void RockPaperScissors_PlayerWithLighter_ShouldNotBeAllowed()
        {
            const string input = "Paul-P, Dave-S, Bob-L, Jane-R, Mike-P, Louis-S";

            // Build players dictionary.
            var players = input.Split(',')
                .Select(player => player.Split('-'))
                .ToDictionary(playerMove => playerMove[0].Trim(), playerMove => playerMove[1].Trim());

            // Find the winner.
            var winner = new challenges.RockPaperScissorTournament().PlayTournament(players);

            Assert.AreEqual("Dave", winner);
        }
    }
}
