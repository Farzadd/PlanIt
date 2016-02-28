using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.IO;

namespace PlanIt.Droid
{
	[Activity (Label = "PlanIt",
        Theme="@style/android:Theme.Holo.Light.NoActionBar",
        Icon = "@drawable/icon",
        MainLauncher = true)]
	public class MainActivity : Activity
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
                newUser.Id = "123";
                newUser.FacebookID = user.UserId;
                newUser.FacebookName = "CHEESECAKE";

                var result = await client
                    .InvokeApiAsync<User, string>("createUser", newUser);

                Global.mThisUser = newUser;

                CreateAndShowDialog(result, user.UserId);
                
                success = true;
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
				StartActivity(typeof(EventList));
            }
        }

		[Java.Interop.Export()]
		public void openEventList(View view)
		{
			StartActivity(typeof(EventList));
		}

		[Java.Interop.Export()]
		public void openEventDetail(View view)
		{
			StartActivity(typeof(EventDetails));
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            CurrentPlatform.Init();

            // Create the Mobile Service Client instance, using the provided
            // Mobile Service URL
            client = new MobileServiceClient(applicationURL);

            // Sample server code: ****************************************************
            /*
            CurrentPlatform.Init();
            TodoItem item = new TodoItem { Text = "Awesome item" };
            await MobileService.GetTable<TodoItem>().InsertAsync(item);
            */
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


