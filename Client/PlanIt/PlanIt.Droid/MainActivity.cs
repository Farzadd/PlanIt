using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Microsoft.WindowsAzure.MobileServices;

namespace PlanIt.Droid
{
	[Activity (Label = "PlanIt.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            "https://planit-server.azurewebsites.net"
         );

		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
            // Sample server code: ****************************************************
            /*
            CurrentPlatform.Init();
            TodoItem item = new TodoItem { Text = "Awesome item" };
            await MobileService.GetTable<TodoItem>().InsertAsync(item);
            */

			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}


