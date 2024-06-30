using MQTTnet;
using MQTTnet.Server;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using MQTTBroker2.Handlers;
using MQTTnet.Internal;
namespace MQTTBroker2.Services
{
    public class MQTTBrokerService
    {
        private static ILogger<MQTTBrokerService>? _logger;

        public MQTTBrokerService(ILogger<MQTTBrokerService> logger)
        {
            _logger = logger;
        }
        public static async Task<MqttServer> Run_minimal_server()
        {
            var mqttFactory = new MqttFactory();
            var mqttServerOptions = new MqttServerOptionsBuilder()
                .WithDefaultEndpoint()
                .WithDefaultEndpointPort(1883)
                .WithKeepAlive()
                .Build();
            var mqttServer = mqttFactory.CreateMqttServer(mqttServerOptions);

           /* await Intercepting_application_message(mqttServer);*/
            try
            {
                await mqttServer.StartAsync();
                LogHandler.WriteLog("started MQTT");
               
                return mqttServer;
            }
            catch (Exception ex)
            {

                LogHandler.WriteErrorLog(ex);
                return mqttServer;
            }
        }
        public async Task PublishMessageFromBroker()
        {
            var server = await Run_minimal_server();

            var message = new MqttApplicationMessageBuilder()
                .WithTopic("TEST")
                .WithPayload("Hello")
                .Build();
            try
            {
                await server.InjectApplicationMessage(
                new InjectedMqttApplicationMessage(message)
                {
                    SenderClientId = "sender"
                });
                LogHandler.WriteLog("MEssage Injected");
            }
            catch (Exception ex)
            {
                LogHandler.WriteErrorLog(ex);
            }
        }

        /*public static async Task Intercepting_application_message(MqttServer mqttServer)
        {
            try
            {
                mqttServer.InterceptingPublishAsync += e =>
                {
                    LogHandler.WriteLog($"Topic is:{e.ApplicationMessage.Topic}, Payload is: {e.ApplicationMessage.PayloadSegment.ToString()}");
                    return CompletedTask.Instance;
                };
            }
            catch (Exception ex)
            {
                LogHandler.WriteErrorLog(ex);
            }
           
        }*/
    }
}

