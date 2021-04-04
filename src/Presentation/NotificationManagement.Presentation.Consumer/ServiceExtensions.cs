using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationManagement.Presentation.Consumer.Consumers;
using NotificationManagement.Presentation.Consumer.Contract;
using RabbitMQHelper;

namespace NotificationManagement.Presentation.Consumer
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddNotificationManagementConsumers(this IServiceCollection services, IConfigurationSection rabbitConfigurationSection)
        {
            services.AddAsyncJobHelper(rabbitConfigurationSection);

            services.AddSingleton<IAsyncJobConsumer<RegisterUserMessage>, RegisterUserConsumer>();

            //hosted services
            services.AddHostedService<BaseConsumerHostedService<RegisterUserMessage>>();

            return services;
        }
    }
}
