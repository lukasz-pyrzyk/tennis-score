using NUnit.Framework;
using Ploeh.AutoFixture;
using TennisGame.Players;

namespace TennisGame.Tests.Players
{
    /// <summary>
    /// Unit tests for <see cref="OpponentsMapping"/>
    /// </summary>
    [TestFixture]
    public class OpponentsMappingTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void Ctor_AssignsPlayers()
        {
            // Arrange
            Player player = _fixture.Create<Player>();
            Player opponent = _fixture.Create<Player>();

            // Act
            OpponentsMapping mapping = new OpponentsMapping(player, opponent);

            // Assert
            Assert.That(mapping.Player, Is.EqualTo(player));
            Assert.That(mapping.Opponent, Is.EqualTo(opponent));
        }

        [Test]
        public void Ctor_ThrowsWhenPlayerIsNull()
        {
            // Arrange
            Player player = null;
            Player opponent = _fixture.Create<Player>();

            // Act and assert
            Assert.That(() => new OpponentsMapping(player, opponent), Throws.ArgumentNullException);
        }

        [Test]
        public void Ctor_ThrowsWhenOpponentIsNull()
        {
            // Arrange
            Player player = _fixture.Create<Player>();
            Player opponent = null;

            // Act and assert
            Assert.That(() => new OpponentsMapping(player, opponent), Throws.ArgumentNullException);
        }
    }
}
