using DataProvider.Abstractions;
using DeviceTimeLine.Abstractions;
using DeviceTimeLine.Models;
using DeviceTimeLine.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceTimeLine.WebApp.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IDeviceService _deviceService;
        public DeviceController(
            ILogger<DeviceController> logger, 
            IDeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }

        public async Task<IActionResult> DeviceTimeStatus()
        {
            var deviceTimeStatusList = await _deviceService.GetDeviceTimeStatusListAsync();

            return View(deviceTimeStatusList);
        }

        // GET: DeviceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeviceViewModel device)
        {
            try
            {
                _deviceService.CreateDeviceAsync(device);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                _logger.LogError("Problems creating device");
                return View();
            }
        }

        public ActionResult AddDeviceTimeStatus()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDeviceTimeStatus(DeviceTimeStatus deviceTimeStatus)
        {
            try
            {
                _deviceService.AddDeviceTimeStatusAsync(deviceTimeStatus);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                _logger.LogError("Problems creating device");
                return View();
            }
        }

        // GET: DeviceController/Delete/5
        public IActionResult Delete(string id)
        {
            if (id.Equals(Guid.Empty)) return NotFound();

            _deviceService.DeleteDeviceAsync(id);

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult DeleteTimeStatus(string id)
        {
            if (id.Equals(Guid.Empty)) return NotFound();

            _deviceService.DeleteDeviceTimeStatusAsync(id);

            return RedirectToAction(nameof(DeviceTimeStatus));
        }

        [HttpPost]
        public IActionResult Cancel()
        {
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
