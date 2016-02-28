using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Java.Util;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PlanIt.Droid
{
    [Activity(Label = "EventList")]
    public class EventList : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventList);

            var eventlistexample = CreateList();

            var listView = FindViewById<LinearLayout>(Resource.Id.eventlistlinearLayout);

            foreach (Event ev in eventlistexample) {
                listView.AddView(genTextViewForEvent(ev));
            }
        }

        protected TextView genTextViewForEvent(Event ev) {
            var view = new TextView(this);
            view.SetText(ev.Title, TextView.BufferType.Normal);
            return view;
        }

        protected List<Event> CreateList() {
            List<Event> eventlistexample = new List<Event>();

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
    }
}