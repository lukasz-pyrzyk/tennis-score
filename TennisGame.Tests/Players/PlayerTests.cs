using NUnit.Framework;
using Ploeh.AutoFixture;
using TennisGame.Players;

namespace TennisGame.Tests.Players
{
    /// <summary>
    /// Unit tests for <see cref="Player"/>
    /// </summary>
    [TestFixture]
    public class PlayerTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void Ctor_AddsDefaultPoint()
        {
            // Arrange
            Player player = new Player();

            // Act and assert
            Assert.That(player.PointsCount, Is.EqualTo(1));
        }

        [Test]
        public void Key_CanAssignValue()
        {
            // Arrange
            Player player = new Player();
            char key = _fixture.Create<char>();

            // Act
            player.Key = key;

            // Assert
            Assert.That(player.Key, Is.EqualTo(key));
        }

        [Test]
        public void Name_CanAssignValue()
        {
            // Arrange
            Player player = new Player();
            string name = _fixture.Create<string>();

            // Act
            player.Name = name;

            // Assert
            Assert.That(player.Name, Is.EqualTo(name));
        }

        [Test]
        public void ToString_ReturnsName()
        {
            // Arrange
            Player player = new Player();
            string name = _fixture.Create<string>();

            // Act
            player.Name = name;

            // Assert
            Assert.That(player.ToString(), Is.EqualTo(name));
        }
    }
}
