﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace HotFi.App.Workers
{
    public class ServerSetupWorker : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}