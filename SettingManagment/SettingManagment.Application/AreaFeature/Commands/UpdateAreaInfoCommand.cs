namespace SettingManagment.Application.AreaFeature.Commands
{
    public class UpdateAreaInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public int AreaType { get; set; }
        public int ParentID { get; set; }
        public float CenterLatitude { get; set; }
        public float Centerlongitude { get; set; }
        public bool Status { get; set; }
        public int CityId { get; set; }
    }
}
