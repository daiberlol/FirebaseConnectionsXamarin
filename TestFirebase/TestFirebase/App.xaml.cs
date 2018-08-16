using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TestFirebase
{
	public partial class App : Application
	{
        public static IFirebaseAuthService _firebaseService;
		public App ()
		{
			InitializeComponent();
            _firebaseService = DependencyService.Get<IFirebaseAuthService>();
            MessagingCenter.Subscribe<String, String>(this, _firebaseService.getAuthKey(), (sender, args) =>
               {
                   LoginGoogle(args);
               });
            MainPage = new NavigationPage(new MainPage());
		}

        private async Task LoginGoogle(String token)
        {
            if (await _firebaseService.SignInWithGoogle(token))
            {
                //await NavigationService.NavigateToAsync<MainViewModel>();
            }

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
