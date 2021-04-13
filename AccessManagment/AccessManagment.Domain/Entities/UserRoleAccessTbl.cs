namespace AccessManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("UserRoleAccessTbl")]
    public class UserRoleAccessTbl:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string ApplicationName { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string RoleName { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string UserName { get; set; }


    }
}
