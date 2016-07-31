using NUnit.Framework;
using TennisGame.Points;

namespace TennisGame.Tests.Points
{
    /// <summary>
    /// Unit tests for <see cref="Thirty" />
    /// </summary>
    [TestFixture]
    public class ThirtyTests
    {
        [Test]
        public void Name_MapsValueToNameAndToString()
        {
            // Arrange
            uint value = 30;
            var point = new Thirty();

            // Act and assert
            Assert.That(point.Value, Is.EqualTo(value));
            Assert.That(point.Name, Is.EqualTo(value.ToString()));
            Assert.That(point.ToString(), Is.EqualTo(value.ToString()));
        }

        [Test]
        public void NextValue_PointToFifteen()
        {
            // Arrange
            var point = new Thirty();

            // Act and assert
            Assert.That(point.NextPoint, Is.TypeOf<Forty>());
        }

        [Test]
        public void PreviousValue_ThrowsException()
        {
            // Arrange
            var point = new Thirty();

            // Act and assert
            Assert.That(point.PreviousPoint, Is.TypeOf<Fifteeen>());
        }
    }
}
