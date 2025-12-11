using System.Text.Json;
using System.Net.Http.Json;
using Ajedrez.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ajedrez.Web.Controllers
{
    public class TorneoController : Controller
    {
        private readonly HttpClient _http;

        public TorneoController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        // GET: /Torneo
        public async Task<IActionResult> Index()
        {
            var response = await _http.GetAsync("api/Torneo");

            if (!response.IsSuccessStatusCode)
                return View(new List<TorneoVM>());

            var json = await response.Content.ReadAsStringAsync();
            var torneos = JsonSerializer.Deserialize<List<TorneoVM>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<TorneoVM>();

            return View(torneos);
        }

        // GET: /Torneo/Crear
        [HttpGet]
        public IActionResult Crear()
        {
            return View(new TorneoVM { Fecha = DateTime.Today });
        }

        // POST: /Torneo/Crear
        [HttpPost]
        public async Task<IActionResult> Crear(TorneoVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _http.PostAsJsonAsync("api/Torneo", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al guardar el torneo.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Torneo/Editar/3
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _http.GetAsync($"api/Torneo/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            var json = await response.Content.ReadAsStringAsync();
            var torneo = JsonSerializer.Deserialize<TorneoVM>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (torneo == null)
                return RedirectToAction(nameof(Index));

            return View(torneo);
        }

        // POST: /Torneo/Editar
        [HttpPost]
        public async Task<IActionResult> Editar(TorneoVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _http.PutAsJsonAsync($"api/Torneo/{model.Id}", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al actualizar el torneo.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Torneo/Eliminar/3
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _http.DeleteAsync($"api/Torneo/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}