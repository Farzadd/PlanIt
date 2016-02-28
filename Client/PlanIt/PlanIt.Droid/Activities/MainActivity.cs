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
	[Activity (Label = "PlanIt.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        PlanIt.Main logicMain;
        LoginActivity mLoginActivity;

        protected override void OnCreate(Bundle bundle)
        {
            logicMain = new Main(this);

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            CurrentPlatform.Init();

            mLoginActivity = new LoginActivity(logicMain);

            if (logicMain.IsUserLoggedIn()) {
                // TODO@Jun: Fix this
                // mLoginActivity.OnCreate();
            }     
        }

        public void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}


