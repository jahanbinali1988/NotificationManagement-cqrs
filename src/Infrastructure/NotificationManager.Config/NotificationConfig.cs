using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NotificationManagement.Application.Command.Handler;
using NotificationManagement.Application.Facade.Contract.Messages;
using NotificationManagement.Application.Facade.Contract.Users;
using NotificationManagement.Application.Facade.Messages;
using NotificationManagement.Application.Facade.Users;
using NotificationManagement.Application.Query.Contract.Users;
using NotificationManagement.Application.Query.Users;
using NotificationManagement.Domain.Models.Message;
using NotificationManagement.Domain.Models.User;
using NotificationManagement.Domain.Services;
using NotificationManagement.Persistence.Mongo.Repositories;
using NotificationManagement.Persistence.Mongo.Services;
using NotificationManagement.Query.Mongo.Handlers.Users;

namespace NotificationManagement.Config
{
    public class NotificationConfig
    {
        private readonly IConfiguration _configuration;

        public NotificationConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Register(IServiceCollection service)
        {

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IMessageRepository, MessageRepository>();

            service.AddScoped<IMessageValidator, MessageValidator>();
            service.AddScoped<IUserValidator, UserValidator>();

            service.AddScoped<IMessageFacade, MessageFacade>();
            service.AddScoped<IUserFacade, UserFacade>();

            service.AddScoped<IUserFacadeQuery, UserFacadeQuery>();

            service.AddMediatR(typeof(UserQueryHandler).Assembly);
            service.AddMediatR(typeof(MessageHandler).Assembly);
            service.AddMediatR(typeof(UserHandler).Assembly);

            service.AddSingleton(a => CreateMongoDb());
        }
        private IMongoDatabase CreateMongoDb()
        {
            var mongoConfigSection = _configuration.GetSection("MongoDb");

            var config = mongoConfigSection.Get<MongoDbConfig>();

            var client = new MongoClient(config.ConnectionString);

            return client.GetDatabase(config.DatabaseName);
        }
    }
}
