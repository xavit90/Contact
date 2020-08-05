using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewContactPage : ContentPage
	{
		public NewContactPage ()
		{
			InitializeComponent ();
		}

        private bool Validation() =>
            !string.IsNullOrWhiteSpace(entryName.Text) &
            !string.IsNullOrWhiteSpace(entryLastName.Text) &
            !string.IsNullOrWhiteSpace(entryEmail.Text) &
            !string.IsNullOrWhiteSpace(entryTelephone.Text);

        private void Clear()
        {
            entryName.Text = string.Empty;
            entryLastName.Text = string.Empty;
            entryEmail.Text = string.Empty;
            entryTelephone.Text = string.Empty;
        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    // Obtenemos los datos de la interfaz y los seteamos al objeto de la clase contacto
                    Code.Contact contact = new Code.Contact
                    {
                        Name = entryName.Text,
                        LastName = entryLastName.Text,
                        Email = entryEmail.Text,
                        Telephone = entryTelephone.Text
                    };

                    // Conexion Sin Using
                    //var conn = new SQLite.SQLiteConnection(App.Path_Db); // Crear cadena de conexion
                    //conn.CreateTable<Code.Contact>(); // Crear tabla con el tipo de objeto, para el caso "Contact"
                    //conn.Insert(contact); // Se agrega a la tabla el nuevo contacto agregado
                    //conn.Close(); // Cerrar conexion

                    // Conexion Con Using
                    using (var conn = new SQLite.SQLiteConnection(App.Path_Db)) // Crear cadena de conexion
                    {
                        conn.CreateTable<Code.Contact>(); // Crear tabla con el tipo de objeto, para el caso "Contact"
                        conn.Insert(contact); // Se agrega a la tabla el nuevo contacto agregado
                    } // Cierra conexion en automatico

                    DisplayAlert("Éxito", "Contanto agregado correctamente", "Aceptar");
                    Clear();
                }
                else
                {
                    DisplayAlert("Error", "*Faltan campos requeridos para insertar", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}