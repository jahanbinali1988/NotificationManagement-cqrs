using Grpc.Core;
using Mapster;
using NotificationManagement.Application.Facade.Contract.Messages;
using NotificationManagement.Application.Query.Contract.Users;
using NotificationManagement.Presentation.Api.GRPC.Map;
using NotificationManagement.Presentation.Api.GRPC.Proto;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationManagement.Presentation.Api.GRPC.GrpcService
{
    public class NotificationService : NotoficationManagementService.NotoficationManagementServiceBase
    {
        #region fields
        private readonly IMessageFacade _messageFacade;
        #endregion

        #region ctor
        public NotificationService(IMessageFacade messageFacade)
        {
            _messageFacade = messageFacade;
        }
        #endregion

        #region methods
        public override async Task<SendMessageResponse> SendMessage(SendMessageRequest request, ServerCallContext context)
        {
            if (!request.Message.Content.Any())
                throw new RpcException(new Status(StatusCode.InvalidArgument, "The given Content is invalid"));

            var command = request.Message.Map();

            var result = await _messageFacade.SendMesssage(command);

            return new SendMessageResponse() { IsSuccessfull = result };
        }
        #endregion
    }
}
