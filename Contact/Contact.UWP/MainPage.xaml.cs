using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Contact.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string file_name = "db_contacts.sqlite"; // Nombre del archivo de bd
            string directory = ApplicationData.Current.LocalFolder.Path; // Directorio donde sera guardada la bd
            string path = Path.Combine(directory, file_name); // Ruta completa de la bd

            LoadApplication(new Contact.App(path)); // Se cambia el constructor por el creado que cointiene la ruta de la bd
        }
    }
}
