namespace AccessManagment.Application.User.Commands
{
    public class ResetPassUserCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
        public string NewPassConfirm { get; set; }
    }

}
