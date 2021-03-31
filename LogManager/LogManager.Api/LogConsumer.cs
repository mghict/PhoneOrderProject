using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace LogManager.Api
{
    public class LogConsumer : BackgroundService
    {
        ILogger<LogConsumer> _logger;

        public LogConsumer(ILogger<LogConsumer> logger):base()
        {
            _logger = logger;
        }
        protected override  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            CreateConnection();

            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var log = JsonConvert.DeserializeObject<LogFromat>(content);

                if (log.MessageType.ToUpper().Equals("LOG"))
                {
                    string valueMessage = $"{log.MessageBody}";
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
                }
                
                _model.BasicAck(ea.DeliveryTag, false);
            };

            _model.BasicConsume("UserTest", false, consumer);

            return Task.CompletedTask;
        }



        private ConnectionFactory _connectionFactory;
        private IModel _model;
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
            _model.QueueDeclare("UserTest", true, false, false, null);
        }
    }
}