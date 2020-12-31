using AdivinarPeliculas.clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AdivinarPeliculas
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Pelicula> Peliculas { get; set; }

        private void GeneraPeliculasEjemplo()
        {
            string urlImagenPelicula = "https://mott.pe/noticias/wp-content/uploads/2016/05/PORTADA-3.jpg";
            Peliculas.Add(new Pelicula("Peli1", "1", urlImagenPelicula, Pelicula.Dificultad.Facil, Pelicula.Genero.CienciaFiccion));
            Peliculas.Add(new Pelicula("Peli2", "2", urlImagenPelicula, Pelicula.Dificultad.Dificil, Pelicula.Genero.Comedia));
            Peliculas.Add(new Pelicula("Peli3", "3", urlImagenPelicula, Pelicula.Dificultad.Normal, Pelicula.Genero.Comedia));
            Peliculas.Add(new Pelicula("Peli4", "4", urlImagenPelicula, Pelicula.Dificultad.Facil, Pelicula.Genero.Comedia));
            Peliculas.Add(new Pelicula("Peli5", "5", urlImagenPelicula, Pelicula.Dificultad.Facil, Pelicula.Genero.Accion));
            Peliculas.Add(new Pelicula("Peli6", "6", urlImagenPelicula, Pelicula.Dificultad.Facil, Pelicula.Genero.Comedia));
            Peliculas.Add(new Pelicula("Peli7", "7", urlImagenPelicula, Pelicula.Dificultad.Facil, Pelicula.Genero.Terror));
            Peliculas.Add(new Pelicula("Peli8", "8", urlImagenPelicula, Pelicula.Dificultad.Facil, Pelicula.Genero.Drama));
            Peliculas.Add(new Pelicula("Peli9", "9", urlImagenPelicula, Pelicula.Dificultad.Facil, Pelicula.Genero.Comedia));
        }

        public MainWindow()
        {
            Peliculas = new ObservableCollection<Pelicula>();
            GeneraPeliculasEjemplo();
            InitializeComponent();
        }
    }
}
