using System.Dynamic;
using System.Windows;

namespace TrackBed
{
    class BoundingRectangle
    {
        public double Xmin { get; private set; }
        public double Xmax { get; private set; }
        public double Ymin { get; private set; }
        public double Ymax { get; private set; }
        private Point []Corners { get; set; }
        public BoundingRectangle()
        {
            Corners = new Point[4];
        }
        public void UpdateRange()
        {
            Xmin = Corners[0].X;
            Xmax = Corners[0].X;
            Ymin = Corners[0].Y;
            Ymax = Corners[0].Y;

           
        }
       
        public bool PointInRange(Point point)
        {
            return (point.X >= Xmin) && (point.X <= Xmax) && (point.Y >= Ymin) && (point.Y <= Ymax);
        }
        private void line(Point pointA, Point pointB)
        {
            var dif = pointB - pointA;
            dif.X / dif.Y;
        }
        public bool Intersects(BoundingRectangle Rectangle)
        {
            for(int i = 0; i<4; i++)
            {
                if(PointInRange(Rectangle.Corners[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }

    class BoundingCircle
    {
        public double Ratio { get; set; }
        public Point Position { get; set; }
        
        public bool Intersects(BoundingCircle Circle)
        {
            var Dist = Circle.Position - Position;
            return Dist.Length <= Ratio + Circle.Ratio;
        }
        public bool PointInRange(Point point)
        {
            var Dis = point - Position;
            return Dis.Length <= Ratio;
        }
    }
}
