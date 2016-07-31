using TennisGame.Players;

namespace TennisGame.Match
{
    public interface IScoreProcessor
    {
        bool ProcessGoal(Player player, Player opponent);
    }
}
