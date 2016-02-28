
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
    [Activity(Label = "EventDetails",
        Theme = "@style/android:Theme.Holo.Light.NoActionBar",
        Icon = "@drawable/icon")]			
	public class EventDetails : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.EventDetails);

			RadioButton radio_going = FindViewById<RadioButton>(Resource.Id.radio_going);
			RadioButton radio_maybe = FindViewById<RadioButton>(Resource.Id.radio_maybe);
			RadioButton radio_cannot = FindViewById<RadioButton>(Resource.Id.radio_cannot);

			radio_going.Click += RadioButtonClick;
			radio_maybe.Click += RadioButtonClick;
			radio_cannot.Click += RadioButtonClick;

            FindViewById<TextView>(Resource.Id.titleText).Text = this.Intent.Extras.GetString("eventTitle");
            FindViewById<TextView>(Resource.Id.locationText).Text = this.Intent.Extras.GetString("eventLocation");
            FindViewById<TextView>(Resource.Id.timeText).Text = this.Intent.Extras.GetString("eventTime");
            //FindViewById<TextView>(Resource.Id.note).Text = this.Intent.Extras.GetString("eventNotes");
        }

		private void RadioButtonClick (object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			Toast.MakeText (this, rb.Text, ToastLength.Short).Show ();
		}
	}
}

