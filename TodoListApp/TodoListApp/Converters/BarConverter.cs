using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Xamarin.Forms;
using System.Globalization;

namespace TodoListApp.Converters
{
    class BarConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "Alta":
                    return Color.Red;
                case "Média":
                    return Color.Blue;
                default:
                    return Color.Green;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
