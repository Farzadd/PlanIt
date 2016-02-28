
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
        Theme = "@style/android:Theme.Holo.Light.Dialog.NoActionBar",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        Icon = "@drawable/icon")]			
	public class EventDetails : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.EventDetails);

			var attendeeList = CreateList();

			//var listView = FindViewById<ListView>(PlanIt.Droid.Resource.Id.attendeeList);
			//listView.Adapter = new ArrayAdapter<String>(this, PlanIt.Droid.Resource.Layout.attendee, attendeeList);
			//listView.Adapter = new ColorAdapter(this, attendeeList);
			RadioButton radio_going = FindViewById<RadioButton>(Resource.Id.radio_going);
			RadioButton radio_maybe = FindViewById<RadioButton>(Resource.Id.radio_maybe);
			RadioButton radio_cannot = FindViewById<RadioButton>(Resource.Id.radio_cannot);

			radio_going.Click += RadioButtonClick;
			radio_maybe.Click += RadioButtonClick;
			radio_cannot.Click += RadioButtonClick;
		}

		public class ColorAdapter : BaseAdapter<User>
		{
			List<User> attendees;
			Activity context;
			public ColorAdapter(Activity context, List<User> attendees)
				: base()
			{
				this.context = context;
				this.attendees = attendees;
			}
			public override long GetItemId(int position)
			{
				return position;
			}
			public override User this[int position]
			{
				get { return attendees[position]; }
			}
			public override int Count
			{
				get { return attendees.Count; }
			}
			public override View GetView (int position, View convertView, ViewGroup parent)
			{
				var user = attendees[position];

				View view = convertView;
				if (view == null) // no view to re-use, create new
					view = context.LayoutInflater.Inflate(PlanIt.Droid.Resource.Layout.attendee, null);
				view.FindViewById<TextView>(PlanIt.Droid.Resource.Id.attendeeName).Text = user.FacebookName;
				view.FindViewById<ImageView> (PlanIt.Droid.Resource.Id.status).SetImageResource(Resource.Drawable.logoNoBorder);
				return view;
			}
		}


		private void RadioButtonClick (object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			Toast.MakeText (this, rb.Text, ToastLength.Short).Show ();
		}

		protected List<User> CreateList() {
			List<User> eventlistexample = new List<User>();

			User saman = new User();
			saman.FacebookName = "Saman";

			User mahsan = new User();
			mahsan.FacebookName = "Mahsan";

			User farzad = new User();
			mahsan.FacebookName = "Farzad";

			User shayan = new User();
			mahsan.FacebookName = "Shayan";

			User ehsan = new User();
			mahsan.FacebookName = "Ehsan";

			eventlistexample.Add(saman);
			eventlistexample.Add(mahsan);
			eventlistexample.Add(farzad);
			eventlistexample.Add(shayan);
			eventlistexample.Add(ehsan);

			return eventlistexample;
		}
	}
}

