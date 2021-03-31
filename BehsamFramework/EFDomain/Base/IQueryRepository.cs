namespace BehsamFramework.EFDomain.Base
{
	public interface IQueryRepository<T> where T : Entity.IEntity
	{
		System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id);

		System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();
	}

    public interface IQueryRepository<T,TKeyDataType> 
        where T : Entity.IEntity<TKeyDataType>
        where TKeyDataType:struct
    {
        System.Threading.Tasks.Task<T> GetByIdAsync(TKeyDataType id);

        System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();
    }
}
