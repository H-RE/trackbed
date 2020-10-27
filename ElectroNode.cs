using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrackBed
{
    class ElectroNode
    {
        Grid MergeGrid;
        public void AddElement(ElectroElement Element)
        {
            //MergeGrid.Merge(Element.ElementGrid);
            MergeGrid.ListGrid.Add(Element.ElementGrid);
        }
    }
    class ElectroElement
    {
        public Grid ElementGrid { get; set; }
    }
    class Line:ElectroElement
    {
        //Mientras se Agrega una linea, Se verifica que no choque con un ElectroNode distinto
        //al que pertenece
        
        Node Fixed, Movil;
        public Line()
        {
            //Se pone la posicion del Movil y el tipo de elemento que la ocupa
            ElementGrid.FillCell(Movil.Position,Movil);

        }
        public void Update()
        {
            //La linea rota respecto al origen de la grilla
            var direction = (Movil.Position - Fixed.Position).normalize();
            ElementGrid.SetDirection(direction);
            //Actualiza las dimensiones de la Grilla
            //Actualiza la posicion de la grilla
            //Actualiza las posiciones afectadas debido al cambio de tamaño y rotación
        }
    }
    class Rectangle:ElectroElement
    {
        //El rectangulo rota respecto al centro de la grilla
    }
}
