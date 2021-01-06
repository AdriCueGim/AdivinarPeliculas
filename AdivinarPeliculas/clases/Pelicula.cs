using Newtonsoft.Json;
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

        private bool adivinada;
        public bool Adivinada
        {
            get { return adivinada; }
            set 
            {
                if (this.adivinada != value)
                {
                    this.adivinada = value;
                    this.NotifyPropertyChanged("Adivinada");
                }
            }
        }

        private bool pistaYaMostrada;
        public bool PistaYaMostrada
        {
            get { return pistaYaMostrada; }
            set
            {
                if (this.pistaYaMostrada != value)
                {
                    this.pistaYaMostrada = value;
                    this.NotifyPropertyChanged("PistaYaMostrada");
                }
            }
        }


        public static string[] GENEROS
        {
            get
            {
                return System.Enum.GetNames(typeof(Genero));
            }
        }

        [JsonConstructor]
        public Pelicula(string titulo, string pista, string rutaImagen, Dificultad dificultadAdivinado, Genero generoPelicula)
        {
            Titulo = titulo;
            Pista = pista;
            RutaImagen = rutaImagen;
            DificultadAdivinado = dificultadAdivinado;
            GeneroPelicula = generoPelicula;
            Adivinada = false;
            PistaYaMostrada = false;
        }

        public Pelicula(Pelicula pelicula)
        {
            Titulo = pelicula.Titulo;
            Pista = pelicula.Pista;
            RutaImagen = pelicula.RutaImagen;
            DificultadAdivinado = pelicula.DificultadAdivinado;
            GeneroPelicula = pelicula.GeneroPelicula;
            Adivinada = false;
            PistaYaMostrada = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
