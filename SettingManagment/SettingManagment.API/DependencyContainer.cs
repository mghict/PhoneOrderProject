using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace SettingManagment.Core
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
            services.AddSingleton<BehsamFreamwork.Logger.InternalLogger>();

            // **************************************************
			services.AddTransient
            <Microsoft.AspNetCore.Http.IHttpContextAccessor,
                Microsoft.AspNetCore.Http.HttpContextAccessor>();
            // **************************************************
            

			services.AddMediatR
                (typeof(Application.CustomerValuesFeature.Commands.CustomerValuesCommand).GetTypeInfo().Assembly);
			// **************************************************
			services.AddAutoMapper(typeof(Application.CustomerValuesFeature.MappingProfile).GetTypeInfo().Assembly);
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
