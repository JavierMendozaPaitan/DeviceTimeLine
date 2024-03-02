using System.Diagnostics;
using DeviceTimeLine.Abstractions;
using DeviceTimeLine.Models;
using DeviceTimeLine.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceTimeLine.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITimeLineService _timeLineService;

        public HomeController(
            ILogger<HomeController> logger,
            ITimeLineService timeLineService)
        {
            _logger = logger;
            _timeLineService = timeLineService;
        }

        public async Task<IActionResult> Index()
        {
            var deviceTimeLine = await _timeLineService.GetDeviceTimeLineAsync();

            return View(deviceTimeLine);
        }


        
    }
}
