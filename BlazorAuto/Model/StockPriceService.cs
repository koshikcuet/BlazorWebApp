using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorAuto.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace BlazorAuto.Model
{  
    public class StockPriceService : IHostedService, IDisposable
    {
        private readonly IHubContext<StockHub> _hubContext;
        private Timer _timer;

        public StockPriceService(IHubContext<StockHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateStockPrices, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            return Task.CompletedTask;
        }

        private void UpdateStockPrices(object state)
        {
            var random = new Random();
            string[] stks = ["BEXIMCO", "ACI", "EBL", "AFTABAUTO", "GP"];
            var stockSymbol = stks[random.Next(0, 4)];
            var price = random.Next(100, 500);

            // Send update to all clients
            _hubContext.Clients.All.SendAsync("ReceiveStockUpdate", stockSymbol, price);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}


