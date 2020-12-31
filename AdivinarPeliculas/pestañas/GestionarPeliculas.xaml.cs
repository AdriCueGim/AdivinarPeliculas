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
    public partial class GestionarPeliculas : UserControl
    {
        public ObservableCollection<Pelicula> Peliculas { get; private set; }

        public GestionarPeliculas()
        {
            InitializeComponent();
            Peliculas = (Application.Current.MainWindow as MainWindow).Peliculas;
            contenedorPrincipal.DataContext = Peliculas;
            listaGeneros.ItemsSource = Pelicula.GENEROS;
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            Peliculas.Remove(listaPeliculas.SelectedItem as Pelicula);
        }

        private void BotonAñadir_Click(object sender, RoutedEventArgs e)
        {
            Pelicula.Dificultad dificultad;

            if ((bool)facilRadioButton.IsChecked)
                dificultad = Pelicula.Dificultad.Facil;
            else if ((bool)normalRadioButton.IsChecked)
                dificultad = Pelicula.Dificultad.Normal;
            else
                dificultad = Pelicula.Dificultad.Dificil;

            Peliculas.Add(new Pelicula(tituloTextBox.Text,
                                       pistaTextBox.Text,
                                       imagenTextBox.Text,
                                       dificultad,
                                       (Pelicula.Genero)Enum.Parse(
                                                            typeof(Pelicula.Genero),
                                                            listaGeneros.SelectedItem.ToString())));
        }

        private void BotonDeseleccionar_Click(object sender, RoutedEventArgs e)
        {
            listaPeliculas.SelectedItem = null;
        }
    }
}
