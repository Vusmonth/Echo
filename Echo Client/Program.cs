using Echo_Client.Controllers;
using EchoUtility;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace EchoClient
{

    class Program
    {
        static Explorer explorer = new Explorer(System.IO.Directory.GetCurrentDirectory());
        static HubConnection client = SignalRClient.Connect(ConnectionMode.Development);

        static void Main(string[] args)
        {
            client.On("EXPLORER/GO_BACK", HandleGoBack);
            client.On("EXPLORER/LIST_FILES", HandleListFiles);
            client.On<string>("EXPLORER/NAVIGATE_TO", HandleNavigateTo);

            while (true) { };

        }

        public static async void HandleGoBack()
        {
            explorer.GoBack();
            try
            {
                await client.InvokeAsync("EXPLORER/EMIT_FILE_LIST", explorer.ListFiles());
                await client.InvokeAsync("EXPLORER/CURRENT_PATH", explorer.currentRoute);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static async void HandleListFiles()
        {
            try
            {
                await client.InvokeAsync("EXPLORER/EMIT_FILE_LIST", explorer.ListFiles());
                await client.InvokeAsync("EXPLORER/CURRENT_PATH", explorer.currentRoute);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static async void HandleNavigateTo(string path)
        {
            explorer.NavigateTo(path);

            try
            {
                await client.InvokeAsync("EXPLORER/EMIT_FILE_LIST", explorer.ListFiles());
                await client.InvokeAsync("EXPLORER/CURRENT_PATH", explorer.currentRoute);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
