using RabbitMQ.Client;

namespace Framework.MessageSender
{
    public class MessageDetails : IMessageDetails
    {
        public MessageDetails(string queueName, string exchangeName, string userName, string pass, string hostName, int port=0)
        {
            QueueName = queueName;
            ExchangeName = exchangeName;
            UserName = userName;
            Pass = pass;
            HostName = hostName;
            Port = port>0 ? port: Protocols.DefaultProtocol.DefaultPort;
        }
        public string QueueName { get; }
        public string ExchangeName { get; }
        public string UserName { get; }
        public string Pass { get; }
        public string HostName { get; }
        public int Port { get; }
    }
}