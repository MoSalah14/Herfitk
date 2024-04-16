using Herfitk.API.ChatServices;
using Herfitk.API.Dto;
using Microsoft.AspNetCore.SignalR;

namespace Herfitk.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatService chatService;

        public ChatHub(ChatService _chatService)
        {
            chatService = _chatService;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "CommoChat");
            await Clients.Caller.SendAsync("UserConnected");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "CommoChat");
            var user = chatService.GetuserByconnectionid(Context.ConnectionId);
            chatService.RemoveUserFromlist(user);

            await DisplayOnlineUsers();
            await base.OnDisconnectedAsync(exception);
        }

        public async Task adduserconnectionid(string name)
        {
            chatService.Adduserconnectionid(name, Context.ConnectionId);
            await DisplayOnlineUsers();
        }

        private async Task DisplayOnlineUsers()
        {
            var onlineusers = chatService.GetOnlineUser();
            await Clients.Groups("CommoChat").SendAsync("OnlinneUsers", onlineusers);
        }

        public async Task ReceiveMessage(MessageDto message)
        {
            await Clients.Group("CommoChat").SendAsync("NewMessage", message);
        }

        public async Task CreatePrivateChat(MessageDto message)
        {
            string privateGroupName = GetPrivateGroupName(message.From, message.To);
            await Groups.AddToGroupAsync(Context.ConnectionId, privateGroupName);
            var toConnectionid = chatService.GetConnectionidByuser(message.To);

            await Groups.AddToGroupAsync(toConnectionid, privateGroupName);
            //openning private checkbox for the other end user
            await Clients.Client(toConnectionid).SendAsync("OpenPrivateChat", message);
        }

        public async Task RecievePrivateMessage(MessageDto message)
        {
            string privateGroupName = GetPrivateGroupName(message.From, message.To);
            await Clients.Group(privateGroupName).SendAsync("NewPrivateMessage", message);
        }

        public async Task RemovePrivateChat(string from, string to)
        {
            string privateGroupName = GetPrivateGroupName(from, to);
            await Clients.Group(privateGroupName).SendAsync("ClosePrivateChat");

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, privateGroupName);
            var toConnectionid = chatService.GetConnectionidByuser(to);
            await Groups.RemoveFromGroupAsync(toConnectionid, privateGroupName);
        }

        private string GetPrivateGroupName(string from, string to)
        {
            //fromahmed to mahmoud
            var stringCompare = string.CompareOrdinal(from, to) > 0;
            return stringCompare ? $"{from}-{to}" : $"{to}-{from}";
        }
    }
}