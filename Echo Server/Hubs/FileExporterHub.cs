using EchoUtility;
using Microsoft.AspNetCore.SignalR;

namespace Echo_Server.Hubs
{
    public class ExplorerHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        [HubMethodName("EXPLORER/LIST_FILES")]
        public async Task ListFiles()
        {
            await Clients.All.SendAsync("EXPLORER/LIST_FILES");
        }

        [HubMethodName("EXPLORER/GO_BACK")]
        public async Task GoBack()
        {
            await Clients.All.SendAsync("EXPLORER/GO_BACK");
        }

        [HubMethodName("EXPLORER/NAVIGATE_TO")]
        public async Task NavigateTo(string path)
        {
            await Clients.All.SendAsync("EXPLORER/NAVIGATE_TO", path);
        }

        [HubMethodName("EXPLORER/EMIT_FILE_LIST")]
        public async Task EmitFileList(List<FileItem> files)
        {
            await Clients.All.SendAsync("EXPLORER/FILE_LIST", files);
        }

        [HubMethodName("EXPLORER/CURRENT_PATH")]
        public async Task EmitCurrentPath(string path)
        {
            await Clients.All.SendAsync("EXPLORER/CURRENT_PATH", path);
        }

    }
}