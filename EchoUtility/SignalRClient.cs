using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoUtility
{
    public class SignalRClient
    {
        static SignalRClient? instance;
        static HubConnection? connection;

        private SignalRClient(string ConnectionURL)
        {
            connection = new HubConnectionBuilder()
                   .WithUrl(ConnectionURL ?? $"http://localhost:5000/explorer")
                   .WithAutomaticReconnect()
                   .Build();

            connection.StartAsync().Wait();
        }

        public static HubConnection Connect(string ConnectionURL)
        {
            if (connection == null)
            {
                instance = new SignalRClient(ConnectionURL);
            }
            return connection;
        }

    }
}
