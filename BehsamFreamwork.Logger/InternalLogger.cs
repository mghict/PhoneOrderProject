using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BehsamFreamwork.Logger
{
    public interface IInternalLogger
    {
        Task SendToQueue(InternalLog input);
    }
    public class InternalLogger:IInternalLogger
    {
        private ConnectionFactory _connectionFactory;
        private IModel _model;

        private string exchangeName;
        private string queueName;
        private string userName ;
        private string pass ;
        private string hostName;
        private int port;
        private IConnection Connection { get; set; }

        public InternalLogger(string exchangeName= "InternalLogEx", string queueName= "InternalLogQ", string userName= "admin", string pass= "admin", string hostName= "localhost", int port = 0)
        {
            this.exchangeName = exchangeName;
            this.queueName = queueName;
            this.userName = userName;
            this.pass = pass;
            this.hostName = hostName;
            this.port = port;
        }

        private void CreateConnection()
        {
            if (_connectionFactory == null)
            {
                _connectionFactory = new ConnectionFactory()
                {
                    HostName = hostName,
                    Password = pass,
                    UserName = userName,
                    Port = port == 0 ? Protocols.DefaultProtocol.DefaultPort : port
                };
            }

            Connection = _connectionFactory.CreateConnection();
            _model = Connection.CreateModel();
            _model.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            _model.QueueDeclare(queueName, true, false, false, null);
            _model.QueueBind(queueName, exchangeName, queueName, null);
        }

        public async Task SendToQueue(InternalLog input)
        {
            await Task.Run(() =>
            {
                CreateConnection();
                _model.BasicPublish(exchangeName, queueName, null, input.ToByteArray());
            });

        }
    }
}
