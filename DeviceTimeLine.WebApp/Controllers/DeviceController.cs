using DataProvider.Abstractions;
using DeviceTimeLine.Abstractions;
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

        // GET: DeviceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeviceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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

        [HttpPost]
        public IActionResult Cancel()
        {
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
