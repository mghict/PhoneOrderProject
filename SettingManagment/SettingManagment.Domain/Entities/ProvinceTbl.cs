namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("ProvinceTbl")]
    public class ProvinceTbl :
        BehsamFramework.Entity.IEntity<float>
    {
        public float Id { get; set; }
        public string ProvinceName { get; set; }
    }
}
