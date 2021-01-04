using AdivinarPeliculas.clases;
using System.Collections.ObjectModel;
using System.Windows;

namespace AdivinarPeliculas
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Pelicula> Peliculas { get; set; }

        public MainWindow()
        {
            Peliculas = new ObservableCollection<Pelicula>();
            InitializeComponent();
        }
    }
}
