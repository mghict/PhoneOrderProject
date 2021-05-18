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
    public class InternalLogger:IInternalLogger,IDisposable
    {
        private ConnectionFactory _connectionFactory;
        //private IModel _model;
        //private IConnection Connection { get; set; }
        protected IModel _model { get; private set; }
        private IConnection Connection;

        private string exchangeName;
        private string queueName;
        private string userName ;
        private string pass ;
        private string hostName;
        private int port;


        public InternalLogger(string exchangeName= "InternalLogEx", string queueName= "InternalLogQ", string userName= "admin", string pass= "admin", string hostName= "localhost", int port = 0)
        {

            this.exchangeName = exchangeName;
            this.queueName = queueName;
            this.userName = userName;
            this.pass = pass;
            this.hostName = hostName;
            this.port = port == 0 ? Protocols.DefaultProtocol.DefaultPort : port;

            _connectionFactory = new ConnectionFactory()
            {
                HostName = this.hostName,
                Password = this.pass,
                UserName = this.userName,
                Port = this.port
            };
        }

        private void CreateConnection()
        {
            if (Connection == null || Connection.IsOpen == false)
            {
                Connection = _connectionFactory.CreateConnection();
            }

            if (_model == null || _model.IsOpen == false)
            {
                _model = Connection.CreateModel();
                _model.ExchangeDeclare(exchangeName, ExchangeType.Direct,durable: true,autoDelete: false);
                _model.QueueDeclare(queueName, false, false, false);
                _model.QueueBind(queueName, exchangeName, queueName, null);
            }
            
        }

        public async Task SendToQueue(InternalLog input)
        {
            
            await Task.Run(() =>
            {
                CreateConnection();
                _model.BasicPublish(exchangeName, queueName, null, input.ToByteArray());
            });

        }

        public void Dispose()
        {
            try
            {
                _model?.Close();
                _model?.Dispose();
                _model = null;

                Connection?.Close();
                Connection?.Dispose();
                Connection = null;
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
