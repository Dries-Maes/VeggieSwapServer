using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VeggieSwapServer.Business;
using VeggieSwapServer.Data;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VeggieSwapServer", Version = "v1" });
            });

            services.AddDbContext<VeggieSwapServerContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });
            services.AddCors();
            services.AddScoped<IGenericRepo<Address>, GenericRepo<Address>>();
            services.AddScoped<IGenericRepo<Purchase>, GenericRepo<Purchase>>();
            services.AddScoped<IGenericRepo<Resource>, GenericRepo<Resource>>();
            services.AddScoped<IGenericRepo<Trade>, GenericRepo<Trade>>();
            services.AddScoped<IGenericRepo<TradeItem>, GenericRepo<TradeItem>>();
            services.AddScoped<IGenericRepo<User>, GenericRepo<User>>();
            services.AddScoped<IGenericRepo<Wallet>, GenericRepo<Wallet>>();

            services.AddScoped<IGenericService<Address>, GenericService<Address>>();
            services.AddScoped<IGenericService<Purchase>, GenericService<Purchase>>();
            services.AddScoped<IGenericService<Resource>, GenericService<Resource>>();
            services.AddScoped<IGenericService<Trade>, GenericService<Trade>>();
            services.AddScoped<IGenericService<TradeItem>, GenericService<TradeItem>>();
            services.AddScoped<IGenericService<User>, GenericService<User>>();
            services.AddScoped<IGenericService<Wallet>, GenericService<Wallet>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VeggieSwapServer v1"));
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}