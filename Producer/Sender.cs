using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName="localhost"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("BasicTest", false, false, false, null);
            string message = "Sandeep's hello world";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "BasicTest", null, body);
            Console.WriteLine("Message has been sent {0} ", message);

        }
    }
}
