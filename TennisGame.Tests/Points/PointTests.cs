using NUnit.Framework;
using TennisGame.Points;

namespace TennisGame.Tests.Points
{
    /// <summary>
    /// Unit tests for <see cref="Point" />
    /// </summary>
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void Point_HasCorrectDefaultValue()
        {
            // Arrange
            var point = new FakeTests();

            // Act and assert
            Assert.That(point.WinningPoint, Is.False);
            Assert.That(point.ShoudBeAddedPreviousPoint, Is.False);
        }

        internal class FakeTests : Point
        {
            public override uint Value { get; }

            public override string Name { get; }

            public override Point NextPoint { get; }

            public override Point PreviousPoint { get; }
        }
    }
}
