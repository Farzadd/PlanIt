using System;
using Newtonsoft.Json;

namespace PlanIt
{
	public class User
	{
		public string Id { get; set; }

        [JsonProperty(PropertyName = "facebookid")]
        public string FacebookID { get; set; }

		[JsonProperty(PropertyName = "facebookname")]
        public string FacebookName { get; set; }
	}

    public class UserWrapper : Java.Lang.Object
	{
        public UserWrapper(User user)
		{
            User = user;
		}

        public User User { get; private set; }
	}
}

