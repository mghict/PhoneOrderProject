namespace BillManagement.Domain.Entities
{
    public class Order:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
    }
}
