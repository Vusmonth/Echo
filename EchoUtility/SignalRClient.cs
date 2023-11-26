using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoUtility
{
    public enum ConnectionMode
    {
        Development,
        Production
    }

    public class SignalRClient
    {
        static SignalRClient? instance;
        static HubConnection? connection;

        private SignalRClient(string ConnectionURL)
        {
            connection = new HubConnectionBuilder()
                   .WithUrl(ConnectionURL)
                   .WithAutomaticReconnect()
                   .Build();

            connection.StartAsync().Wait();
        }

        public static HubConnection Connect(ConnectionMode connectionMode)
        {
            if (connection == null)
            {
                string remoteURL = "https://ordinary-edge-production.up.railway.app/explorer";
                string localURL = "http://localhost:8081/explorer";
                instance = new SignalRClient(connectionMode == ConnectionMode.Production ? remoteURL : localURL);
            }
            return connection;
        }

    }
}
