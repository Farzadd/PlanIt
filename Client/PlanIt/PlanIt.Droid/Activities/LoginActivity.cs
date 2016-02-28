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
	[Activity (Label = "PlanIt.Droid", MainLauncher = true, Theme="@style/android:Theme.Holo.Light.NoActionBar")]
	public class LoginActivity : Activity
	{
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

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);

			CurrentPlatform.Init();

			// Create the Mobile Service Client instance, using the provided
			// Mobile Service URL
			client = new MobileServiceClient(applicationURL);

			//Initializing button from layout
			//			Button login = FindViewById<Button> (Resource.Id.buttonLoginUser);

			//Login button click action
			//			login.Click += (object sender, EventArgs e) => {
			//				Android.Widget.Toast.MakeText(this, "Login Button Clicked!", Android.Widget.ToastLength.Short).Show();
			//			};
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