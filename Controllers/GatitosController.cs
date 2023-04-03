using Microsoft.AspNetCore.Mvc;
using GatitosWebApp.Models;
using GatitosWebApp.Services;

namespace GatitosWebApp.Controllers
{
    public class GatitosController : Controller
    {
        private readonly GatitoService _gatitoService;

        public GatitosController()
        {
            _gatitoService = GatitoService.Instance;
        }
    
        public IActionResult Index()
        {
            var gatitos = _gatitoService.GetAll();
            return View(gatitos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gatito gatito)
        {
            if (ModelState.IsValid)
            {
                _gatitoService.Create(gatito);
                return RedirectToAction(nameof(Index));
            }
            return View(gatito);
        }

        public IActionResult Edit(int id)
        {
            var gatito = _gatitoService.GetById(id);
            if (gatito == null)
            {
                return NotFound();
            }
            return View(gatito);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Gatito gatito)
        {
            if (id != gatito.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _gatitoService.Update(gatito);
                return RedirectToAction(nameof(Index));
            }
            return View(gatito);
        }

        public IActionResult Details(int id)
        {
            var gatito = _gatitoService.GetById(id);
            if (gatito == null)
            {
                return NotFound();
            }
            return View(gatito);
        }

        public IActionResult Delete(int id)
        {
            var gatito = _gatitoService.GetById(id);
            if (gatito == null)
            {
                return NotFound();
            }
            return View(gatito);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _gatitoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

