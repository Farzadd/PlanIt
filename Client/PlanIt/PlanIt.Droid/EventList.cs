using System;
using System.Linq;
using System.Text;

using Java.Util;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace PlanIt.Droid
{
    [Activity(Label = "Event List",
        Theme = "@style/android:Theme.Holo.Light.NoActionBar",
        Icon = "@drawable/icon")]
    public class EventList : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventList);

            PopulateEvents();
        }

        protected async void PopulateEvents()
        {
            var eventlistexample = await CreateList();

            var listView = FindViewById<ListView>(PlanIt.Droid.Resource.Id.eventList);
            List<EventItem> eventItems = new List<EventItem>();

            listView.Adapter = new ColorAdapter(this, eventItems);

            foreach (Event ev in eventlistexample)
            {
                eventItems.Add(new EventItem()
                {
                    Color = Android.Graphics.Color.DarkRed,
                    EventName = ev.Title,
                    EventLocation = ev.Location
                });
            }
        }

        protected async Task<List<Event>> CreateList() {
            List<Event> eventlistexample = new List<Event>();
            var x = await Global.mClient
                 .InvokeApiAsync<string, string>("getUserEvents", "");

            Event shayans = new Event();
            shayans.Location = "Shayan's";
            shayans.Time = "Feb 2nd 2015";
            shayans.Title = "Telep at Shayan's";

            Event farzads = new Event();
            farzads.Location = "Farzad's";
            farzads.Time = "Feb 8th 2015";
            farzads.Title = "Telep at Farzad's";

            Event behys = new Event();
            behys.Location = "Behy's";
            behys.Time = "March 5th 2016";
            behys.Title = "Telep at Behy's";

            eventlistexample.Add(shayans);
            eventlistexample.Add(farzads);
            eventlistexample.Add(behys);

            return eventlistexample;
        }

        [Java.Interop.Export()]
        public void NewEvent(View view)
        {
            StartActivity(typeof(CreateEvent));
        }

        [Java.Interop.Export()]
        public void ViewEvent(View view)
        {
            StartActivity(typeof(LetsVote));
        }
	}

	public class ColorAdapter : BaseAdapter<EventItem>
	{
		List<EventItem> items;
		Activity context;
		public ColorAdapter(Activity context, List<EventItem> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override EventItem this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var item = items[position];

			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(PlanIt.Droid.Resource.Layout.eventItem, null);
			view.FindViewById<TextView>(PlanIt.Droid.Resource.Id.eventName).Text = item.EventName;
			view.FindViewById<TextView>(PlanIt.Droid.Resource.Id.eventLocation).Text = item.EventLocation;
			view.FindViewById<ImageButton>(PlanIt.Droid.Resource.Id.eventImageButton).SetBackgroundColor(item.Color);

			return view;
		}
	}

	public class EventItem
	{
		public string EventName { get; set; }
		public string EventLocation { get; set; }
		public Android.Graphics.Color Color { get; set; }
	}
}