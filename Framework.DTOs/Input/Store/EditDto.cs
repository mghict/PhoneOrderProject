namespace DTOs.Input.Store
{
    public class EditDto : Base.DtoInputBase
    {
        public double StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int AreaId { get; set; }
        public byte Status { get; set; }
    }
}
