using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using MassTransit;

namespace Framework.MessageSender
{
    public class SendMessages //<TMessageDetails>
    // where TMessageDetails : IMessageDetails
    {
        private  ConnectionFactory _connectionFactory;
        private  IModel _model;
        private  IMessageDetails _messageDetails;
        private  IConnection Connection { get; set; }

        public SendMessages(IMessageDetails messageDetails)
        {
            _messageDetails = messageDetails;
        }

        public  async Task SendToQueue<T>(T input)
        {
            await Task.Run(() =>
            {
                CreateConnection();
                _model.BasicPublish(_messageDetails.ExchangeName, _messageDetails.QueueName, null, input.ToByteArray());
            });

        }

        private  void CreateConnection()
        {
            if (Connection == null)
            {
                _connectionFactory = new ConnectionFactory()
                {
                    HostName = _messageDetails.HostName,
                    Password = _messageDetails.Pass,
                    UserName = _messageDetails.UserName,
                    Port = _messageDetails.Port
                };


                Connection = _connectionFactory.CreateConnection();
                _model = Connection.CreateModel();
                _model.QueueDeclare(_messageDetails.QueueName, true, false, false, null);
                _model.ExchangeDeclare(_messageDetails.ExchangeName, ExchangeType.Direct);

                _model.QueueBindNoWait(_messageDetails.QueueName, _messageDetails.ExchangeName, _messageDetails.QueueName, null);
            }
        }

        //public  async Task SendToQueueByBus<T>(T input)
        //{
        //    var bus = Bus.Factory.CreateUsingRabbitMq(sb =>
        //    {
        //        sb.Host("rabbitmq://localhost");
        //        sb.ReceiveEndpoint(_messageDetails.QueueName, ep =>
        //        {
        //            //ep.Handler<T>(context =>
        //            //{
        //            //    return Console.Out.WriteLineAsync(context);
        //            //});
        //        });
        //    });

        //    await bus.StartAsync();
        //    await bus.Publish(input);
        //    await bus.StopAsync();
        //}
    }
}
