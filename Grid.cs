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
        
        public void SetDirection(Point Pmovil)//Pasar la direccion ya normalizada como argumento
        {
            //Verificar que la grilla no esté fija
            var Dif = Pmovil - Position;
            Dif.Normalize();
            foreach(var cell in Positions)
            {
                cell.X = cell.X * Pmovil.X - cell.Y * Pmovil.Y;
                cell.Y = cell.Y * Pmovil.X + cell.X * Pmovil.Y;
            }
        }
        public void ShiftXColumn(double position, double distance)
        {   //Recorre la posicion de un punto una distancia especificada
            //en la dirección X de la grilla

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
