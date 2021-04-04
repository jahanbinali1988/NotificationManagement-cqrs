using MediatR;
using MongoDB.Driver;
using NotificationManagement.Application.Command.Contract.Message;
using NotificationManagement.Domain.Models.Message;
using NotificationManagement.Persistence.Mongo.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Application.Command.Handler
{
    public class MessageHandler :
        AsyncRequestHandler<SendMessageCommand>
    {
        #region fields
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMessageRepository _messageRepository;
        #endregion

        #region ctor
        public MessageHandler(IMongoDatabase mongoDatabase, IMessageRepository messageRepository)
        {
            this._mongoDatabase = mongoDatabase;
            this._messageRepository = messageRepository;
        }
        #endregion

        #region methods
        protected override async Task Handle(SendMessageCommand command, CancellationToken cancellationToken)
        {
            if (command is null)
                throw new Exception("The message to send is null");

            foreach (var userId in command.UserIds)
            {
                var id = Guid.NewGuid();
                var message = await Message.Create(id, command.Content, command.Title, true, userId, new MessageValidator(this._mongoDatabase));

                await _messageRepository.Create(message);
            }
        }
        #endregion
    }
}
