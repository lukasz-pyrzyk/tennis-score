using System;
using NUnit.Framework;
using TennisGame.Points;

namespace TennisGame.Tests.Points
{
    /// <summary>
    /// Unit tests for <see cref="Advantage" />
    /// </summary>
    [TestFixture]
    public class AdvantageTests
    {
        [Test]
        public void Name_MapsValueToNameAndToString()
        {
            // Arrange
            uint value = 50;
            var point = new Advantage();

            // Act and assert
            Assert.That(point.Value, Is.EqualTo(value));
            Assert.That(point.Name, Is.EqualTo("A"));
            Assert.That(point.ToString(), Is.EqualTo("A"));
        }

        [Test]
        public void WinningPoint_ReturnsTrue()
        {
            // Arrange
            var point = new Advantage();

            // Act and assert
            Assert.That(point.WinningPoint, Is.True);
        }

        [Test]
        public void ShoudBeAddedPreviousPoint_ReturnsTrue()
        {
            // Arrange
            var point = new Advantage();

            // Act and assert
            Assert.That(point.ShoudBeAddedPreviousPoint, Is.True);
        }

        [Test]
        public void NextValue_PointToFifteen()
        {
            // Arrange
            var point = new Advantage();

            // Act and assert
            Assert.That(() => point.NextPoint, Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void PreviousValue_ThrowsException()
        {
            // Arrange
            var point = new Advantage();

            // Act and assert
            Assert.That(point.PreviousPoint, Is.TypeOf<Forty>());
        }
    }
}
