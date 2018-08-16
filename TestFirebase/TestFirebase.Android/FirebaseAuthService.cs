using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using TestFirebase.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(FirebaseAuthService))]
namespace TestFirebase.Droid
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        public static int REQ_AUTH = 9999;
        public static string KEY_AUTH = "FIREBASE";
        public string getAuthKey()
        {
            return KEY_AUTH;
        }

        public bool IsUserSigned()
        {
            var user = Firebase.Auth.FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            var signedIn = user != null;
            return signedIn;
        }

        public async Task<bool> Logout()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.GetInstance(MainActivity.app).SignOut();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SignIn(string email, string password)
        {
            try
            {

                await Firebase.Auth.FirebaseAuth.GetInstance(MainActivity.app).SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SignInWithGoogle()
        {
            var googleIntent = new Intent(Forms.Context, typeof(GoogleLoginActiviy));
            ((Activity)Forms.Context).StartActivityForResult(googleIntent, REQ_AUTH);
        }
        

        public async Task<bool> SignInWithGoogle(string token)
        {
            try
            {
                AuthCredential credential = GoogleAuthProvider.GetCredential(token, null);
                await FirebaseAuth.GetInstance(MainActivity.app).SignInWithCredentialAsync(credential);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> SignUp(string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.GetInstance(MainActivity.app).CreateUserWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}