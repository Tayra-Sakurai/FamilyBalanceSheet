using Microsoft.AspNetCore.SignalR;

namespace FamilyBalanceSheet.Hubs
{
    public class RequestHub : Hub
    {
        public async Task SendRequestNotification(string user)
        {
            await Clients.All.SendAsync("RequestSent", user);
        }

        public async Task RequestAcception(string user, string acceptedUser)
        {
            await Clients.All.SendAsync("RequestAccepted", user, acceptedUser);
        }
    }
}
