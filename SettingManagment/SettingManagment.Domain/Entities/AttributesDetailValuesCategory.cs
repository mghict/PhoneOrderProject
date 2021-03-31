namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("AttributeCategoryDetailInfoTbl")]
    public class AttributesDetailValuesCategory : BehsamFramework.Entity.IEntity<int>
    {
        public AttributesDetailValuesCategory() : base()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int AttributeCategoryDetailId { get; set; }
        public bool IsDefualt { get; set; }

    }
}