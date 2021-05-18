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

namespace LogManager.Api.InternalLog
{
    public class InternalLoggerService : BackgroundService,IDisposable
    {
        ILogger<InternalLoggerService> _logger;

        private ConnectionFactory _connectionFactory;
        private IModel _model;
        private IConnection Connection { get; set; }

        private string exchangeName, queueName, hostName, userName, pass;
        int port;

        public InternalLoggerService(ILogger<InternalLoggerService> logger, IConfiguration configuration)
        {
            _logger = logger;

            SetInjection(configuration);
        }

        protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            CreateConnection();

            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += Consumer_Received;

            _model.BasicConsume(queueName, false, consumer);

            return;
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var content = Encoding.UTF8.GetString(e.Body.ToArray());
            var log = JsonConvert.DeserializeObject<InternalLog>(content);


            string valueMessage = $"{log.LogMessage}";
            switch (log.LogLevel)
            {
                case LogLevel.Information:
                    _logger.LogInformation(valueMessage);
                    break;
                case LogLevel.Warning:
                    _logger.LogWarning(valueMessage);
                    break;
                case LogLevel.Error:
                    _logger.LogError(valueMessage);
                    break;
                case LogLevel.Critical:
                    _logger.LogCritical(valueMessage);
                    break;
                case LogLevel.Trace:
                    _logger.LogTrace(valueMessage);
                    break;
                case LogLevel.Debug:
                    _logger.LogDebug(valueMessage);
                    break;


            }

            _model.BasicAck(e.DeliveryTag, false);
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
                    .GetSection(key: "ExchangeLogData")
                    .Value;

            queueName = configuration
                    .GetSection(key: "RabbitMQSetting")
                    .GetSection(key: "QueueLogData")
                    .Value;
        }

        private void CreateConnection()
        {
            if (Connection == null || Connection.IsOpen == false)
            {
                _connectionFactory = new ConnectionFactory()
                {
                    HostName = hostName,
                    Password = pass,
                    UserName = userName,
                    Port = port == 0 ? Protocols.DefaultProtocol.DefaultPort : port
                };

                Connection = _connectionFactory.CreateConnection();
            }

            if (_model == null || _model.IsOpen == false)
            {
                _model = Connection.CreateModel();
                _model.ExchangeDeclare(exchangeName, ExchangeType.Direct, durable: true, autoDelete: false);
                _model.QueueDeclare(queueName, false, false, false, null);
                _model.QueueBind(queueName, exchangeName, queueName, null);
            }
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
