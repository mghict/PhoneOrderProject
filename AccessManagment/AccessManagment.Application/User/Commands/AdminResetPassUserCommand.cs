namespace AccessManagment.Application.User.Commands
{
    public class AdminResetPassUserCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
        public string NewPass { get; set; }
        public string NewPassConfirm { get; set; }
    }

}
