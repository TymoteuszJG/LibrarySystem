using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DataLibrary.Communication
{
  public class ChatHub : Hub
  {
    /*
    public async Task SendRequest(string userId, string bookId)
    {
    
      await Clients.Others.SendAsync("RequestReceived", userId, bookId);
    }
    public async Task SendResponse(string userId, string bookId, bool isOnComponent)
    {
    
      await Clients.All.SendAsync("ResponseReceived", userId, bookId, isOnComponent);
    }
    */
    public async Task SendRequest(string connectionId, string bookId)
    {

      await Clients.Others.SendAsync("RequestReceived", connectionId, bookId);
    }
    public async Task SendResponse(string connectionId, string bookId)
    {
      await Clients.Client(connectionId).SendAsync("ResponseReceived", bookId);
     // await Clients.Others.SendAsync("ResponseReceived", bookId);
    }
    public string GetConnectionId()
    {
      return Context.ConnectionId;
    }
  }
}
