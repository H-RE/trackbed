using System;
using System.Windows;

namespace TrackBed
{
    class QuadTree
    {
        //Hacer que las celdas sean moviles para que se desplazen rápido
        QuadTree []child;
        readonly double Lead;
        DiscreteSquare Dimensions;
        public Fill fill { get; private set; }

        public QuadTree(DiscreteSquare Region,double lead)
        {
            child = new QuadTree[4];
            Dimensions = Region;
            Lead = lead;
            //Box = box;
        }
        public bool AddCell(Cell cell)//Regresa true si todo el arbol es negro
        {
            //Si hay en toda la region partela en 4 y metete a cada region
            if (CellInRange(cell))
            {
                if(Dimensions.Length>Lead)
                {
                    bool BlackTree = true;//Sirve para revisar que todos los cuadrantes sean negros
                    for (int i = 0; i < 4; i++)
                    {
                        var Region = Dimensions.GetQuadrant(i);
                        child[i] = new QuadTree(Region, Lead);
                        
                        BlackTree= child[i].AddCell(cell) && BlackTree;
                    }
                    //Si no se completo el Quadtree llenar este arbol con gris, si se completo llenar con blanco
                    if (BlackTree)
                    {
                        fill = Fill.Black;
                        Array.Clear(child, 0, 4);
                    }
                    else fill = Fill.Gray;

                    return BlackTree;
                }
                else
                {   //Si se encontro algo en el cuadrante y se alcanzó la longitud 
                    //minima, llenar con negro
                    fill = Fill.Black;
                    return true;
                }
            }
            else
            {
                //Si no hay nada entonces llenar con blanco toda la region
                fill = Fill.White;
            }
            return false;
        }
        public bool CellInRange(Cell cell)//Busca en toda la region de este arbol
        { 
            var x = 54;//Pasar la posicion de la celda
            var y = 21;
            var disX = Math.Abs(x - Dimensions.Center.X);
            var disY = Math.Abs(y - Dimensions.Center.Y);
            bool XinRange = disX < Dimensions.GetHalfLength();//Optimizar esto
            bool YinRange = disY < Dimensions.GetHalfLength();
            return XinRange && YinRange;
        }
        public bool Find(Cell cell)
        {

            return false;
        }
    }

    class DiscreteSquare
    {
        public Point Center { get; set; }
        public int Length { get; set; }
        //public double Lead { get; set; }
        public double Xmin { get; set; }
        public double Xmax { get; set; }
        public double Ymin { get; set; }
        public double Ymax { get; set; }
        
        public DiscreteSquare GetQuadrant(int iQuad)
        {
            var Qcenter = new Point();
            var QLength = Length / 4;
            
            switch (iQuad)
            {
                case 1:
                    Qcenter.X = Center.X + QLength;
                    Qcenter.Y = Center.Y + QLength;
                    break;
                case 2:
                    Qcenter.X = Center.X - QLength;
                    Qcenter.Y = Center.Y + QLength;
                    break;
                case 3:
                    Qcenter.X = Center.X - QLength;
                    Qcenter.Y = Center.Y - QLength;
                    break;
                case 4:
                    Qcenter.X = Center.X + QLength;
                    Qcenter.Y = Center.Y - QLength;
                    break;
            };
            return new DiscreteSquare(Qcenter, Length / 2);
        }
        public int GetHalfLength()
        {
            return Length / 2;
        }
        public DiscreteSquare(Point center, int length)
        {
            Center = center;
            Length = length;
        }
    }
    enum Fill { Black, Gray, White }
}