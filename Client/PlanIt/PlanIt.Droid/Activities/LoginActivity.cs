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
	[Activity (Label = "PlanIt.Droid", Theme="@style/android:Theme.Holo.Light.NoActionBar")]
	public class LoginActivity : Activity
	{
        private Main logicMain;

        public LoginActivity()
        {
        }

        public LoginActivity(Main logicMain)
        {
            this.logicMain = logicMain;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            CurrentPlatform.Init();
        }

        [Java.Interop.Export()]
        public async void LoginUser(View view)
        {
            // Load data only after authentication succeeds.
            if (await logicMain.Authenticate())
            {
                // TODO@Jun: instead of hiding button, switch to main activity
                FindViewById<Button>(Resource.Id.buttonLoginUser).Visibility = ViewStates.Gone;
            }
        }
	}
}