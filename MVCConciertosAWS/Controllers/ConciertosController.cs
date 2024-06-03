using Microsoft.AspNetCore.Mvc;
using MVCConciertosAWS.Models;
using MVCConciertosAWS.Services;
using System.Runtime.InteropServices;

namespace MVCConciertosAWS.Controllers
{
    public class ConciertosController : Controller
    {
        private ServiceApiConciertos service;
        private ServiceStorageAWS serviceStorage;



        public ConciertosController(ServiceApiConciertos service, ServiceStorageAWS
        serviceStorage)
        {
            this.service = service;
            this.serviceStorage = serviceStorage;
        }
        public async Task<IActionResult> Index()
        {
            List<Evento> eventos =
            await this.service.GetEventosAsync();
            return View(eventos);
        }

    }
}
