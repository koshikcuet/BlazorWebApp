using Microsoft.AspNetCore.SignalR;
//using System.Threading.Tasks;

namespace BlazorAuto.Hubs;
public class StockHub : Hub
{
    public async Task SendStockUpdate(string stockSymbol, decimal price)
    {
        await Clients.All.SendAsync("ReceiveStockUpdate", stockSymbol, price);
    }
}

