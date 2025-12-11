using System.Text.Json;
using System.Net.Http.Json;
using Ajedrez.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ajedrez.Web.Controllers
{
    public class JugadorController : Controller
    {
        private readonly HttpClient _http;

        public JugadorController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        // GET: /Jugador
        public async Task<IActionResult> Index()
        {
            var response = await _http.GetAsync("api/Jugador");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<JugadorVM>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var jugadores = JsonSerializer.Deserialize<List<JugadorVM>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<JugadorVM>();

            return View(jugadores);
        }

        // GET: /Jugador/Crear
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        // POST: /Jugador/Crear
        [HttpPost]
        public async Task<IActionResult> Crear(JugadorVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _http.PostAsJsonAsync("api/Jugador", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al guardar el jugador.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Jugador/Editar/5
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _http.GetAsync($"api/Jugador/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            var json = await response.Content.ReadAsStringAsync();
            var jugador = JsonSerializer.Deserialize<JugadorVM>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (jugador == null)
                return RedirectToAction(nameof(Index));

            return View(jugador);
        }

        // POST: /Jugador/Editar
        [HttpPost]
        public async Task<IActionResult> Editar(JugadorVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _http.PutAsJsonAsync($"api/Jugador/{model.Id}", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al actualizar el jugador.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Jugador/Eliminar/2
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _http.DeleteAsync($"api/Jugador/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
