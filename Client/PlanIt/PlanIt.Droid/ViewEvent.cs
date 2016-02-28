using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
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

            LatLng location = new LatLng(49.2740435, -123.2522604);
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);
            builder.Bearing(155);
            builder.Tilt(65);
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            MapFragment mapFrag = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
            GoogleMap map = mapFrag.Map;
            if (map != null)
            {
                map.MoveCamera(cameraUpdate);
            }
        }
    }
}