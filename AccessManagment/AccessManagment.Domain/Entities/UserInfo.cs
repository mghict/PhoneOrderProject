﻿namespace AccessManagment.Domain.Entities
{
    public class UserInfo 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public float StoreId { get; set; }
        public string StoreName { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string? RoleName { get; set; }
        public int? ActiveStatus { get; set; }
        public string? ActiveStatusDesription { get; set; }
    }
}
