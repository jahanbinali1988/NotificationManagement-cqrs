using System;
using System.Collections.Generic;

namespace NotificationManagement.Presentation.Api.Messages.User.Request
{
    public class SendMessageRequest
    {
        public string Content { get; set; }
        public string Title { get; set; }
    }
}
