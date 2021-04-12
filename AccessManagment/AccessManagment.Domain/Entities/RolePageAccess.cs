namespace AccessManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("RolePageAccess")]
    public class RolePageAccess:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PageId { get; set; }
        public bool Status { get; set; }
    }
}
