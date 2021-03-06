﻿using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TennisGame.Match;
using TennisGame.Players;

namespace TennisGame.Tests.Match
{
    /// <summary>
    /// Unit tests for <see cref="TennisMatch"/>
    /// </summary>
    [TestFixture]
    public class TennisMatchTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void IsStarted_IsDefaultFalse()
        {
            // Arrange
            var tennisMatch = new TennisMatch(_fixture.Create<Player>(), _fixture.Create<Player>());

            // Act and assert
            Assert.That(tennisMatch.IsStarted, Is.False);
        }

        [Test]
        public void Ctor_AssignsPlayers()
        {
            // Arrange
            Player firstPlayer = _fixture.Create<Player>();
            Player secondPlayer = _fixture.Create<Player>();

            // Act
            var tennisMatch = new TennisMatch(firstPlayer, secondPlayer);

            // Assert
            Assert.That(tennisMatch.FirstPlayer, Is.EqualTo(firstPlayer));
            Assert.That(tennisMatch.SecondPlayer, Is.EqualTo(secondPlayer));
        }

        [Test]
        public void Start_StartsMatch()
        {
            // Arrange
            var tennisMatch = new TennisMatch(_fixture.Create<Player>(), _fixture.Create<Player>());

            // Act
            tennisMatch.Start();

            // Assert
            Assert.That(tennisMatch.IsStarted, Is.True);
        }

        [Test]
        public void Start_ProcessPoint_ForServer()
        {
            // Arrange
            char key = '1';
            var tennisMatch = new TennisMatch(_fixture.Create<Player>(), _fixture.Create<Player>());

            // Act
            tennisMatch.ProcessPoint(key);

            // Assert
            Assert.That(tennisMatch.FirstPlayer.PointsCount, Is.EqualTo(1));
        }

        [Test]
        public void Start_ProcessPoint_ForReceiver()
        {
            // Arrange
            char key = '2';
            var tennisMatch = new TennisMatch(_fixture.Create<Player>(), _fixture.Create<Player>());

            // Act
            tennisMatch.ProcessPoint(key);

            // Assert
            Assert.That(tennisMatch.SecondPlayer.PointsCount, Is.EqualTo(1));
        }

        [Test]
        public void ProcessPoint_ProcessPointForFirstPlayer()
        {
            // Arrange
            Player firstPlayer = _fixture.Create<Player>();
            Player secondPlayer = _fixture.Create<Player>();
            IScoreProcessor processor = Substitute.For<IScoreProcessor>();
            IOpponentDispatcher dispatcher = Substitute.For<IOpponentDispatcher>();
            dispatcher.GetMappingForKey(firstPlayer.Key).Returns(new OpponentsMapping(firstPlayer, secondPlayer));

            // Act
            TennisMatch match = new TennisMatch(firstPlayer, secondPlayer, processor, dispatcher);
            match.ProcessPoint(firstPlayer.Key);

            // Assert
            processor.Received(1).ProcessGoal(firstPlayer, secondPlayer);
        }

        [Test]
        public void ProcessPoint_ProcessPointForSecondPlayer()
        {
            // Arrange
            Player firstPlayer = _fixture.Create<Player>();
            Player secondPlayer = _fixture.Create<Player>();
            IScoreProcessor processor = Substitute.For<IScoreProcessor>();
            IOpponentDispatcher dispatcher = Substitute.For<IOpponentDispatcher>();
            dispatcher.GetMappingForKey(secondPlayer.Key).Returns(new OpponentsMapping(secondPlayer, firstPlayer));

            // Act
            TennisMatch match = new TennisMatch(firstPlayer, secondPlayer, processor, dispatcher);
            match.ProcessPoint(secondPlayer.Key);

            // Assert
            processor.Received(1).ProcessGoal(secondPlayer, firstPlayer);
        }

        [Test]
        public void ProcessPoint_StopsMatchAndCallsEvent()
        {
            // Arrange
            Player firstPlayer = _fixture.Create<Player>();
            Player secondPlayer = _fixture.Create<Player>();
            IScoreProcessor processor = Substitute.For<IScoreProcessor>();
            processor.ProcessGoal(firstPlayer, secondPlayer).Returns(true);
            IOpponentDispatcher dispatcher = Substitute.For<IOpponentDispatcher>();
            dispatcher.GetMappingForKey(Arg.Any<char>()).Returns(new OpponentsMapping(firstPlayer, secondPlayer));

            bool eventRaised = false;

            // Act
            TennisMatch match = new TennisMatch(firstPlayer, secondPlayer, processor, dispatcher);
            match.OnFinish += (sender, args) => eventRaised = true;
            match.ProcessPoint(firstPlayer.Key);

            // Assert
            Assert.That(match.IsStarted, Is.False);
            Assert.That(eventRaised, Is.True);
        }
    }
}
