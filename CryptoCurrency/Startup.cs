using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using CryptoCurrency.Data;
using Microsoft.EntityFrameworkCore;
using CryptoCurrencyWallet.Service;
using CryptoCurrencyWallet.Service.Interfaces;
using CryptoCurrencyWallet.Data;
using CryptoCurrency.Models;
using Microsoft.AspNetCore.Identity;
using CryptoCurrencyWallet.Data.Models;

namespace CryptoCurrency
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
            services.AddControllersWithViews();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));
            services.AddScoped<ICurrencyServices, CurrencyServices>();
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IEmailServices, EmailServices>();
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;

                opt.User.RequireUniqueEmail = true;

                opt.SignIn.RequireConfirmedEmail = true;

            })
             .AddEntityFrameworkStores<ApplicationContext>()
             .AddDefaultTokenProviders();
            //services.AddIdentity<AccountProfile, IdentityRole>(opt =>
            //{
            //    opt.Password.RequiredLength = 7;
            //    opt.Password.RequireDigit = false;
            //    opt.Password.RequireUppercase = false;

            //    opt.User.RequireUniqueEmail = true;

            //    opt.SignIn.RequireConfirmedEmail = true;

            //    opt.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
            //})
            // .AddEntityFrameworkStores<AccountContext>()
            // .AddDefaultTokenProviders();
            //.AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
