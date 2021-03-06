﻿using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Serilog;

namespace Wrido.Electron
{
  public class FakeElectronModule : Module
  {
    private readonly ILogger _logger = Log.ForContext<FakeElectronModule>();

    protected override void Load(ContainerBuilder builder)
    {
      _logger.Information("Wiring up Fake Electron services");

      builder
        .RegisterType<FakeElectronHost>()
        .AsImplementedInterfaces()
        .SingleInstance();
    }
  }

  public class FakeElectronHost : IElectronHost
  {
    public Task StartAsync(CancellationToken ct = default)
    {
      return Task.CompletedTask;
    }
  }
}
