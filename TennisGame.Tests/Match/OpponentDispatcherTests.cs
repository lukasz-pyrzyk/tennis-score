using NUnit.Framework;
using Ploeh.AutoFixture;
using TennisGame.Match;
using TennisGame.Players;

namespace TennisGame.Tests.Match
{
    /// <summary>
    /// Unit tests for <see cref="OpponentDispatcher"/>
    /// </summary>
    [TestFixture]
    public class OpponentDispatcherTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        [TestCase((char)123, (char)12312)]
        [TestCase((char)0, (char)12312)]
        public void RegisterCombinations_GetMappingForKey__ReturnsCorrectMappings(char firstKey, char secondKey)
        {
            // Arrange
            Player player = _fixture.Build<Player>().With(x => x.Key, firstKey).Create();
            Player opponent = _fixture.Build<Player>().With(x => x.Key, secondKey).Create();

            // Act
            OpponentDispatcher mappingprovider = new OpponentDispatcher();
            mappingprovider.RegisterCombinations(player, opponent);
            OpponentsMapping mapping = mappingprovider.GetMappingForKey(firstKey);

            // Assert
            Assert.That(mapping.Player, Is.EqualTo(player));
            Assert.That(mapping.Opponent, Is.EqualTo(opponent));
        }

        [Test]
        public void RegisterCombinations_GetMappingForKey_ReturnsNullWhenCannotFindASpecificPlayer()
        {
            // Arrange
            Player player = _fixture.Build<Player>().With(x => x.Key, 0).Create();
            Player opponent = _fixture.Build<Player>().With(x => x.Key, 1).Create();

            // Act
            OpponentDispatcher mappingprovider = new OpponentDispatcher();
            mappingprovider.RegisterCombinations(player, opponent);
            OpponentsMapping mapping = mappingprovider.GetMappingForKey(char.MaxValue);

            // Assert
            Assert.That(mapping, Is.Null);
        }

        [Test]
        public void RegisterCombinations_GetMappingForKey_ThrowsWhenFindTwoPlayersWithSameKey()
        {
            // Arrange
            char key = _fixture.Create<char>();
            Player player = _fixture.Build<Player>().With(x => x.Key, key).Create();
            Player opponent = _fixture.Build<Player>().With(x => x.Key, key).Create();

            // Act
            OpponentDispatcher mappingprovider = new OpponentDispatcher();
            mappingprovider.RegisterCombinations(player, opponent);

            // Assert
            Assert.That(() => mappingprovider.GetMappingForKey(key), Throws.InvalidOperationException);
        }

        [Test]
        public void RegisterCombinations_ThrowsWhenFirstPlayerIsNull()
        {
            // Arrange
            Player player = null;
            Player opponent = _fixture.Create<Player>();

            // Act and assert
            Assert.That(() => new OpponentDispatcher().RegisterCombinations(player, opponent), Throws.ArgumentNullException);
        }

        [Test]
        public void RegisterCombinations_ThrowsWhenSecondPlayerIsNull()
        {
            // Arrange
            Player player = _fixture.Create<Player>();
            Player opponent = null;

            // Act and assert
            Assert.That(() => new OpponentDispatcher().RegisterCombinations(player, opponent), Throws.ArgumentNullException);
        }
    }
}
