using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;


namespace Echo_Mobile.Services
{
    internal class SignalRClient
    {
        public static HubConnection Build(int signalPort)
        {
            try
            {
                HubConnection connection = new HubConnectionBuilder()
                              .WithUrl($"http://localhost:{signalPort}/explorer")
                              .Build();

                //auto reconect
                connection.Closed += async (error) =>
                {
                    await Task.Delay(5000);
                    await connection.StartAsync();
                };

                connection.StartAsync().Wait();

                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

    }
}
