using SCNetworking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server
    {
        private static void Main(string[] args) {
            SCNetwork server = new SCNetwork();
            server.OnConnect += server_OnConnect;
            server.OnDataReceived += server_OnDataReceived;
            server.OnDisconnect += server_OnDisconnect;

            //Database.DatabaseAsync().Wait();

            server.Start(55555);

            while (true) {
                Console.ReadLine(); // infinite loop, do server work here...
            }
        }

        private static void server_OnConnect(object sender, SCNetwork connection) {
            Console.WriteLine($"Connection from: {connection.RemoteEndPoint}");
        }

        private static void server_OnDataReceived(object sender, SCNetwork connection, byte[] e) {
            Console.WriteLine($"Message from {connection.RemoteEndPoint}: {Encoding.UTF8.GetString(e)}");
        }

        private static void server_OnDisconnect(object sender, SCNetwork connection) {
            Console.WriteLine($"Disconnected from: {connection.RemoteEndPoint}");
        }
    }
}