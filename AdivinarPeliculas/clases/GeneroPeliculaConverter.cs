﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace AdivinarPeliculas.clases
{
    public class GeneroPeliculaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(typeof(Pelicula.Genero), value.ToString());
        }
    }
}
