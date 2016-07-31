namespace TennisGame.Points
{
    public abstract class Point
    {
        public virtual bool WinningPoint => false;

        public virtual bool ShoudBeAddedPreviousPoint => false;

        public abstract uint Value { get; }

        public abstract string Name { get; }

        public abstract Point NextPoint { get; }

        public abstract Point PreviousPoint { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
