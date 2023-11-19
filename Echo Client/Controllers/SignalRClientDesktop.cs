using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;


namespace Echo_Client.Controllers
{
    internal class SignalRClientDesktop
    {
        static HubConnection connection;
        static Explorer explorer;

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

        public static void Start(Explorer _explorer)
        {
            explorer = _explorer;
            connection.On("EXPLORER/GO_BACK", HandleGoBack);
            connection.On("EXPLORER/LIST_FILES", HandleListFiles);
            connection.On<string>("EXPLORER/NAVIGATE_TO", HandleNavigateTo);
            connection.StartAsync().Wait();
        }

        public static async void HandleGoBack()
        {
            explorer.GoBack();
            try
            {
                await connection.InvokeAsync("EXPLORER/EMIT_FILE_LIST", explorer.ListFiles());
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
                await connection.InvokeAsync("EXPLORER/EMIT_FILE_LIST", explorer.ListFiles());
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
                await connection.InvokeAsync("EXPLORER/EMIT_FILE_LIST", explorer.ListFiles());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
