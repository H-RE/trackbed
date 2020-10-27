using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace TrackBed
{
    class Cell
    {
        public int Y { get; set; }
        public int X { get; set; }
        public List<int> Id { get; }

        public Cell(int X, int Y, int Id)
        {
            this.X = X;
            this.Y = Y;
            
            this.Id.Add(Id);
        }
        public void AddIdentifier(int Id)
        {
            this.Id.Add(Id);
        }
        public void RemoveIdentifier(int Id)
        {
            this.Id.Remove(Id);
        }
        public void Rot(int X, int Y, double Angle)
        {
            //usar transformada z o secuencias de coseno para agilizar el procesamiento
            
        }
        public void Tras(int X, int Y)
        {
            this.X += X;
            this.Y += Y;
        }

    }
}
