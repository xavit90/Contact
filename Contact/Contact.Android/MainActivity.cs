using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace Contact.Droid
{
    [Activity(Label = "Contact", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            string file_name = "db_contacts.sqlite"; // Nombre del archivo de bd
            string directory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Directorio donde sera guardada la bd
            string path = Path.Combine(directory, file_name); // Ruta completa de la bd

            LoadApplication(new App(path)); // Se cambia el constructor por el creado que cointiene la ruta de la bd
        }
    }
}