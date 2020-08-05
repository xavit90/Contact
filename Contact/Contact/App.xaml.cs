using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Contact
{
    public partial class App : Application
    {
        public static string Path_Db; // Se crea una variable estatica para guardar la ruta de la bd

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage(); // Direccion a Pagina principal
        }
        // Se crea un nuevo constructor para pasar la ruta de la base de datos
        public App(string path_db)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage()); // Direccion a Navegacion, inicia con pagina principal
            Path_Db = path_db; // Asignamos el parametro a la variable estatica
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
