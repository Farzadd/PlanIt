
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PlanIt.Droid
{
	[Activity (Label = "LetsVote",
        Theme="@style/android:Theme.Holo.Light.NoActionBar",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        Icon = "@drawable/icon")]
	public class LetsVote : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view
			SetContentView (PlanIt.Droid.Resource.Layout.LetsVote);

		}
	}
}

