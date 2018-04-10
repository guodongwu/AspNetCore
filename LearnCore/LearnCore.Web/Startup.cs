using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LearnCore.Application;
using LearnCore.Application.UserMapper;
using LearnCore.Core.IRepositories;
using LearnCore.EntityFramework;
using LearnCore.EntityFramework.Repositories;
using LearnCore.Web.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MapperManage.Initialize();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = Configuration.GetConnectionString("MyDbContext");
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("LearnCore.Web")));
            //依赖注入(批量注入问题)
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IUserService, UserService>();
            ServiceRegister.RegisterAssembly(services, "LearnCore.Core");
            ServiceRegister.RegisterAssembly(services, "LearnCore.EntityFramework");
            ServiceRegister.RegisterAssembly(services, "LearnCore.Application");

            services.AddSession();
            services.AddMvc();
            var redisConnection = Configuration["RedisConfig"];
            var redisInstanceName = Configuration["RedisConfig:InstanceName"];
            var sessionOutTime = Configuration.GetValue<int>("RedisConfig:SessionTimeOut");

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = redisConnection;
                options.InstanceName = redisInstanceName;
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

          
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


       
    }
}

