using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestFirebase
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            App._firebaseService.SignInWithGoogle();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App._firebaseService.Logout();
        }
    }
}
