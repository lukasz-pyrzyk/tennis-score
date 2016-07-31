using System;

namespace TennisGame.Points
{
    internal class Zero : Point
    {
        public override uint Value => 0;

        public override string Name => Value.ToString();

        public override Point NextPoint => new Fifteeen();

        public override Point PreviousPoint
        {
            get { throw new InvalidOperationException("Zero point does not have previous point"); }
        }
    }
}
