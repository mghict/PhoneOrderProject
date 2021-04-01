namespace UserAuthorize.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("PageInfoTbl")]
    public class PageInfoTbl :
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string PageName { get; set; }
        public int? ParentId { get; set; }
        public int ApplicationId { get; set; }
        public bool Status { get; set; }
        public string DisplayName { get; set; }
    }
}
