using System;
using System.Threading;
using System.Threading.Tasks;
using HotFi.App.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotFi.App.Workers
{
    public class DropletCreationWorker : BackgroundService
    {
        private readonly ApplicationDbContext _dbContext;
        public DropletCreationWorker(IServiceScopeFactory serviceScopeFactory)
        {
            _dbContext = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}