using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dados;
using EstoqueAPI.Domain.Repository;
using EstoqueAPI.Domain.Service;
using EstoqueAPI.Infraestrutura;
using EstoqueAPI.Repository;
using EstoqueAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EstoqueAPI.WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddTransient<IUnitOfWork, UnitOfWork<Contexto>>();
      services.AddTransient<IProdutoRepository, ProdutoRepositorio>();
      services.AddTransient<IProdutoService, ProdutoService>();
      services.AddDbContext<Contexto>();
      services.AddControllers();
      services.AddCors(options =>
      {
        options.AddPolicy("EnableCORS", builder =>
        {
          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("EnableCORS");

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
