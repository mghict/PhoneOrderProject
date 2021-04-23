using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LogManager.Api.DataLog
{
    public class DataLogService : BackgroundService
    {
        private string exchangeName, queueName, hostName, userName, pass;
        int port;

        private ConnectionFactory _connectionFactory;
        private IModel _model;
        private IConnection Connection { get; set; }

        private Persistence.IUnitOfWork unitOfWork;
        private ILogger<DataLogService> _logger;

        public DataLogService(ILogger<DataLogService> logger,IConfiguration configuration, Persistence.IUnitOfWork UnitOfWork)
        {
            _logger = logger;
            SetInjection(configuration);
            unitOfWork= UnitOfWork;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            CreateConnection();

            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += Consumer_Received;

            _model.BasicConsume(queueName, false, consumer);

            return;//Task.CompletedTask;
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var content = Encoding.UTF8.GetString(e.Body.ToArray());
            var logData = JsonConvert.DeserializeObject<Domain.Entities.LogMessage>(content);

            if(logData!=null)
            {
                try
                {
                    unitOfWork.LogMessageRepository.Insert(logData);

                    _model.BasicAck(e.DeliveryTag, false);
                }
                catch(Exception ex)
                {
                    _logger.LogInformation("Data Logger has an error :=>" + ex.Message);
                }
            }

            
        }

        //------------------------------------------------------
        //------------------------------------------------------
        private void CreateConnection()
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = hostName,
                Password = pass,
                UserName = userName,
                Port = port == 0 ? Protocols.DefaultProtocol.DefaultPort : port
            };

            Connection = _connectionFactory.CreateConnection();
            _model = Connection.CreateModel();
            _model.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            _model.QueueDeclare(queueName, true, false, false, null);
            _model.QueueBind(queueName, exchangeName, queueName, null);

        }
        private void SetInjection(IConfiguration configuration)
        {
            hostName = configuration
                       .GetSection(key: "RabbitMQSetting")
                       .GetSection(key: "HostName")
                       .Value;

            port = Convert.ToInt32(configuration
                    .GetSection(key: "RabbitMQSetting")
                    .GetSection(key: "Port")
                    .Value);

            userName = configuration
                    .GetSection(key: "RabbitMQSetting")
                    .GetSection(key: "UserName")
                    .Value;

            pass = configuration
                    .GetSection(key: "RabbitMQSetting")
                    .GetSection(key: "Password")
                    .Value;

            exchangeName = configuration
                    .GetSection(key: "RabbitMQSetting")
                    .GetSection(key: "ExchangeData")
                    .Value;

            queueName = configuration
                    .GetSection(key: "RabbitMQSetting")
                    .GetSection(key: "QueueData")
                    .Value;
        }

        
    }
}
