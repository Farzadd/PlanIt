using System;
using Newtonsoft.Json;

namespace PlanIt
{
	public class Event
	{
        public string Id { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "time")]
		public string Time { get; set; }

		[JsonProperty(PropertyName = "location")]
		public string Location { get; set; }

		[JsonProperty(PropertyName = "notes")]
		public string Notes { get; set; }
	}

	public class EventWrapper : Java.Lang.Object
	{
		public EventWrapper(Event sam)
		{
			Event = sam;
		}

		public Event Event { get; private set; }
	}
}

