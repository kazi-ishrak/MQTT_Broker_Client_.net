using Microsoft.AspNetCore.Mvc;
using MQTTBroker2.Models;
using System.Diagnostics;
using MQTTBroker2.Services;
namespace MQTTBroker2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
   
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public async Task<IActionResult> Index()
        {
            await MQTTBrokerService.Run_minimal_server();
            await MQTTSubscriberService.Connect_Client();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
