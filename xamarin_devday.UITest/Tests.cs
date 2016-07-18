using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace xamarin_devday.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void CreateNote()
        {
            //app.Repl();
            app.Tap(x => x.Class("EntryEditText").Index(0));
            app.EnterText(x => x.Class("EntryEditText").Index(0), string.Format("Debo ir al trabajo - {0}", Guid.NewGuid().ToString()));
            app.Tap(x => x.Class("PickerRenderer").Index(0));
            app.Tap(x => x.Class("AppCompatTextView").Index(0));
            app.Tap("Agregar");
            app.ScrollDown();
            app.Back();
        }
    }
}

