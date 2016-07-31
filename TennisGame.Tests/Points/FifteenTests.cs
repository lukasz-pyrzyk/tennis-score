using NUnit.Framework;
using TennisGame.Points;

namespace TennisGame.Tests.Points
{
    /// <summary>
    /// Unit tests for <see cref="Fifteeen" />
    /// </summary>
    [TestFixture]
    public class FifteenTests
    {
        [Test]
        public void Name_MapsValueToNameAndToString()
        {
            // Arrange
            uint value = 15;
            var point = new Fifteeen();

            // Act and assert
            Assert.That(point.Value, Is.EqualTo(value));
            Assert.That(point.Name, Is.EqualTo(value.ToString()));
            Assert.That(point.ToString(), Is.EqualTo(value.ToString()));
        }

        [Test]
        public void NextValue_PointToFifteen()
        {
            // Arrange
            var point = new Fifteeen();

            // Act and assert
            Assert.That(point.NextPoint, Is.TypeOf<Thirty>());
        }

        [Test]
        public void PreviousValue_ThrowsException()
        {
            // Arrange
            var point = new Fifteeen();

            // Act and assert
            Assert.That(point.PreviousPoint, Is.TypeOf<Zero>());
        }
    }
}
