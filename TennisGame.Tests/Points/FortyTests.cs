using NUnit.Framework;
using TennisGame.Points;

namespace TennisGame.Tests.Points
{
    /// <summary>
    /// Unit tests for <see cref="Forty" />
    /// </summary>
    [TestFixture]
    public class FortyTests
    {
        [Test]
        public void Name_MapsValueToNameAndToString()
        {
            // Arrange
            uint value = 40;
            var point = new Forty();

            // Act and assert
            Assert.That(point.Value, Is.EqualTo(value));
            Assert.That(point.Name, Is.EqualTo(value.ToString()));
            Assert.That(point.ToString(), Is.EqualTo(value.ToString()));
        }

        [Test]
        public void WinningPoint_ReturnsTrue()
        {
            // Arrange
            var point = new Forty();

            // Act and assert
            Assert.That(point.WinningPoint, Is.True);
        }

        [Test]
        public void NextValue_PointToFifteen()
        {
            // Arrange
            var point = new Forty();

            // Act and assert
            Assert.That(point.NextPoint, Is.TypeOf<Advantage>());
        }

        [Test]
        public void PreviousValue_ThrowsException()
        {
            // Arrange
            var point = new Forty();

            // Act and assert
            Assert.That(point.PreviousPoint, Is.TypeOf<Thirty>());
        }
    }
}
