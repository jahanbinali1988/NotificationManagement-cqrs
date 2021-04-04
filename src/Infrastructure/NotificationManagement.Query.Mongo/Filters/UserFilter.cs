using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationManagement.Query.Mongo.Filters
{
    public class UserFilter
    {
        public int Offset { get; set; }
        public int Count { get; set; }
        public bool IsActive { get; set; }
    }
}
