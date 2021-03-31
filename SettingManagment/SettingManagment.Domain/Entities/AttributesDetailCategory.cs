namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("AttributeCategoryDetailTbl")]
    public class AttributesDetailCategory : BehsamFramework.Entity.IEntity<int>
    {
        public AttributesDetailCategory() : base()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public bool Status { get; set; }
        public int AttributeCategoryId { get; set; }
        public bool IsMandetory { get; set; }
        public bool IsListValue { get; set; }

    }
}