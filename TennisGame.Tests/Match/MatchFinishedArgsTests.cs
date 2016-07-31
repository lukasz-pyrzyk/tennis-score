using NUnit.Framework;
using Ploeh.AutoFixture;
using TennisGame.Match;
using TennisGame.Players;

namespace TennisGame.Tests.Match
{
    /// <summary>
    /// Unit tests for <see cref="MatchFinishedArgs"/>
    /// </summary>
    [TestFixture]
    public class MatchFinishedArgsTests
    {
        private readonly Fixture _fiture = new Fixture();

        [Test]
        public void Ctor_AssingsPlayer()
        {
            // Arrange
            Player player = _fiture.Create<Player>();

            // Act
            MatchFinishedArgs args = new MatchFinishedArgs(player);

            // Assert
            Assert.That(args.Player, Is.EqualTo(player));
        }
    }
}
