#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("UserRoleTbl")]
    public partial class UserRoleTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public byte Status { get; set; }

        public virtual RoleInfoTbl Role { get; set; }
        public virtual UserInfoTbl User { get; set; }
    }
}
