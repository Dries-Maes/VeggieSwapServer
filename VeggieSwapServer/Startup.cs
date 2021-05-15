using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VeggieSwapServer.Business;
using VeggieSwapServer.Business.Services;
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
            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VeggieSwapServer", Version = "v1" });
            });

            services.AddDbContext<VeggieSwapServerContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddScoped<IGenericRepo<Address>, GenericRepo<Address>>();
            services.AddScoped<IGenericRepo<Purchase>, GenericRepo<Purchase>>();
            services.AddScoped<IGenericRepo<Resource>, GenericRepo<Resource>>();
            services.AddScoped<IGenericRepo<Trade>, GenericRepo<Trade>>();
            services.AddScoped<IGenericRepo<TradeItem>, GenericRepo<TradeItem>>();
            services.AddScoped<IGenericRepo<User>, GenericRepo<User>>();
            services.AddScoped<IGenericRepo<Wallet>, GenericRepo<Wallet>>();

            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<AddressService, AddressService>();
            services.AddScoped<PurchaseService, PurchaseService>();
            services.AddScoped<ResourceService, ResourceService>();
            services.AddScoped<TradeService, TradeService>();
            services.AddScoped<TradeItemService, TradeItemService>();
            services.AddScoped<UserService, UserService>();
            services.AddScoped<WalletService, WalletService>();

            services.AddScoped<ITokenService, TokenService>();
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