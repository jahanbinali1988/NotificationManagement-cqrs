using EasyNetQ;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NotificationManagement.Application.Facade.Contract.Users;
using NotificationManagement.Application.Facade.Contract.Users.Commands;
using NotificationManagement.Application.Query.Contract.Users;
using NotificationManagement.Presentation.Consumer.Contract;
using RabbitMQHelper;
using System.Threading.Tasks;

namespace NotificationManagement.Presentation.Consumer.Consumers
{
    public class RegisterUserConsumer : BaseAsyncJobConsumer<RegisterUserMessage>
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public RegisterUserConsumer(IBus bus, ILogger<RegisterUserMessage> logger, IServiceScopeFactory scopeFactory) : base(bus, logger, "SmsNotifier")
        {
            _scopeFactory = scopeFactory;
        }

        public override async Task OnMessage(RegisterUserMessage message)
        {
            using var scope = _scopeFactory.CreateScope();
            var userFacade = scope.ServiceProvider.GetRequiredService<IUserFacade>();
            var userQueryFacade = scope.ServiceProvider.GetRequiredService<IUserFacadeQuery>();
            
            if (await userQueryFacade.UserExistance(message.Mobile))
            {
                var addCommandDto = message.Adapt<AddUserCommandDto>();
                await userFacade.AddUser(addCommandDto);
            }   
            else
            {
                var updateCommandDto = message.Adapt<UpdateCommandDto>();
                await userFacade.UpdateUser(updateCommandDto);
            }
        }
    }
}
