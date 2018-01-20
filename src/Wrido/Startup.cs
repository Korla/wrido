﻿using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Wrido.Core.Resolution;
using Wrido.Logging;
using Wrido.Plugin.Google;
using Wrido.Services;

namespace Wrido
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSignalR(options => options.JsonSerializerSettings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      });
      services.AddMvc();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
      builder
        .RegisterModule<DummyQueryModule>()
        .RegisterModule<LoggingModule>();

      builder
        .RegisterType<QueryService>()
        .AsImplementedInterfaces()
        .SingleInstance();

      new GooglePlugin().Register(builder);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app
        .UseDeveloperExceptionPage()
        .UseDefaultFiles()
        .UseStaticFiles()
        .UseSignalR(hub =>
          {
            hub.MapHub<InputHub>("input");
            hub.MapHub<LoggingHub>("logging");
          })
        .UseMvc();
    }
  }
}
