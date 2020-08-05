using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contact
{
    public partial class MainPage : ContentPage
    {
        // Lista para leer los contactos de la bd
        List<Code.Contact> contacts;

        public MainPage()
        {
            InitializeComponent();
            contacts = new List<Code.Contact>();
            // Se crea un evento de listView para saber que elemento esta seleccionando
            listViewContacts.ItemSelected += ListViewContacts_ItemSelected;
        }

        private void ListViewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Obtener el contacto seleccionado
            var contact = (Code.Contact)e.SelectedItem;
            // Navegacion a la pagina detalles contacto
            Navigation.PushAsync(new ContactDetailPage(contact));
        }

        // Se vuelve a leer cada que inicia la pagina
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Conexion a la BD
            using (var conn = new SQLite.SQLiteConnection(App.Path_Db))
            {
                conn.CreateTable<Code.Contact>(); // Crea la tabla si no existe
                contacts = conn.Table<Code.Contact>().ToList(); // Extrae los datos de la tabla a la lista
                listViewContacts.ItemsSource = contacts; // Se enlaza la lista a la fuente de datos del listView
            }
        }

        private void ToolBarAdd_Clicked(object sender, EventArgs e)
        {
            // Navegacion a la pagina nuevo contacto
            Navigation.PushAsync(new NewContactPage());
        }
    }
}
