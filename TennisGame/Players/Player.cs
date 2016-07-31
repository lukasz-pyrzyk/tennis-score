using System.Collections.Generic;
using TennisGame.Points;

namespace TennisGame.Players
{
    public class Player
    {
        public Player()
        {
            _points.AddLast(new Zero());
        }

        public int PointsCount => _points.Count;

        public Point LastPoint => _points.Last.Value;

        public virtual char Key { get; set; }

        public virtual string Name { get; set; }

        protected LinkedList<Point> _points { get; } = new LinkedList<Point>();

        public void AddPoint()
        {
            Point nextPoint = LastPoint.NextPoint;

            AddPoint(nextPoint);
        }

        public void AddPoint(Point point)
        {
            if (point != null)
            {
                _points.AddLast(point);
            }
        }

        public void AddPreviousPoint()
        {
            Point nextPoint = LastPoint.PreviousPoint;

            if (nextPoint != null)
            {
                _points.AddLast(nextPoint);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
