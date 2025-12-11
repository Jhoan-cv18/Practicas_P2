using System.Text.Json;
using Ajedrez.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ajedrez.Web.Controllers
{
    public class PartidaController : Controller
    {
        private readonly HttpClient _http;

        public PartidaController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        // GET: /Partida
        public async Task<IActionResult> Index()
        {
            var response = await _http.GetAsync("api/Partida");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<PartidaVM>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var partidas = JsonSerializer.Deserialize<List<PartidaVM>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(partidas ?? new List<PartidaVM>());
        }

        // GET: /Partida/Crear
        [HttpGet]
        public IActionResult Crear()
        {
            // dejamos la fecha con hoy para que no esté vacío
            return View(new PartidaVM
            {
                Fecha = DateTime.Today
            });
        }

        // POST: /Partida/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(PartidaVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _http.PostAsJsonAsync("api/Partida", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al guardar la partida.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Partida/Editar/5
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _http.GetAsync($"api/Partida/{id}");
            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            var json = await response.Content.ReadAsStringAsync();
            var partida = JsonSerializer.Deserialize<PartidaVM>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (partida == null)
                return RedirectToAction(nameof(Index));

            return View(partida);
        }

        // POST: /Partida/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, PartidaVM model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            // Si tu API NO tiene PUT, comenta esta línea y luego lo vemos.
            var response = await _http.PutAsJsonAsync($"api/Partida/{id}", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al actualizar la partida.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Partida/Eliminar/5
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _http.DeleteAsync($"api/Partida/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}