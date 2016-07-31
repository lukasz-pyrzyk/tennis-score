using System;

namespace TennisGame.Points
{
    internal class Advantage : Point
    {
        public override uint Value => 50;

        public override string Name => "A";

        public override bool WinningPoint => true;

        public override bool ShoudBeAddedPreviousPoint => true;

        public override Point NextPoint
        {
            get { throw new InvalidOperationException("Advantage point does not have next point"); }
        }

        public override Point PreviousPoint => new Forty();
    }
}
