﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TrackBed
{
    //POSIBLEMENTE ESTA CLASE PUEDE HEREDAR DEL MODELGROUP3D PARA PODER OCULTAR Y MOSTRAR TODOS
    //LOS ELEMENTOS Y PODER HACER UNA COPIA DE TODO EL PLANO CON ELEMENTOS
    //SI NO POS HAZ UNA CLASE

    //HACER UNA PROPIEDAD DE DEPENDENCIA PARA LA PROFUNDIDAD DEL PLANO
    class Plane2D
    {
        //Agregar la posicion del elemento donde se encuentra actualmente dentro del plano
        //Tal vez sea bueno que cada elemento tenga su traslación registrada
        List<Element3D> Items = new List<Element3D>();//hacer una clase aparte
        MeshGeometryModel3D plano = new MeshGeometryModel3D();
        protected Viewport3DX viewport;
        public float Length;
        public Plane2D(Viewport3DX Viewport, float Length=5f)
        {
            var material = new PhongMaterial();
            material.DiffuseColor = new Color4(1f, 1f, 0, 0.5f);

            viewport = Viewport;
            this.Length = Length;
            var meshbuilder = new MeshBuilder();
            var sd2 = Length / 2;
            meshbuilder.AddQuad(
                new Vector3(-sd2, sd2, 0),
                new Vector3(-sd2, -sd2, 0),
                new Vector3(sd2, -sd2, 0),
                new Vector3(sd2, sd2, 0)
                );
            //meshbuilder.AddFacePZ();
            plano.Geometry = meshbuilder.ToMeshGeometry3D();
            plano.Geometry.IsDynamic = false;
            plano.Material = material;
            plano.IsTransparent = true;
            viewport.Items.Add(plano);
            
            plano.MouseDown3D += Plano_MouseDown3D;
        }


        private void Plano_MouseDown3D(object sender, RoutedEventArgs e)
        {
            var args = e as Mouse3DEventArgs;
            //checar con los comand bindings 
        }

        public void AddItem(Element3D Item,Vector2 position)
        {
            //Adds an item on the plane at the given 2D position
            Item.MouseDown3D += Item_MouseDown3D;
            Item.MouseUp3D += Item_MouseUp3D;
            Item.MouseMove3D += Item_MouseMove3D;
            Items.Add(Item);
            viewport.Items.Add(Item);
        }

        private void Item_MouseMove3D(object sender, RoutedEventArgs e)
        {
            
        }

        private void Item_MouseUp3D(object sender, RoutedEventArgs e)
        {
            
        }

        private void Item_MouseDown3D(object sender, RoutedEventArgs e)
        {
            
        }

        public void Hide()
        {
            //Este metodo oculta todos los elementos que se hayan agregado a este plano
        }
        public void Enable()
        {
            plano.AlwaysHittable = true;
            //activa el marco
        }
        public void Disable()
        {
            //Este metodo deshabilita el movimiento de todo lo que se haya
            //agregado en este plano
            plano.AlwaysHittable = false;
            plano.IsRendering = false;
        }
    }
}
