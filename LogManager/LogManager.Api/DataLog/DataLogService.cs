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
    public class DataLogService : BackgroundService, IDisposable
    {
        private string exchangeName, queueName, hostName, userName, pass;
        int port;

        private ConnectionFactory _connectionFactory;
        private IModel _model;
        private IConnection Connection { get; set; }

        private Persistence.IUnitOfWork unitOfWork;
        private ILogger<DataLogService> _logger;

        public DataLogService(ILogger<DataLogService> logger, IConfiguration configuration, Persistence.IUnitOfWork UnitOfWork)
        {
            _logger = logger;
            SetInjection(configuration);
            unitOfWork = UnitOfWork;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            CreateConnection();

            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += Consumer_Received;

            _model.BasicConsume(queueName, false, consumer);

            return Task.CompletedTask;
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var content = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                var log= JsonConvert.DeserializeObject<LogMessageGeneral>(content);

                if (log.Type.ToUpper().Equals("LogMessage".ToUpper()))
                {
                    var logData = JsonConvert.DeserializeObject<Domain.Entities.LogMessage>(log.MessageValue);

                    if (logData != null)
                    {

                        var insItem = (unitOfWork.LogMessageRepository.InsertAsync(logData)).Result;

                        _model.BasicAck(e.DeliveryTag, false);

                    }
                }
                else if (log.Type.ToUpper().Equals("OrderLogsModel".ToUpper()))
                {
                    var logData = JsonConvert.DeserializeObject<BehsamFramework.Models.OrderLogsModel>(log.MessageValue);

                    if (logData != null)
                    {

                        var insItem = (unitOfWork.LogOrderRepository.InsertAsync(logData)).Result;

                        _model.BasicAck(e.DeliveryTag, false);

                    }
                }
                else
                {
                    _model.BasicNack(e.DeliveryTag, false, false);
                }
            }
            catch (Exception ex)
            {
                _model.BasicNack(e.DeliveryTag, false, true);
                _logger.LogError("Data Logger has an error :=>" + ex.Message);
            }


        }

        //------------------------------------------------------
        //------------------------------------------------------
       
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
