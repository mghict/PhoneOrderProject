namespace BehsamFramework.EFDomain.Base
{
	public interface IUnitOfWork : IQueryUnitOfWork
	{
		System.Threading.Tasks.Task SaveAsync();
	}
}
