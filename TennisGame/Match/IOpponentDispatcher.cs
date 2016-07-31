using TennisGame.Players;

namespace TennisGame.Match
{
    public interface IOpponentDispatcher
    {
        void RegisterCombinations(Player firstPlayer, Player secondPlayer);
        OpponentsMapping GetMappingForKey(char key);
    }
}
