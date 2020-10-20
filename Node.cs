using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using SharpDX.Direct2D1;

namespace TrackBed
{
    class Node:Component3D
    {
        Vector2 Location;
        public Node(Vector3 Position)
        {
            Location = new Vector2(Position.X, Position.Y);

            var builder = new MeshGeometry3D();
            float radio = 0.2f;
            int iteraciones = 100;
            
            var Perigonal = 2 * Math.PI;
            double incremento = Perigonal / iteraciones;
            builder.Positions = new Vector3Collection();
            builder.Normals = new Vector3Collection();
            builder.Indices = new IntCollection();
            builder.Positions.Add(Position);//agrega el centro
            builder.Normals.Add(new Vector3(0, 0, 1));
            for (double angle=0; angle<=Perigonal; angle+=incremento)
            {
                var position = new Vector3(
                        Position.X + radio*Convert.ToSingle(Math.Cos(angle)),
                        Position.Y + radio*Convert.ToSingle(Math.Sin(angle)),
                        Position.Z);
                builder.Positions.Add(position);
                builder.Normals.Add(new Vector3(0, 0, 1));
            }
            int p = 1;
            for(int i=0; p<builder.Positions.Count-1;i+=3)
            {
                builder.Indices.Add(0);
                
                for(int j=p;j<=p+1;j++)
                {
                    builder.Indices.Add(j);
                }
                p++;
            }
            //borrar-----------
            foreach(var str in builder.Indices)
            {
                Console.WriteLine(str.ToString());
            }
            Console.WriteLine(builder.Positions.Count.ToString());
            //borrar----------

            Model = new MeshGeometryModel3D();
            Model.Geometry = builder;
            Model.Material = PhongMaterials.White;
            Model.Geometry.IsDynamic = false;
            
        }
    }
}
