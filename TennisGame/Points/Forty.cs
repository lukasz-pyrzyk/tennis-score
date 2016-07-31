namespace TennisGame.Points
{
    internal class Forty : Point
    {
        public override uint Value => 40;

        public override string Name => Value.ToString();

        public override bool WinningPoint => true;

        public override Point NextPoint => new Advantage();

        public override Point PreviousPoint => new Thirty();
    }
}
