using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarin_devday.Converters
{
    public class PlatformConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;

            ImageSource iphone = Device.OnPlatform(
            iOS: ImageSource.FromFile("iphone.png"),
            Android: ImageSource.FromFile("iphone.png"),
            WinPhone: ImageSource.FromFile("iphone.png"));

            ImageSource droid = Device.OnPlatform(
            iOS: ImageSource.FromFile("droid.png"),
            Android: ImageSource.FromFile("droid.png"),
            WinPhone: ImageSource.FromFile("droid.png"));
            
            return (val == "iOS Device") ? iphone : droid;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
