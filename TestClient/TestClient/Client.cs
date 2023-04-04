using SCNetworking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Client
    {
        private static void Main(string[] args)
        {
            SCNetwork client = new SCNetwork();
            client.OnConnect += client_OnConnect;
            client.OnDataReceived += client_OnDataReceived;
            client.OnDisconnect += client_OnDisconnect;

            client.Connect("localhost", 55555);

            while (true)
            {
                Console.WriteLine(">");
                client.Send(Encoding.UTF8.GetBytes(Console.ReadLine()));
            }
        }

        private static void client_OnConnect(object sender, SCNetwork connection)
        {
            Console.WriteLine($"Connection to: {connection.RemoteEndPoint}");
        }

        private static void client_OnDataReceived(object sender, SCNetwork connection, byte[] e)
        {
            Console.WriteLine($"Message from {connection.RemoteEndPoint}: {Encoding.UTF8.GetString(e)}");
        }

        private static void client_OnDisconnect(object sender, SCNetwork connection)
        {
            Console.WriteLine($"Disconnected from: {connection.RemoteEndPoint}");
        }
    }
}