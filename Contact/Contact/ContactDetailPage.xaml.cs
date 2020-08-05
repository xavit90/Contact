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
	public partial class ContactDetailPage : ContentPage
	{
        // Propidad de tipo contacto
        public Code.Contact Contact { get; set; }

        public ContactDetailPage (Code.Contact contact)
		{
			InitializeComponent ();
            // Asignar los valores del objeto obtenido de la pagina anterior a los labels
            Contact = contact;
            labelName.Text = $"{contact.Name} {contact.LastName}";
            labelEmail.Text = contact.Email;
            labelTelephone.Text = contact.Telephone;
		}
	}
}