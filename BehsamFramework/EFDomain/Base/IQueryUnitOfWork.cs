namespace BehsamFramework.EFDomain.Base
{
	public interface IQueryUnitOfWork : System.IDisposable
	{
		bool IsDisposed { get; }
	}
}
