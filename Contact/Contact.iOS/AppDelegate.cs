using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace Contact.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            string file_name = "db_contacts.sqlite"; // Nombre del archivo de bd
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "Databases"); // Directorio compuesto donde sera guardada la bd, una carpeta al nivel de "Personal"
            string path = Path.Combine(directory, file_name); // Ruta completa de la bd

            LoadApplication(new App(path)); // Se cambia el constructor por el creado que cointiene la ruta de la bd

            return base.FinishedLaunching(app, options);
        }
    }
}
