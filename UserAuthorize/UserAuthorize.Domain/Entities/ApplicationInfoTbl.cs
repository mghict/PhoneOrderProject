namespace UserAuthorize.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("ApplicationInfoTbl")]
    public class ApplicationInfoTbl :
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        public int ApplicationId { get; set; }
        public bool Status { get; set; }
    }
}
