using NotificationManagement.Application.Command.Contract.Message;
using NotificationManagement.Application.Facade.Contract.Messages.Commands;
using System;
using System.Collections.Generic;

namespace NotificationManagement.Application.Facade.Contract.Messages.Mapper
{
    public static class MessageMapper
    {
        public static SendMessageCommand Map(this SendMessageCommandDto dto, List<Guid> userIds)
        {
            SendMessageCommand command = new SendMessageCommand();
            return new SendMessageCommand() {
                Content = dto.Content,
                Title = dto.Title,
                UserIds = userIds
            };
        }
    }
}
