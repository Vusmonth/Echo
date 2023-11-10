using Echo_Client.Controllers;
using System.Diagnostics;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {

            SignalRClient.Build(5137);
            SignalRClient.Start();
            Explorer explorer = new Explorer("C:\\Users\\Arthu");

            while (true) { };

        }

    }
}
