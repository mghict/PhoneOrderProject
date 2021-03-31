namespace UserAuthorize.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("RoleInfoTbl")]
    public class RoleInfoTbl :
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        public string RoleName { get; set; }
        public int ApplicationId { get; set; }
        public bool Status { get; set; }
    }
}
