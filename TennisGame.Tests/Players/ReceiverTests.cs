using NUnit.Framework;
using TennisGame.Players;

namespace TennisGame.Tests.Players
{
    /// <summary>
    /// Unit tests for <see cref="Receiver"/>
    /// </summary>
    [TestFixture]
    public class ReceiverTests
    {
        [Test]
        public void KeyNumber_HasACorrectValue()
        {
            // Arrange
            char expectedNumber = '2';
            Receiver user = new Receiver();

            // Act and assert
            Assert.That(user.Key, Is.EqualTo(expectedNumber));
        }

        [Test]
        public void Name_HasACorrectValue()
        {
            // Arrange
            Receiver user = new Receiver();

            // Act and assert
            Assert.That(user.Name, Is.EqualTo(nameof(Receiver)));
        }
    }
}
