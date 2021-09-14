using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using PersistenceServer.Repository;

namespace PersistenceServer.Networking
{
    public class DataServer
    {
        private TcpListener listener;
        private IPAddress ipAddress;

        public void Start()
        {
            ipAddress = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(ipAddress, 12345);
            listener.Start();

            while (true)
            {
                TcpClient acceptTcpClient = listener.AcceptTcpClient();
                ServerHandler serverHandler = new ServerHandler(acceptTcpClient);
                new Thread(async () => await handleClientConnection(serverHandler)).Start();
                Console.WriteLine($"Server connected client, connection status: {acceptTcpClient.Connected}");
            }
        }

        private async Task handleClientConnection(ServerHandler serverHandler)
        {
            await serverHandler.HandleRequest();
        }
    }
}