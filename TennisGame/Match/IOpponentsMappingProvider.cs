using TennisGame.Players;

namespace TennisGame.Match
{
    internal interface IOpponentsMappingProvider
    {
        OpponentsMapping GetMappingForKey(char key);
    }
}
