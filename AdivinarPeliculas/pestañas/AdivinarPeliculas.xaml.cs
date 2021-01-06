using AdivinarPeliculas.clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        }

        private ObservableCollection<Pelicula> SeleccionaPeliculas()
        {
            Peliculas = (Application.Current.MainWindow as MainWindow).Peliculas;
            ObservableCollection<Pelicula> peliculasSeleccionadas = new ObservableCollection<Pelicula>();
            List<int> peliculasYaSeleccionadas = new List<int>();
            int peliculaSeleccionada;

            for (int i = 0; i < NUMERO_PELICULAS && PeliculasLength > 5; i++)
            {
                peliculaSeleccionada = GeneraNuevoNumeroAleatorio(0, Peliculas.Count, peliculasYaSeleccionadas);
                peliculasYaSeleccionadas.Add(peliculaSeleccionada);
                peliculasSeleccionadas.Add(new Pelicula(Peliculas[peliculaSeleccionada]));
            }

            CompruebaPeliculas(peliculasSeleccionadas.Count);

            return peliculasSeleccionadas;
        }

        private void CompruebaPeliculas(int numeroPeliculasSeleccionadas)
        {
            if (numeroPeliculasSeleccionadas == 5)
            {
                MessageBox.Show(
                    "Se han seleccionado 5 nuevas películas",
                    "Nueva partida", MessageBoxButton.OK, MessageBoxImage.Information);
                contenedorValidar.Tag = "Boton habilitado";
            }
            else
            {
                MessageBox.Show("Se debe tener al menos 5 películas para empezar a jugar, " +
                                "para añadir películas vaya a la pestaña 'Gestionar'",
                                "Aviso",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                contenedorValidar.Tag = "Boton deshabilitado";
            }
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
        }

        private int EligePuntuacion()
        {
            int puntuacion;
            switch (Peliculas[Posicion].DificultadAdivinado)
            {
                case Pelicula.Dificultad.Facil:
                    puntuacion = PUNTUACION_FACIL;
                    break;
                case Pelicula.Dificultad.Normal:
                    puntuacion = PUNTUACION_NORMAL;
                    break;
                case Pelicula.Dificultad.Dificil:
                    puntuacion = PUNTUACION_DIFICIL;
                    break;
                default:
                    puntuacion = 0;
                    break;
            }

            puntuacion /= (bool)pistaCheckBox.IsChecked ? 2 : 1;

            return puntuacion;
        }

        private void Izquierda_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Posicion > 0)
            {
                Posicion--;
                MuestraPeliculas();
                tituloAdivinado.Text = "";
            }
        }

        private void Derecha_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Posicion < PeliculasLength - 1)
            {
                Posicion++;
                MuestraPeliculas();
                tituloAdivinado.Text = "";
            }
        }

        private void BotonNuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            textoPuntuacion.Text = 0.ToString();
            Posicion = 0;
            Peliculas = SeleccionaPeliculas();
            MuestraPeliculas();
        }

        private void BotonValidar_Click(object sender, RoutedEventArgs e)
        {
            if (Peliculas[Posicion].Titulo.ToUpper() == tituloAdivinado.Text.ToUpper())
            {
                int puntuacion = int.Parse(textoPuntuacion.Text);
                puntuacion += EligePuntuacion();
                textoPuntuacion.Text = puntuacion.ToString();

                Peliculas[Posicion].Adivinada = true;

                MessageBox.Show(
                    "¡Has acertado!",
                    "Que bien", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show(
                    "No has acertado, si desea visualizar la pista, haga click en el campo de abajo", 
                    "Que mal", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
