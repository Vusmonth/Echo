using Echo_Client.Controllers;
using EchoUtility;
using System.Diagnostics;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Explorer explorer = new Explorer("C:\\Users\\Arthu");
            SignalRClient.Build(5093);
            SignalRClient.Start(explorer);

            while (true) { };

        }

    }
}
