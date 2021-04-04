using CacheHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationManagement.Presentation.Api.GRPC.GrpcService;
using NotificationManagement.Presentation.Consumer;
using NotificationManagement.Presentation.Consumer.Contract;
using RabbitMQHelper;
using RedisConnectionHelper;
using ServiceHost.Extensions;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCacheServices(Configuration.GetSection("Cache"));

            services.AddRedis(Configuration.GetSection("Redis"));

            services.AddGrpc();

            services.RegisterNotificationManagementDependencies(Configuration);
            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            //add consumers and rabbitMQ connection
            services.AddNotificationManagementConsumers(Configuration.GetSection("Rabbit"));
            services.AddSingleton<IAsyncJobProducer<RegisterUserMessage>, AsyncJobProducer<RegisterUserMessage>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<NotificationService>();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification V1");
            });

            app.UseHttpsRedirection();
        }
    }
}
