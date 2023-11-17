using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoUtility
{
    class SignalRClient
    {
        static SignalRClient? instance;
        private HubConnection? connection;

        private SignalRClient()
        {
            connection = new HubConnectionBuilder()
                   .WithUrl($"http://localhost:5000/explorer")
                   .WithAutomaticReconnect()
                   .Build();

            connection.StartAsync().Wait();
        }

        public static SignalRClient Client()
        {
            if (instance == null)
            {
                instance = new SignalRClient();
            }
            return instance;
        }

    }
}
