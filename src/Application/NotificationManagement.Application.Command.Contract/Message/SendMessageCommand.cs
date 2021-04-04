using MediatR;
using System;
using System.Collections.Generic;

namespace NotificationManagement.Application.Command.Contract.Message
{
    public class SendMessageCommand : IRequest
    {
        public List<Guid> UserIds { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
}
