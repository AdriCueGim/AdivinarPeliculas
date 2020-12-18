using System.ComponentModel;

namespace AdivinarPeliculas.clases
{
    public class Pelicula : INotifyPropertyChanged
    {
        public enum Dificultad { Facil, Normal, Dificil }

        public enum Genero { Comedia, Drama, Accion, Terror, CienciaFiccion }

        private string titulo;
        public string Titulo
        {
            get { return this.titulo; }
            set
            {
                if (this.titulo != value)
                {
                    this.titulo = value;
                    this.NotifyPropertyChanged("Titulo");
                }
            }
        }

        private string pista;
        public string Pista
        {
            get { return this.pista; }
            set
            {
                if (this.pista != value)
                {
                    this.pista = value;
                    this.NotifyPropertyChanged("Pista");
                }
            }
        }

        private string rutaImagen;
        public string RutaImagen
        {
            get { return rutaImagen; }
            set
            {
                if (this.rutaImagen != value)
                {
                    this.rutaImagen = value;
                    this.NotifyPropertyChanged("RutaImagen");
                }
            }
        }

        private Dificultad dificultad;
        public Dificultad DificultadAdivinado
        {
            get { return dificultad; }
            set
            {
                if (this.dificultad != value)
                {
                    this.dificultad = value;
                    this.NotifyPropertyChanged("Dificultad");
                }
            }
        }

        private Genero genero;

        public Genero GeneroPelicula
        {
            get { return genero; }
            set
            {
                if (this.genero != value)
                {
                    this.genero = value;
                    this.NotifyPropertyChanged("Genero");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
