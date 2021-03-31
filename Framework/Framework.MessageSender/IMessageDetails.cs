namespace Framework.MessageSender
{
    public interface IMessageDetails
    {
        string QueueName { get; }
        string ExchangeName { get; }
        string UserName { get; }
        string Pass { get; }
        string HostName { get; }
        int Port { get; }
    }
}