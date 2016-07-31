using NUnit.Framework;
using TennisGame.Players;

namespace TennisGame.Tests.Players
{
    /// <summary>
    /// Unit tests for <see cref="Server"/>
    /// </summary>
    [TestFixture]
    public class ServerTests
    {
        [Test]
        public void KeyNumber_HasACorrectValue()
        {
            // Arrange
            char expectedNumber = '1';
            Server user = new Server();

            // Act and assert
            Assert.That(user.Key, Is.EqualTo(expectedNumber));
        }

        [Test]
        public void Name_HasACorrectValue()
        {
            // Arrange
            Server user = new Server();

            // Act and assert
            Assert.That(user.Name, Is.EqualTo(nameof(Server)));
        }
    }
}
