﻿using Microsoft.Azure.Mobile.Server;
using System.Collections.Generic;

namespace PlanIt_ServerService.DataObjects
{
    public class EventDTO : EntityData
    {
        public string Id { get; set; }

        public string Title { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public int Status { get; set; }

        public virtual User Creator { get; set; }
        public virtual List<User> Invitees { get; set; }
    }
}