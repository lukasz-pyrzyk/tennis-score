namespace TennisGame.Points
{
    internal class Fifteeen : Point
    {
        public override uint Value => 15;

        public override string Name => Value.ToString();

        public override Point NextPoint => new Thirty();

        public override Point PreviousPoint => new Zero();
    }
}
