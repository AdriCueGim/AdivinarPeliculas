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

namespace AdivinarPeliculas.pestañas
{
    public partial class AdivinarPeliculas : UserControl
    {
        private const int PUNTUACION_FACIL = 100;
        private const int PUNTUACION_NORMAL = 250;
        private const int PUNTUACION_DIFICIL = 500;

        private const int NUMERO_PELICULAS = 5;

        public ObservableCollection<Pelicula> Peliculas { get; private set; }

        private int Posicion { get; set; }

        private int PeliculasLength
        {
            get
            {
                return Peliculas is null ? 0 : Peliculas.Count;
            }
        }

        public AdivinarPeliculas()
        {
            InitializeComponent();
            Posicion = 0;

            MuestraPeliculas();
        }

        private ObservableCollection<Pelicula> SeleccionaPeliculas()
        {
            Peliculas = (Application.Current.MainWindow as MainWindow).Peliculas;
            ObservableCollection<Pelicula> peliculasSeleccionadas = new ObservableCollection<Pelicula>();
            List<int> peliculasYaSeleccionadas = new List<int>();
            int peliculaSeleccionada;

            for (int i = 0; i < NUMERO_PELICULAS; i++)
            {
                peliculaSeleccionada = GeneraNuevoNumeroAleatorio(0, Peliculas.Count, peliculasYaSeleccionadas);
                peliculasYaSeleccionadas.Add(peliculaSeleccionada);
                peliculasSeleccionadas.Add(Peliculas[peliculaSeleccionada]);
            }

            return peliculasSeleccionadas;
        }

        private int GeneraNuevoNumeroAleatorio(int minimo, int maximo, List<int> numerosYaGenerados)
        {
            Random semilla = new Random();
            int numeroGenerado;

            do
            {
                numeroGenerado = semilla.Next(minimo, maximo);
            } while (numerosYaGenerados.Contains(numeroGenerado));

            return numeroGenerado;
        }

        private void MuestraPeliculas()
        {
            contenedorPrincipal.DataContext = PeliculasLength > 0 ? Peliculas[Posicion] : null;
            numeroPeliculas.Text = $"{Posicion + (PeliculasLength > 0 ? 1 : 0)} / {PeliculasLength}";

            if (PeliculasLength < 5)
            {
                MessageBox.Show("Se debe tener al menos 5 películas para empezar a jugar",
                                "Aviso",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                botonValidar.IsEnabled = false;
            }
            else
                botonValidar.IsEnabled = true;
        }

        private void Izquierda_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Posicion > 0)
            {
                Posicion--;
                MuestraPeliculas();
            }
        }

        private void Derecha_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Posicion < PeliculasLength - 1)
            {
                Posicion++;
                MuestraPeliculas();
            }
        }

        private void BotonNuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            textoPuntuacion.Text = 0.ToString();

            Peliculas = SeleccionaPeliculas();
            MuestraPeliculas();
        }
    }
}
