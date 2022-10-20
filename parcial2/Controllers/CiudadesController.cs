using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using parcial2.Models;
using System.Text;

namespace parcial2.Controllers
{
    public class CiudadesController : Controller
    {
        // GET: CiudadesController
        public async Task<ActionResult> Index()
        {
            List<Models.CiudadesModel> ciudades = new List<Models.CiudadesModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/ListCiudades/");
            ciudades = JsonConvert.DeserializeObject<List<Models.CiudadesModel>>(json);
            return View(ciudades);
        }

        // GET: CiudadesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/ciudades/" + id);
            Models.CiudadesModel ciudades = JsonConvert.DeserializeObject<CiudadesModel>(json);
            return View(ciudades);
        }

        // GET: CiudadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CiudadesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.CiudadesModel ciudades)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ciudades);
                var data = new StringContent(json, Encoding.UTF8, "Application/json");

                var api = new HttpClient();

                var response = await api.PostAsync("https://localhost:7279/ciudades/", data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CiudadesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/ciudades/" + id);
            Models.CiudadesModel ciudades = JsonConvert.DeserializeObject<CiudadesModel>(json);
            return View(ciudades);
        }

        // POST: CiudadesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.CiudadesModel ciudades)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ciudades);
                var data = new StringContent(json, Encoding.UTF8, "Application/json");

                var api = new HttpClient();

                var response = await api.PutAsync("https://localhost:7279/ciudades/" + ciudades.Id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CiudadesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/ciudades/" + id);
            Models.CiudadesModel ciudades = JsonConvert.DeserializeObject<CiudadesModel>(json);
            return View(ciudades);
        }

        // POST: CiudadesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var api = new HttpClient();
                var response = await api.DeleteAsync("https://localhost:7279/ciudades/" + id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
