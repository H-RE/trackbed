using HelixToolkit.Wpf.SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Drawing;
using System.Windows.Shapes;
using SharpDX;

namespace TrackBed
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Camera camera { get; }
        public EffectsManager effectsManager { get; }
        public Material Green { get; }
        public MeshGeometry3D mesh { get; private set; }
        public MainWindow()
        {
            //Hacer ToolTip a los elementos
            
            InitializeComponent();
            //view1.EnableCurrentPosition = true;
            DataContext = this;
            effectsManager = new DefaultEffectsManager();
            camera = new PerspectiveCamera();
            var miPlano = new Plane2D(view1);
            
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            MessageBox.Show("diste");

        }

        private void view1_MouseMove3D(object sender, RoutedEventArgs e)
        {
            //var args = e as Mouse3DEventArgs;
            //var position = args.Position.ToVector2();
            //label.Content = position.Y.ToString() ;
        }
    }
}
