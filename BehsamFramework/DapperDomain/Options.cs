namespace BehsamFramework.DapperDomain
{
	public class Options : object
	{
		public Options() : base()
		{
		}

		// **********
		public BehsamFramework.DapperDomain.Enums.Provider Provider { get; set; }
		// **********

		// **********
		public string ConnectionString { get; set; }
		// **********

		// **********
		public string InMemoryDatabaseName { get; set; }
		// **********
	}
}
