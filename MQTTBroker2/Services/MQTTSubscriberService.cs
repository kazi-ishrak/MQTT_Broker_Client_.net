using MQTTBroker2.Handlers;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using System.Text;

namespace MQTTBroker2.Services
{
    public class MQTTSubscriberService
    {
        public static async Task Connect_Client()
        {
            var mqttFactory = new MqttFactory();
            var mqttClinet = mqttFactory.CreateMqttClient();

            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .Build();
            await Handle_Recieved_Application_Messages(mqttClinet);
            await mqttClinet.ConnectAsync(mqttClientOptions, CancellationToken.None);
            await Subscribe_topic(mqttFactory, mqttClinet);
        }
        public static async Task Subscribe_topic (MqttFactory mqttFactory, IMqttClient mqttClient)
        {
            var mqttSubscriberOptions = mqttFactory.CreateSubscribeOptionsBuilder()
               .WithTopicFilter
               (
                   f =>
                   {
                       f.WithTopic("mqttnet/samples/topic/1");
                   }
               ).Build();
            var response = await mqttClient.SubscribeAsync(mqttSubscriberOptions, CancellationToken.None);
            LogHandler.WriteLog("MQTT subscriber subscribed to a topic");
        }
        public static async Task Handle_Recieved_Application_Messages(IMqttClient mqttClient)
        {
            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                LogHandler.WriteLog($"Received Application Message topic: {e.ApplicationMessage.Topic}, and payload {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)} ");
                return Task.CompletedTask;
            };
        }
    }
}
