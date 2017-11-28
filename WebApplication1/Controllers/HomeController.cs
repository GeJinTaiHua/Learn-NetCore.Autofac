﻿using Entity;
using IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConnectionStrings _connectionStrings;
        private readonly IMovieListerService _movieListerService;
        private readonly ILogger _logger;

        public HomeController(IOptions<ConnectionStrings> connectionStrings, ILogger<HomeController> logger, IMovieListerService movieListerService)
        {
            this._connectionStrings = connectionStrings.Value;
            this._movieListerService = movieListerService;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            // Autofa
            var manager = AutofacBuild.Get<IDatabaseService>();
            string resultAutofac = manager.Run();

            Task.Run(() => LogWorking("HomeController.Index"));
            return View();
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        private void LogWorking(string info)
        {
            _logger.LogInformation(info);
            _logger.LogWarning("警告信息");
            _logger.LogError("错误信息");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
