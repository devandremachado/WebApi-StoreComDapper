using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Infra.StoreContext.DataContext;
using Store.Infra.StoreContext.Repositories;
using Store.Infra.StoreContext.Services;
using Elmah.Io.AspNetCore;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Store.Shared;

namespace Store.Api
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        // Adiciona middleware na aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(option => option.EnableEndpointRouting = false);
            
            // Arquivo de configuração (antigo web.config)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            // Faz a compressão das requisições da api (gzip)
            services.AddResponseCompression();

            // De-para DependencyInjection
            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            // Gera documentação a partir dos end-points da api
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Store", Version = "v1"});
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(x => // Documentacao em html
            { 
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Store - v1");
            });


            //app.UseElmahIo("c0d5e2a936534de5915b790bff870418", new Guid("62951742-0826-48ff-a1cf-d2babdbc9dd3"));
        }
    }
}
