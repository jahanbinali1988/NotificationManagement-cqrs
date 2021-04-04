using NotificationManagement.Application.Facade.Contract.Messages.Commands;
using NotificationManagement.Presentation.Api.GRPC.Proto;

namespace NotificationManagement.Presentation.Api.GRPC.Map
{
    public static class MessageMapper
    {
        public static SendMessageCommandDto Map(this Message message)
        {
            var command = new SendMessageCommandDto();

            if (message == null)
                return command;

            command.Content = message.Content;
            command.Title = message.Title;

            return command;
        }
    }
}
