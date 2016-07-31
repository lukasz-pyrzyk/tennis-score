using TennisGame.Players;

namespace TennisGame.Match
{
    internal class ScoreProcessor : IScoreProcessor
    {
        public bool ProcessGoal(Player player, Player opponent)
        {
            if (player.LastPoint.WinningPoint && player.LastPoint.Value > opponent.LastPoint.Value)
            {
                return true;
            }

            if (opponent.LastPoint.ShoudBeAddedPreviousPoint)
            {
                opponent.AddPreviousPoint();
            }
            else
            {
                player.AddPoint();
            }

            return false;
        }
    }
}
