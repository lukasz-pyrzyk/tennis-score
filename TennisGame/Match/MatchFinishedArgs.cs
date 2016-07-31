using System;
using TennisGame.Players;

namespace TennisGame.Match
{
    internal class MatchFinishedArgs : EventArgs
    {
        public MatchFinishedArgs(Player player)
        {
            Player = player;
        }

        public Player Player { get; }
    }
}
