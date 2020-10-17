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
using System.Windows.Shapes;

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
            InitializeComponent();
            DataContext = this;
            effectsManager = new DefaultEffectsManager();
            camera = new PerspectiveCamera();
            var miPlano = new Plane2D(view1);
        }
    }
}
