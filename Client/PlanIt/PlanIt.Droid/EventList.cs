using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace PlanIt.Droid
{
	[Activity (Label = "PlanIt.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class EventList : Activity
	{
		List<EventItem> eventItems = new List<EventItem> ();
		ListView listView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (PlanIt.Droid.Resource.Layout.EventList);
			listView = FindViewById<ListView> (PlanIt.Droid.Resource.Id.eventList);

			eventItems.Add (new EventItem () { Color = Android.Graphics.Color.DarkRed,
				EventName = "Event1", EventLocation = "Richmond" });
			eventItems.Add (new EventItem () { Color = Android.Graphics.Color.SlateBlue,
				EventName = "Event2", EventLocation = "Surrey" });
			eventItems.Add (new EventItem () { Color = Android.Graphics.Color.ForestGreen,
				EventName = "Event3", EventLocation = "Mission" });

			listView.Adapter = new ColorAdapter (this, eventItems);
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