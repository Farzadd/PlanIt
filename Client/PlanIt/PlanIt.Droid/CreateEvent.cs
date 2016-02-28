
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
    [Activity(Label = "CreateEvent",
        Theme = "@style/android:Theme.Holo.Light.Dialog.NoActionBar",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        Icon = "@drawable/icon")]			
	public class CreateEvent : Activity
	{
		static string[] NAMES = new string[] {
			"Farzad", "Farzi", "Jun", "Anton", "Behrouz"
		};

		List<EventItem> eventItems = new List<EventItem> ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view
			SetContentView (PlanIt.Droid.Resource.Layout.CreateEvent);

			MultiAutoCompleteTextView textView = FindViewById<MultiAutoCompleteTextView> (PlanIt.Droid.Resource.Id.autocompleteNames);
			var adapter = new ArrayAdapter<String> (this, PlanIt.Droid.Resource.Layout.friends_ac, NAMES);

			textView.Adapter = adapter;
		}

        [Java.Interop.Export()]
        public void SaveEvent(View view)
        {
            StartActivity(typeof(EventList));
        }
	}
}

