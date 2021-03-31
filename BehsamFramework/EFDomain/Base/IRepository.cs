namespace BehsamFramework.EFDomain.Base
{
	public interface IRepository<T> : IQueryRepository<T> where T : Entity.IEntity
	{
		System.Threading.Tasks.Task<T> InsertAsync(T entity);

		System.Threading.Tasks.Task<bool> UpdateAsync(T entity);

		System.Threading.Tasks.Task<bool> DeleteAsync(T entity);

		System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id);
	}

    public interface IRepository<T,TKeyDataType> : IQueryRepository<T, TKeyDataType> 
        where T : Entity.IEntity<TKeyDataType>
        where TKeyDataType:struct
    {
        System.Threading.Tasks.Task<T> InsertAsync(T entity);

        System.Threading.Tasks.Task<bool> UpdateAsync(T entity);

        System.Threading.Tasks.Task<bool> DeleteAsync(T entity);

        System.Threading.Tasks.Task<bool> DeleteByIdAsync(TKeyDataType id);
    }
}
