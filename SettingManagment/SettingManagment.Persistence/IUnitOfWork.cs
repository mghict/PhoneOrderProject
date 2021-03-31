namespace SettingManagment.Persistence
{
    public interface IUnitOfWork : BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.IAttributeStatusRepository AttributeStatusRepository { get; }
    }
}
