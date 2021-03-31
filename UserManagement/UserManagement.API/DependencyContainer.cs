using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement
{
    public static class DependencyContainer : object
    {
        static DependencyContainer()
        {
        }

		public static IServiceCollection ConfigureServices
			(this Microsoft.Extensions.DependencyInjection.IServiceCollection services,Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddSingleton<BehsamFreamwork.Logger.InternalLogger>();

            // **************************************************
			services.AddTransient
            <Microsoft.AspNetCore.Http.IHttpContextAccessor,
                Microsoft.AspNetCore.Http.HttpContextAccessor>();
            // **************************************************
            

			services.AddMediatR
                (typeof(UserManagment.Application.UsersFeature.Commands.CreateUserCommand).GetTypeInfo().Assembly);
            // **************************************************
			services.AddAutoMapper(typeof(UserManagment.Application.UsersFeature.MappingProfile).GetTypeInfo().Assembly);
			// **************************************************
			services.AddTransient<UserManagment.Persistence.IUnitOfWork, UserManagment.Persistence.UnitOfWork>(current =>
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

				return new UserManagment.Persistence.UnitOfWork(options: options);
			});
			// **************************************************
            // **************************************************
			services.AddTransient<UserManagment.Persistence.IQueryUnitOfWork, UserManagment.Persistence.QueryUnitOfWork>(current =>
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

				return new UserManagment.Persistence.QueryUnitOfWork(options: options);
			});
			// **************************************************

			return services;
		}
	}
}
