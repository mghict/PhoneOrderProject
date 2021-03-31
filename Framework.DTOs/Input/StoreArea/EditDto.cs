namespace DTOs.Input.StoreArea
{
    public class EditDto : Base.DtoInputBase
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public int AreaId { get; set; }
        public int ShippingPrice { get; set; }
        public byte DrivingTime { get; set; }
        public byte Priority { get; set; }
        public byte Status { get; set; }
    }
}
