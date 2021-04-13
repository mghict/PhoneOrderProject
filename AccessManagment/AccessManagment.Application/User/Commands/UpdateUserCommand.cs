namespace AccessManagment.Application.User.Commands
{
    public class UpdateUserCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
        public float Storeid { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
    }

}
