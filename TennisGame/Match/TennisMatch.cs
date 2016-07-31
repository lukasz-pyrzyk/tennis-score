using System;
using TennisGame.Players;

namespace TennisGame.Match
{
    internal class TennisMatch
    {
        private readonly IScoreProcessor _scoreProcessor;
        private readonly IOpponentsMappingProvider _opponents;

        public TennisMatch(Player firstPlayer, Player secondPlayer) :
            this(firstPlayer, secondPlayer, new ScoreProcessor())
        {
        }

        internal TennisMatch(Player firstPlayer, Player secondPlayer, IScoreProcessor processor)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;

            _opponents = new OpponentsMappingProvider(firstPlayer, secondPlayer);
            _scoreProcessor = processor;
        }

        public bool IsStarted { get; private set; }

        public Player FirstPlayer { get; }

        public Player SecondPlayer { get; }

        public EventHandler<MatchFinishedArgs> OnFinish { get; set; }

        public void Start()
        {
            IsStarted = true;
        }

        public void ProcessPoint(char userKey)
        {
            OpponentsMapping opponentsMapping = _opponents.GetMappingForKey(userKey);

            if (opponentsMapping != null)
            {
                ProcessGoal(opponentsMapping.Player, opponentsMapping.Opponent);
            }
        }

        private void ProcessGoal(Player player, Player opponent)
        {
            if (_scoreProcessor.ProcessGoal(player, opponent))
            {
                IsStarted = false;
                OnFinish?.Invoke(this, new MatchFinishedArgs(player));
            }
        }
    }
}
