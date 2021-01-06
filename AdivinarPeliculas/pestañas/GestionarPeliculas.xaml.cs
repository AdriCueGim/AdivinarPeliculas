using AdivinarPeliculas.clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;

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

        private void ActualizaLista()
        {
            (Application.Current.MainWindow as MainWindow).Peliculas = Peliculas;
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                   "Se ha eliminado la película " + 
                   (listaPeliculas.SelectedItem as Pelicula).Titulo +
                   " con exito",
                   "Película eliminada",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            Peliculas.Remove(listaPeliculas.SelectedItem as Pelicula);
            ActualizaLista();
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

            MessageBox.Show(
                   "Se ha añadido la película " + tituloTextBox.Text + " con exito",
                   "Película añadida",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            ActualizaLista();
        }

        private void BotonDeseleccionar_Click(object sender, RoutedEventArgs e)
        {
            listaPeliculas.SelectedItem = null;
        }

        private void BotonGuardarJson_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            saveFileDialog.InitialDirectory = AppContext.BaseDirectory;
            string peliculasJson = JsonConvert.SerializeObject(Peliculas);

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, peliculasJson, Encoding.UTF8);
        }

        private void BotonCargarJson_Click(object sender, RoutedEventArgs e)
        {
            List<Pelicula> peliculas;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON file (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = AppContext.BaseDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                Peliculas = new ObservableCollection<Pelicula>();
                try
                {
                    using (StreamReader jsonStream = File.OpenText(openFileDialog.FileName))
                    {
                        var json = jsonStream.ReadToEnd();
                        peliculas = JsonConvert.DeserializeObject<List<Pelicula>>(json);

                        foreach (Pelicula pelicula in peliculas)
                        {
                            Peliculas.Add(pelicula);
                        }
                        contenedorPrincipal.DataContext = Peliculas;
                    }
                }
                catch (JsonReaderException)
                {
                    MessageBox.Show(
                        "El formato del documento no es válido", 
                        "Error al cargar JSON", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            ActualizaLista();
        }

        private void BotonExaminarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG file (*.jpg)|*.jpg|JPEG file (*.jpeg)|*.jpeg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = AppContext.BaseDirectory;

            if (openFileDialog.ShowDialog() == true)
                imagenTextBox.Text = openFileDialog.FileName;
        }
    }
}
