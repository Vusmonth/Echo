using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;


namespace Echo_Client.Controllers
{
    internal class SignalRClient
    {
        static HubConnection connection;

        public static void Build(int signalPort)
        {
            connection = new HubConnectionBuilder()
               .WithUrl($"http://localhost:{signalPort}/explorer")
               .Build();

            //auto reconect
            connection.Closed += async (error) =>
            {
                await Task.Delay(5000);
                await connection.StartAsync();
            };
        }

        public static void Start()
        {
            connection.On<string>("Count", HandleGoBack);
            connection.StartAsync().Wait();
        }

        public static void HandleGoBack(string cmd)
        {
            Console.WriteLine(cmd);
            Console.WriteLine($"\nPressione qualquer tecla para finalizar\n");
        }

        public static async void SendMessage()
        {
            try
            {
                await connection.InvokeAsync("SendMessage", "a", "aaa");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static async void End()
        {
            try
            {
                await connection.InvokeAsync("CountEvents", "Count");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
