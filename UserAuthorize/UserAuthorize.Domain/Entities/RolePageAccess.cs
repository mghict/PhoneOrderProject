namespace UserAuthorize.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("RolePageAccess")]
    public class RolePageAccess :
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public int RoleId { get; set; }
        public int PageId { get; set; }
        public bool Status { get; set; }
    }
}
