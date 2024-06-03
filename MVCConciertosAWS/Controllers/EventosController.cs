using Microsoft.AspNetCore.Mvc;
using MVCConciertosAWS.Models;
using MVCConciertosAWS.Services;

namespace MVCConciertosAWS.Controllers
{
    public class EventosController : Controller
    {
        private ServiceApiConciertos service;
        private ServiceStorageAWS serviceStorage;

        public EventosController(ServiceApiConciertos service, ServiceStorageAWS serviceStorage)
        {
            this.service = service;
            this.serviceStorage = serviceStorage;
        }

        public async Task<IActionResult> Eventos()
        {
            List<Evento> peliculas = await this.service.GetEventosAsync();
            return View(peliculas);
        }

        public async Task<IActionResult> Categorias()
        {
            List<Categoriaevento> categorias = await this.service.GetCategoriasAsync();
            return View(categorias);
        }


        public IActionResult EventosCategoria()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EventosCategoria(int idcategoria)
        {
            List<Evento> eventos =
                await this.service.GetEventosCategoria(idcategoria);
            return View(eventos);
        }





    }
}
