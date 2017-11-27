using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()// 定义web服务器 
                .UseContentRoot(Directory.GetCurrentDirectory())// 用于指定根内容目录
                .UseIISIntegration()// 寄宿在IIS和IIS Express中
                .UseStartup<Startup>()// 指定Startup类
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
