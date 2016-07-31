using NUnit.Framework;
using TennisGame.Match;
using TennisGame.Players;
using TennisGame.Points;

namespace TennisGame.Tests.Match
{
    /// <summary>
    /// Unit tests for <see cref="ScoreProcessor"/>
    /// </summary>
    [TestFixture]
    public class ScoreProcessorTests
    {
        [Test]
        public void ProcessGoal_ReturnsFalseAndAddsPointToTheFirstPlayer()
        {
            // Arrange
            var firstPlayer = new Server();
            var secondPlayer = new Receiver();
            int currentPoints = firstPlayer.PointsCount;
            ScoreProcessor processor = new ScoreProcessor();

            // Act
            bool results = processor.ProcessGoal(firstPlayer, secondPlayer);

            // Assert
            Assert.That(results, Is.False);
            Assert.That(firstPlayer.PointsCount, Is.EqualTo(currentPoints + 1));
        }

        [Test]
        public void ProcessGoal_ReturnsFalseAndAddsPreviousPointToTheSecondPlayer()
        {
            // Arrange
            var firstPlayer = new Server();
            var secondPlayer = new Receiver();
            var fakePoint = new PreviousFakePoint();
            secondPlayer.AddPoint(fakePoint);
            int firstPlayerPoints = firstPlayer.PointsCount;
            int secondPlayerPoints = secondPlayer.PointsCount;
            Point currentPoint = secondPlayer.LastPoint;

            ScoreProcessor processor = new ScoreProcessor();

            // Act
            bool results = processor.ProcessGoal(firstPlayer, secondPlayer);

            // Assert
            Assert.That(results, Is.False);
            Assert.That(firstPlayer.PointsCount, Is.EqualTo(firstPlayerPoints));
            Assert.That(secondPlayer.PointsCount, Is.EqualTo(secondPlayerPoints + 1));
            Assert.That(secondPlayer.LastPoint, Is.Not.EqualTo(currentPoint));
        }

        [Test]
        public void ProcessGoal_ReturnsTrueWhenPointIsWinningAndHasBiggerValue()
        {
            // Arrange
            var firstPlayer = new Server();
            var secondPlayer = new Receiver();
            firstPlayer.AddPoint(new WinningFakePoint());
            int firstPlayerPoints = firstPlayer.PointsCount;
            int secondPlayerPoints = secondPlayer.PointsCount;

            ScoreProcessor processor = new ScoreProcessor();

            // Act
            bool results = processor.ProcessGoal(firstPlayer, secondPlayer);

            // Assert
            Assert.That(results, Is.True);
            Assert.That(firstPlayer.PointsCount, Is.EqualTo(firstPlayerPoints));
            Assert.That(secondPlayer.PointsCount, Is.EqualTo(secondPlayerPoints));
        }

        private class PreviousFakePoint : Point
        {
            public override uint Value => 0;

            public override string Name => Value.ToString();

            public override bool ShoudBeAddedPreviousPoint => true;

            public override Point NextPoint => null;

            public override Point PreviousPoint => new PreviousFakePoint();
        }

        private class WinningFakePoint : Point
        {
            public override uint Value => 50;

            public override string Name => Value.ToString();

            public override bool WinningPoint => true;

            public override Point NextPoint => null;

            public override Point PreviousPoint => null;
        }
    }
}
