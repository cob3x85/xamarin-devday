using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace xamarin_devday.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .DeviceSerial("10.71.34.101:5555")
                    //.ApkFile("../../../xamarin_devday/xamarin_devday.Droid/bin/Release/xamarin_devday.Droid.apk")
                    .ApkFile(@"C:/GitHub/xamarin-devday/xamarin-devday/xamarin_devday.Droid/bin/Release/xamarin_devday.Droid.apk")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

