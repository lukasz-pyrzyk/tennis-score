using EnsureThat;
using TennisGame.Players;

namespace TennisGame.Match
{
    public class OpponentsMapping
    {
        public OpponentsMapping(Player player, Player opponent)
        {
            Ensure.That(player, nameof(player)).IsNotNull();
            Ensure.That(opponent, nameof(player)).IsNotNull();

            Player = player;
            Opponent = opponent;
        }

        public Player Player { get; }

        public Player Opponent { get; }
    }
}
