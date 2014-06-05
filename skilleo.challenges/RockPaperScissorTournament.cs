using System.Collections.Generic;
using System.Linq;

namespace skilleo.challenges
{
    public class RockPaperScissorTournament : Challenge
    {
        public const string NoTournamentString = "No tournament";

        public override string ProcessInput(string input)
        {
            throw new System.NotImplementedException();
        }

        public string PlayTournament(Dictionary<string, string> players)
        {
            // Remove players whose move is not R, P, or S
            var qualifyingPlayers = players
                .Where(player => player.Value.ToUpper() == "R" || player.Value.ToUpper() == "P" || player.Value.ToUpper() == "S")
                .ToDictionary(player => player.Key, player => player.Value);

            if (qualifyingPlayers.Count < 2)
            {
                return NoTournamentString;
            }

            var nextRoundPlayers = qualifyingPlayers;

            do
            {
                nextRoundPlayers = PlayRound(nextRoundPlayers);

            } while (nextRoundPlayers.Count > 1);

            return nextRoundPlayers.ToArray()[0].Key;
        }

        private static Dictionary<string, string> PlayRound(Dictionary<string, string> players)
        {
            var nextRoundPlayers = new Dictionary<string, string>();

            // Only one player, he wins this round.
            if (players.Count == 1)
            {
                return players;
            }

            var playersArr = players.ToArray();

            for (var i = 0; i < playersArr.Length; i += 2)
            {
                if (i == playersArr.Length - 1)
                {
                    // player has no opponent due to odd number of players
                    continue;
                }

                if (playersArr[i].Value == playersArr[i + 1].Value)
                {
                    // tie, advance player[i] to next round
                    nextRoundPlayers.Add(playersArr[i].Key, playersArr[i].Value);
                    continue;
                }

                switch (playersArr[i].Value.ToUpper())
                {
                    case "R":
                        if (playersArr[i + 1].Value == "S")
                        {
                            // rock beats scissors, advance player[i]
                            nextRoundPlayers.Add(playersArr[i].Key, playersArr[i].Value);
                        }
                        else
                        {
                            // paper beats rock, advance player[i+1]
                            nextRoundPlayers.Add(playersArr[i + 1].Key, playersArr[i + 1].Value);
                        }
                        break;

                    case "P":
                        if (playersArr[i + 1].Value == "R")
                        {
                            // paper beats rock, advance player[i]
                            nextRoundPlayers.Add(playersArr[i].Key, playersArr[i].Value);
                        }
                        else
                        {
                            // scissor beats paper, advance player[i+1]
                            nextRoundPlayers.Add(playersArr[i + 1].Key, playersArr[i + 1].Value);
                        }
                        break;

                    case "S":
                        if (playersArr[i + 1].Value == "P")
                        {
                            // scissor beats paper, advance player[i]
                            nextRoundPlayers.Add(playersArr[i].Key, playersArr[i].Value);
                        }
                        else
                        {
                            // rock beats scissor, advance player[i+1]
                            nextRoundPlayers.Add(playersArr[i + 1].Key, playersArr[i + 1].Value);
                        }
                        break;
                }
            }

            // If there is an odd number of players, the last player automatically advances to the next round.
            if (playersArr.Length % 2 == 1)
            {
                nextRoundPlayers.Add(playersArr[playersArr.Length - 1].Key, playersArr[playersArr.Length - 1].Value);
            }

            return nextRoundPlayers;
        }
    }
}
