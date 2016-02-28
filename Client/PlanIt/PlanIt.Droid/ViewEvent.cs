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
    [Activity(Label = "ViewEvent")]
    public class ViewEvent : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.ViewEvent);

            FindViewById<TextView>(Resource.Id.titleText).Text = this.Intent.Extras.GetString("eventTitle");
            FindViewById<TextView>(Resource.Id.locationText).Text = this.Intent.Extras.GetString("eventLocation");
            FindViewById<TextView>(Resource.Id.timeText).Text = this.Intent.Extras.GetString("eventTime");
            FindViewById<TextView>(Resource.Id.notesText).Text = this.Intent.Extras.GetString("eventNotes");
        }
    }
}