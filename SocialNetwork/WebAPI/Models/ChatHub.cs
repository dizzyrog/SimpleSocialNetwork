using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ChatHub : Hub
    {
        public Task SendMessage1(string user1, string user2, string message)               // Two parameters accepted
        {
            return Clients.All.SendAsync("ReceiveOne", user1, user2, message);    // Note this 'ReceiveOne' 
        }
    }
}
