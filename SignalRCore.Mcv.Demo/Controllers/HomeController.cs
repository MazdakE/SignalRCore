using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRCore.Mcv.Demo.Hubs;
using SignalRCore.Mcv.Demo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRCore.Mcv.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<WeatherHub> _weatherHubContext;
        public HomeController(ILogger<HomeController> logger, IHubContext<WeatherHub> weatherHubContext)
        {
            _logger = logger;
            _weatherHubContext = weatherHubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _weatherHubContext
                .Clients
                .All
                .SendAsync("Broadcast", $"Privacy page was visited at: {DateTime.Now}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
