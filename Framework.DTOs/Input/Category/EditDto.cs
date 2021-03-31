namespace DTOs.Input.Category
{
    public class EditDto : Base.DtoInputBase
    {
        public double Id { get; set; }
        public string CategoryName { get; set; }
        public double? ParentId { get; set; }
        public string ImageUrl { get; set; }
        public short Priority { get; set; }
        public byte Status { get; set; }
    }
}
