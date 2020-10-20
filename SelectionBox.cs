using HelixToolkit.Wpf.SharpDX;
using SharpDX;
namespace TrackBed
{
    class SelectionBox//cambiar a SelectionArea
    {
        //Esta caja se encarga de poner Model.Isselected=true
        //A todos los elementos que queden dentro de ella
        //Si es posible también cambiar el color de los modelos
        //se seleccióna por nodos

        //https://docs.microsoft.com/en-us/windows/win32/direct3d9/rendering-from-vertex-and-index-buffers
        public MeshGeometryModel3D Box { get; }
        public SelectionBox(Vector3 normal)
        {
            var builder = new MeshGeometry3D();
            //agregar un punto movil al plano y usar la naturaleza de ese para 
            //modificar el cuadro de selección
            Box = new MeshGeometryModel3D();
            
            builder.Indices=new IntCollection(){0,1,2,3,0,2};
            builder.Positions = new Vector3Collection(){
                new Vector3(0,0,0),
                new Vector3(0,0,0),
                new Vector3(0,0,0),
                new Vector3(0,0,0)
            };
            builder.Normals = new Vector3Collection() {
            new Vector3(0,0,1),
            new Vector3(0,0,1),
            new Vector3(0,0,1),
            new Vector3(0,0,1)
            };
            
            Box.Geometry = builder;
            Box.Geometry.IsDynamic = true;
            Box.Material = PhongMaterials.Red;
        }
        public void Draw(Vector2 puntoA, Vector2 puntoB)
        {
            //Se van modificando las posiciones del marco}
            Box.Geometry.Positions= new Vector3Collection(){
                new Vector3(-1,-1,2),
                new Vector3(-1,1,2),
                new Vector3(1,1,2),
                new Vector3(1,-1,2)
            };
            Box.Geometry.UpdateVertices();
            //Cuadro delimitador IMPORTANTE
            //Box.Geometry.Bound;
            //Bounding box puede detectar intersecciones entre cajas
            //This refresh geometry bounding box
            Box.Geometry.UpdateBounds();
        }
    }
}
