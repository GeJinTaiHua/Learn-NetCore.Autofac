using Autofac;
using Autofac.Extensions.DependencyInjection;
using Entity;
using Host;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace WebApplication1
{
    /// <summary>
    /// 定义请求处理管道和配置应用需要的服务
    /// </summary>
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            // 添加系统配置 
            services.Configure<AppSettings>(o =>
            {
                o.AzureStorageAccountContainer = "A";
                o.StorageConnectionString = "S";
            });
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            // 注册日志
            services.AddLogging(o =>
            {
                o
                    .AddConfiguration(Configuration.GetSection("Logging"))
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddConsole();
            });

            services.AddMvc();

            // 引入Autofac
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacModule>();
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
            AutofacBuild.Set(this.ApplicationContainer);
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        /// <summary>
        /// his method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // UseDirectoryBrowser 和 UseStaticFiles 可能会泄密
            // 启用静态文件服务
            app.UseStaticFiles(new StaticFileOptions()
            {
                // 添加新的(位于web root的外部)Resourcesd的静态文件目录
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Style"),
                // 把不能识别的类型和文件作为图片处理(开启 ServeUnknownFileTypes 存在安全风险，请打消这个念头)
                ServeUnknownFileTypes = true,
                DefaultContentType = "image/png"
            });

            // 允许直接浏览目录wwwroot\images
            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images")),
                RequestPath = new PathString("/MyImages")
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
