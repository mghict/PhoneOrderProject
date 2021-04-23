﻿using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagment.Core
{
    public static class DependencyContainer : object
    {
        static DependencyContainer()
        {
        }

		public static void ConfigureServices
			(Microsoft.Extensions.Configuration.IConfiguration configuration,
			Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {

			//***********************************************
			//===============================================
			//***********************************************

			services.AddSingleton<BehsamFreamwork.Logger.IInternalLogger,BehsamFreamwork.Logger.InternalLogger>(c=>
			{

				string host="", port="", user="", pass="", exchange="", queue="";
				host = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "HostName")
						.Value;

				port =  configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "Port")
						.Value;

				user = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "UserName")
						.Value;

				pass = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "Password")
						.Value;

				exchange = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "ExchangeLogData")
						.Value;

				queue = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "QueueLogData")
						.Value;

				return new BehsamFreamwork.Logger.InternalLogger(exchange,queue, user, pass, host, System.Convert.ToInt32(port));
			});

			services.AddSingleton< BehsamFreamwork.Logger.InternalLogger>(c =>
			{

				string host, port, user, pass, exchange, queue;
				host = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "HostName")
						.Value;

				port = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "Port")
						.Value;

				user = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "UserName")
						.Value;

				pass = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "Password")
						.Value;

				exchange = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "ExchangeLogData")
						.Value;

				queue = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "QueueLogData")
						.Value;

				return new BehsamFreamwork.Logger.InternalLogger(exchange, queue, user, pass, host, System.Convert.ToInt32(port));
			});

			services.AddSingleton<Framework.MessageSender.IMessageDetails, Framework.MessageSender.MessageDetails>(c =>
			{
				string host, port, user, pass, exchange, queue;

				host = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "HostName")
						.Value;

				port = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "Port")
						.Value;

				user = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "UserName")
						.Value;

				pass = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "Password")
						.Value;

				exchange = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "ExchangeData")
						.Value;

				queue = configuration
						.GetSection(key: "RabbitMQSetting")
						.GetSection(key: "QueueData")
						.Value;

				return new Framework.MessageSender.MessageDetails(queue, exchange, user, pass, host, System.Convert.ToInt32(port));
			});

			services.AddSingleton<Framework.MessageSender.SendMessages>();

			// **************************************************
			// **************************************************

			services.AddTransient
            <Microsoft.AspNetCore.Http.IHttpContextAccessor,
                Microsoft.AspNetCore.Http.HttpContextAccessor>();

			// **************************************************
			//***************************************************

			services.AddMediatR
                (typeof(Application.CustomerInfoFeature.Commands.CreateCustomerCommand).GetTypeInfo().Assembly);
            // **************************************************
			services.AddAutoMapper(typeof(Application.CustomerInfoFeature.MappingProfile).GetTypeInfo().Assembly);
			// **************************************************
			services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "CommandsConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "CommandsDatabaseProvider")
					.Value;

				BehsamFramework.DapperDomain.Enums.Provider databaseProvider =
					(BehsamFramework.DapperDomain.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

                BehsamFramework.DapperDomain.Options options =
					new BehsamFramework.DapperDomain.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new Persistence.UnitOfWork(options: options);
			});
			// **************************************************
            // **************************************************
			services.AddTransient<Persistence.IQueryUnitOfWork, Persistence.QueryUnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "QueriesConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "QueriesDatabaseProvider")
					.Value;

                BehsamFramework.DapperDomain.Enums.Provider databaseProvider =
					(BehsamFramework.DapperDomain.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

                BehsamFramework.DapperDomain.Options options =
					new BehsamFramework.DapperDomain.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new Persistence.QueryUnitOfWork(options: options);
			});
			// **************************************************
		}
	}
}
