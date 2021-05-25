using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT.Repo;
using CT.Data.Models;
using CT.Repo.Repositories;
using CT.Services;
using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;

namespace CT.Web
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CollectionTrackerContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<CollectionTrackerContext>()
                .AddUserManager<UserManager<User>>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultTokenProviders();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(INamedService<>), typeof(NamedService<>));
            services.AddScoped(typeof(ICollectibleService<>), typeof(CollectibleService<>));
            services.AddScoped(typeof(ICoinService<>), typeof(CoinService<>));
            services.AddScoped(typeof(IFolderService<>), typeof(FolderService<>));
            services.AddScoped(typeof(ICollectionService<>), typeof(CollectionService<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            /*services.AddTransient<INamedService<Alloy>, NamedService<Alloy>>();
            services.AddTransient<INamedService<Shape>, NamedService<Shape>>();
            services.AddTransient<INamedService<Country>, NamedService<Country>>();
            services.AddTransient<INamedService<Subject>, NamedService<Subject>>();
            services.AddTransient<INamedService<Currency>, NamedService<Currency>>();*/
            services.AddControllers();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
