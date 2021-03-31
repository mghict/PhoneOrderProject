using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace BehsamFreamwork.Logger
{
    public class InternalLogger
    {
        private ConnectionFactory _connectionFactory;
        private IModel _model;

        private string exchangeName = "InternalLogEx";
        private string queueName = "InternalLogQ";
        private IConnection Connection { get; set; }
        private void CreateConnection()
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                Password = "admin",
                UserName = "admin",
                Port = Protocols.DefaultProtocol.DefaultPort
            };

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
