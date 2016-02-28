using System;
using System.Collections.Generic;
using System.Text;
using Android.Views;

using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.IO;

namespace PlanIt
{
    public class Main
    {
        //Mobile Service Client reference
        private MobileServiceClient client;

        const string applicationURL = @"https://planit-server.azurewebsites.net";

        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            applicationURL
         );

        private MobileServiceUser user;
        private async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await client.LoginAsync(this,
                    MobileServiceAuthenticationProvider.Facebook);

                User newUser = new User();
                newUser.FacebookID = user.UserId;
                newUser.FacebookName = "CHEESECAKE";

                var result = await client
                    .InvokeApiAsync<User, string>("createUser", newUser);

                CreateAndShowDialog(result, "FARZ");

                CreateAndShowDialog(string.Format("you are now logged in - {0}",
                    user.UserId), "Logged in!");

                success = true;
				SetContentView (Resource.Layout.Main);
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex, "Authentication failed");
            }
            return success;
        }

        [Java.Interop.Export()]
        public async void LoginUser(View view)
        {
            // Load data only after authentication succeeds.
            if (await Authenticate())
            {
                //Hide the button after authentication succeeds.
                FindViewById<Button>(Resource.Id.buttonLoginUser).Visibility = ViewStates.Gone;

                // Load the data.
                //OnRefreshItemsSelected();
            }
        }

        private void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
        }

        private void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}
