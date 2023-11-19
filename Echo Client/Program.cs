using Echo_Client.Controllers;
using EchoUtility;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Explorer explorer = new Explorer("C:\\Users\\Arthu");
            HubConnection client = SignalRClient.Connect("http://localhost:5093/explorer");

            client.On<string>("TESTE", (e) => { Console.WriteLine("aaa"); });
            client.On("EXPLORER/LIST_FILES", () => { Console.WriteLine("aaa"); });

            //SignalRClientDesktop.Build(5093);
            //SignalRClientDesktop.Start(explorer);

            while (true) { };

        }

        static void teste()
        {

        }

    }
}
