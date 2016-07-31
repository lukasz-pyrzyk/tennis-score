using System.Linq;
using EnsureThat;
using TennisGame.Match;

namespace TennisGame.Players
{
    internal class OpponentsMappingProvider : IOpponentsMappingProvider
    {
        private readonly OpponentsMapping[] _opponentsMapping = new OpponentsMapping[2];

        public OpponentsMappingProvider(Player firstPlayer, Player secondPlayer)
        {
            Ensure.That(firstPlayer, nameof(firstPlayer)).IsNotNull();
            Ensure.That(secondPlayer, nameof(secondPlayer)).IsNotNull();

            _opponentsMapping[0] = new OpponentsMapping(firstPlayer, secondPlayer);
            _opponentsMapping[1] = new OpponentsMapping(secondPlayer, firstPlayer);
        }

        public OpponentsMapping GetMappingForKey(char key)
        {
            return _opponentsMapping.SingleOrDefault(x => x.Player.Key == key);
        }
    }
}
