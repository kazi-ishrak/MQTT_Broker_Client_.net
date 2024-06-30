using System;
using System.Text;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;
using MQTTClient.Handlers;
using MQTTnet.Server;

namespace MQTTClient
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            ConnectClient();
        }

        public async Task ConnectClient()
        {
            var mqttFactory = new MqttFactory();
            var mqttClient = mqttFactory.CreateMqttClient();
            try
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
               .WithClientId("WinFormsClient")
               .WithTcpServer("localhost", 1883)
               .WithCleanSession(true)
               .Build();


                var resposne = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
                LogHandler.WriteLog($"The MQTT client status:{resposne}");
                /*    var clientDisconnectOption = mqttFactory.CreateClientDisconnectOptionsBuilder().Build();
                    await mqttClient.DisconnectAsync(clientDisconnectOption, CancellationToken.None);*/
            }
            catch (Exception ex)
            {
                LogHandler.WriteErrorLog(ex);
                throw;
            }
            await Ping_server(mqttClient);
            await Publish_Application_Message(mqttClient);
            await Subscribe_Topic(mqttClient, mqttFactory);
        }

        private async Task Ping_server(IMqttClient mqttClient)
        {

            try
            {
                await mqttClient.PingAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {

                LogHandler.WriteErrorLog(ex);
            }

        }

        private async Task Publish_Application_Message(IMqttClient mqttClient)
        {
            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic("mqttnet/samples/topic/1")
                .WithPayload("test")
                .Build();
            try
            {
                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
                LogHandler.WriteLog($"Application Message: {applicationMessage.Topic}, {applicationMessage.PayloadSegment}");
            }
            catch (Exception ex)
            {

                LogHandler.WriteErrorLog(ex);
            }
            
        }

        /*private async Task Handle_Received_Application_Message(IMqttClient mqttClient)
        {
            mqttClient.ApplicationMessageReceivedAsync += e =>
            {

            };
        }*/
        private async Task Subscribe_Topic(IMqttClient mqttClient, MqttFactory mqttFactory )
        {
            try
            {
                var mqttSubscriberOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(
                    f =>
                    {
                        f.WithTopic("mqttnet/samples/topic/1");
                    })
                .Build();

                var response = await mqttClient.SubscribeAsync(mqttSubscriberOptions, CancellationToken.None);
                LogHandler.WriteLog($"Subscribe to topic {response}");
            }
            catch (Exception ex)
            {
                LogHandler.WriteErrorLog(ex);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
