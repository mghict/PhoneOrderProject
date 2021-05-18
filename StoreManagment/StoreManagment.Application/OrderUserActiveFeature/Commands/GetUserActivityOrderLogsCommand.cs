using System.Collections.Generic;

namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class GetUserActivityOrderLogsCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.UserActivityLogs>>
    {
        public int UserId { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }

        //[System.Text.Json.Serialization.JsonConstructor]
        //public GetUserActivityOrderLogsCommand()
        //{
        //    UserId = 0;
        //    FromDate = System.DateTime.Now;
        //    ToDate = System.DateTime.Now;
        //}

        //[System.Text.Json.Serialization.JsonConstructor]
        //public GetUserActivityOrderLogsCommand(int userId)
        //{
        //    UserId = userId;
        //    FromDate = System.DateTime.Now;
        //    ToDate = System.DateTime.Now;
        //}
    }
}
