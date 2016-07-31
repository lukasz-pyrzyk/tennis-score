using System;
using NUnit.Framework;
using TennisGame.Points;

namespace TennisGame.Tests.Points
{
    /// <summary>
    /// Unit tests for <see cref="Zero"/>
    /// </summary>
    [TestFixture]
    public class ZeroTests
    {
        [Test]
        public void Name_MapsValueToNameAndToString()
        {
            // Arrange
            uint value = 0;
            var point = new Zero();

            // Act and assert
            Assert.That(point.Value, Is.EqualTo(value));
            Assert.That(point.Name, Is.EqualTo(value.ToString()));
            Assert.That(point.ToString(), Is.EqualTo(value.ToString()));
        }

        [Test]
        public void NextValue_PointToFifteen()
        {
            // Arrange
            var point = new Zero();

            // Act and assert
            Assert.That(point.NextPoint, Is.TypeOf<Fifteeen>());
        }

        [Test]
        public void PreviousValue_ThrowsException()
        {
            // Arrange
            var point = new Zero();

            // Act and assert
            Assert.That(() => point.PreviousPoint, Throws.TypeOf<InvalidOperationException>());
        }
    }
}
