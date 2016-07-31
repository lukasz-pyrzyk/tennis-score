using System;
using TennisGame.Players;

namespace TennisGame.Match
{
    internal class TennisMatch
    {
        private readonly IScoreProcessor _scoreProcessor;
        private readonly IOpponentDispatcher _opponentDispatcher;

        public TennisMatch(Player firstPlayer, Player secondPlayer) :
            this(firstPlayer, secondPlayer, new ScoreProcessor(), new OpponentDispatcher())
        {
        }

        internal TennisMatch(Player firstPlayer, Player secondPlayer, IScoreProcessor processor, IOpponentDispatcher dispatcher)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;

            _scoreProcessor = processor;
            _opponentDispatcher = dispatcher;

            _opponentDispatcher.RegisterCombinations(firstPlayer, secondPlayer);
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
            OpponentsMapping opponentsMapping = _opponentDispatcher.GetMappingForKey(userKey);

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
