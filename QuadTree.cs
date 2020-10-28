using System;
using System.Windows;

namespace TrackBed
{
    class QuadTree
    {
        //Hacer que las celdas sean moviles para que se desplazen rápido
        QuadTree []child;
        readonly double Lead;
        Square Dimensions;
        public Fill fill { get; private set; }

        public QuadTree(Square Region,double lead)
        {
            child = new QuadTree[4];
            Dimensions = Region;
            Lead = lead;
            //Box = box;
            child[0] = null;
            child[1] = null;
            child[2] = null;
            child[3] = null;
        }
        public bool AddCell(Cell cell)//Regresa true si todo el arbol es negro
        {
            //Si hay en toda la region partela en 4 y metete a cada region
            if (Dimensions.InRange(cell))
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
                    else { fill = Fill.Gray; }

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
                Array.Clear(child, 0, 4);
            }
            return false;
        }
        
        public bool IsFilled(Cell cell)
        {
            if (Dimensions.InRange(cell))//Verifica si el punto se encuentra en ese cuadrante
            {
                if (fill == Fill.White) return false;
                if (fill == Fill.Gray)
                {
                    //Optimizar con cell-center.X>0 .Y>0 -> i=0;  X<0 Y>0 -> i=1; ...
                    //Detecta si sale del rango?
                    for (int i = 0; i < 4; i++)
                    {
                        if( child[i].IsFilled(cell))
                        {
                            return true;
                        }
                    }
                }
                if (fill == Fill.Black) return true;
            }
            return false;
        }
    }
    class Square 
    {
        //ACTUALIZAR PARA EVITAR REDONDEOS Y SEA LA POSICION DESEADA
        public Point Center { get; set; }
        public double Length { get; private set; }
        public double Lead { get; set; }
        private readonly int Power;

        public bool InRange(Cell cell)//Busca en toda la region de este arbol
        {
            var disX = Math.Abs(cell.X - Center.X);
            var disY = Math.Abs(cell.Y - Center.Y);
            var HalfLength = Length / 2;
            bool XinRange = disX < HalfLength;
            bool YinRange = disY < HalfLength;
            return XinRange && YinRange;
        }

        public Square GetQuadrant(int iQuad)
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
            return new Square(Qcenter, Power - 1, Lead); //Se puede optimizar si ya se pasara Length en potencia de 2
        }
        public double GetHalfLength()
        {
            return Length / 2;
        }

        //Se puede optimizar si ya se pasara Length en potencia de 2
        public Square(Point center, int Power, double Lead)
        {
            this.Lead = Lead;
            Center = center;
            this.Power = Power;
            var Units = 1;//Number of rectangles
            for(int i=0; i<Power; i++)
            {
                Units *= 2;
            }
            Length = Lead * Units;
        }
    }
    enum Fill { Black, Gray, White }
}