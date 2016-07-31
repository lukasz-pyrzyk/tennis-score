namespace TennisGame.Points
{
    internal class Thirty : Point
    {
        public override uint Value => 30;

        public override string Name => Value.ToString();

        public override Point NextPoint => new Forty();

        public override Point PreviousPoint => new Fifteeen();
    }
}
