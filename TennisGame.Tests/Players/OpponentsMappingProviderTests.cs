using NUnit.Framework;
using Ploeh.AutoFixture;
using TennisGame.Players;

namespace TennisGame.Tests.Players
{
    /// <summary>
    /// Unit tests for <see cref="OpponentsMappingProvider"/>
    /// </summary>
    [TestFixture]
    public class OpponentsMappingProviderTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        [TestCase((char)123, (char)12312)]
        [TestCase((char)0, (char)12312)]
        public void Ctor_GetMappingForKey__ReturnsCorrectMappings(char firstKey, char secondKey)
        {
            // Arrange
            Player player = _fixture.Build<Player>().With(x => x.Key, firstKey).Create();
            Player opponent = _fixture.Build<Player>().With(x => x.Key, secondKey).Create();

            // Act
            OpponentsMappingProvider mappingprovider = new OpponentsMappingProvider(player, opponent);
            OpponentsMapping mapping = mappingprovider.GetMappingForKey(firstKey);

            // Assert
            Assert.That(mapping.Player, Is.EqualTo(player));
            Assert.That(mapping.Opponent, Is.EqualTo(opponent));
        }

        [Test]
        public void Ctor_GetMappingForKey_ReturnsNullWhenCannotFindASpecificPlayer()
        {
            // Arrange
            Player player = _fixture.Build<Player>().With(x => x.Key, 0).Create();
            Player opponent = _fixture.Build<Player>().With(x => x.Key, 0).Create();

            // Act
            OpponentsMappingProvider mappingprovider = new OpponentsMappingProvider(player, opponent);
            OpponentsMapping mapping = mappingprovider.GetMappingForKey(char.MaxValue);

            // Assert
            Assert.That(mapping, Is.Null);
        }

        [Test]
        public void Ctor_GetMappingForKey_ThrowsWhenFindTwoPlayersWithSameKey()
        {
            // Arrange
            char key = _fixture.Create<char>();
            Player player = _fixture.Build<Player>().With(x => x.Key, key).Create();
            Player opponent = _fixture.Build<Player>().With(x => x.Key, key).Create();

            // Act
            OpponentsMappingProvider mappingprovider = new OpponentsMappingProvider(player, opponent);

            // Assert
            Assert.That(() => mappingprovider.GetMappingForKey(key), Throws.InvalidOperationException);
        }

        [Test]
        public void Ctor_ThrowsWhenFirstPlayerIsNull()
        {
            // Arrange
            Player player = null;
            Player opponent = _fixture.Create<Player>();

            // Act and assert
            Assert.That(() => new OpponentsMappingProvider(player, opponent), Throws.ArgumentNullException);
        }

        [Test]
        public void Ctor_ThrowsWhenSecondPlayerIsNull()
        {
            // Arrange
            Player player = _fixture.Create<Player>();
            Player opponent = null;

            // Act and assert
            Assert.That(() => new OpponentsMappingProvider(player, opponent), Throws.ArgumentNullException);
        }
    }
}
