using System.Collections.Generic;
using System.Windows;

namespace TrackBed
{
    class Grid
    {
        public List<Grid> ListGrid { get; set; }
        //List<Vector> Positions;
        private Vector PositionOnBase;
        LinkedList<LinkedList<Cell>> Sections;
        private double Lead;
        private Point Position;
        public double RelativeAngleRotation { get; }
        public double AngleRotation { get; }
        public Grid(double Lead, Point Position)
        {
            this.Lead = Lead;
            this.Position = Position;
            Sections = new LinkedList<LinkedList<Cell>>();
        }
        public Grid(Grid Base, Point Position)
        {
            Lead = Base.Lead;
            this.Position = Position;
            PositionOnBase = Position - Base.Position;
        }
        public void AddGrid(Point Position)
        {
            var NewGrid = new Grid(this, Position);
            ListGrid.Add(NewGrid);
        }
        private Cell ValueToCell(Point Point)
        {
            var temp = new Cell();
            var res = (Point - Position) / Lead;
            temp.X = (int)(res.X + 0.5);
            temp.Y = (int)(res.Y + 0.5);
            return temp;
        }
        public void FillCell(Cell cell)
        {

        }
        
        public void SetDirection(Vector direction)//Pasar la direccion ya normalizada como argumento
        {
            //Verificar que la grilla no esté fija
            
            foreach(var cell in Positions)
            {
                cell.X = cell.X * direction.X - cell.Y * direction.Y;
                cell.Y = cell.Y * direction.X + cell.X * direction.Y;
            }
            
            
        }
        public bool ShiftXColumn(double position, double distance)
        {   //Recorre la posicion de un punto una distancia especificada
            //en la dirección X de la grilla, Agrega o quita columnas 

            //var pointer = Find puntero columna
            //if(no hay algo en la posicion) return false;
            
            return true;
        }
        public int GetQadTree()
        {
            
            return 0;
        }
       
        public void RotOnBase()
        {//Rota en torno al origen de la base

        }
        public Cell FindCell(int x, int y)
        {
            return null;
        }
        public Cell FindItem()
        {
            return null;
        }
        public void Move(double X, double Y)
        {
            PositionOnBase.X += X;
            PositionOnBase.Y += Y;
        }
    }
    
}
