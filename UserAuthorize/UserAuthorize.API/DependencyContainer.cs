using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace UserAuthorize
{
    public static class DependencyContainer : object
    {
        static DependencyContainer()
        {
        }

        public static IServiceCollection ConfigureServices
            (this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddSingleton<BehsamFreamwork.Logger.InternalLogger>();

            // **************************************************
            services.AddTransient
            <Microsoft.AspNetCore.Http.IHttpContextAccessor,
                Microsoft.AspNetCore.Http.HttpContextAccessor>();
            // **************************************************


            services.AddMediatR
                (typeof(Application.UserFeatures.Commands.UserLoginCommand).GetTypeInfo().Assembly);
            // **************************************************
            services.AddAutoMapper(typeof(Application.UserFeatures.MapperProfile).GetTypeInfo().Assembly);
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
            services.AddSingleton<Application.Token.ITokenCreate, Application.Token.TokenCreate>(current =>
            {
                string _Key =
                    configuration
                    .GetSection(key: "Key")
                    .Value;

                string _Issuer =
                    configuration
                    .GetSection(key: "Issuer")
                    .Value;
                return new Application.Token.TokenCreate(_Key, _Issuer);
            });

            return services;
        }
    }
}
