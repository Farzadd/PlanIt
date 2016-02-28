using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PlanIt_ServerService.DataObjects;

namespace PlanIt_ServerService.Models
{
    public class Event
    {
        public Event()
        {
            this.Invitees = new HashSet<User>();
        }

        public string Title { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public int Status { get; set; }

        public User Creator { get; set; }
        public ICollection<User> Invitees { get; set; }
    }
}