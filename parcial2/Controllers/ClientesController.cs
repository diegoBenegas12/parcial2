using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using parcial2.Models;
using System.Collections.Generic;
using System.Text;

namespace parcial2.Controllers
{
    public class ClientesController : Controller
    {
        // GET: ClientesController
        public async Task<ActionResult> Index()
        {
            List<Models.ClientesModel> clientes = new List<Models.ClientesModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/ListClientes/");
            clientes = JsonConvert.DeserializeObject<List<Models.ClientesModel>>(json);
            return View(clientes);
        }


        // GET: ClientesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/clientes/"+id);
            Models.ClientesModel clientes = JsonConvert.DeserializeObject<ClientesModel>(json);
            return View(clientes);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.ClientesModel cliente)
        {
            try
            {
                cliente.FechaNacimiento = TimeZoneInfo.ConvertTimeToUtc((DateTime)cliente.FechaNacimiento); //conversion a utc datetime
                var json = JsonConvert.SerializeObject(cliente);
                var data = new StringContent(json, Encoding.UTF8, "Application/json");

                var api = new HttpClient();

                var response = await api.PostAsync("https://localhost:7279/clientes/", data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/clientes/" + id);
            Models.ClientesModel clientes = JsonConvert.DeserializeObject<ClientesModel>(json);
            return View(clientes);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.ClientesModel cliente)
        {
            try
            {
                cliente.FechaNacimiento = TimeZoneInfo.ConvertTimeToUtc((DateTime)cliente.FechaNacimiento); //conversion a utc datetime
                var json = JsonConvert.SerializeObject(cliente);
                var data = new StringContent(json, Encoding.UTF8, "Application/json");

                var api = new HttpClient();

                var response = await api.PutAsync("https://localhost:7279/clientes/" + cliente.Id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/clientes/" + id);
            Models.ClientesModel clientes = JsonConvert.DeserializeObject<ClientesModel>(json);
            return View(clientes);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                
                var api = new HttpClient();
                var response = await api.DeleteAsync("https://localhost:7279/clientes/" + id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> getCiudades()
        {
            List<Models.CiudadesModel> clientes = new List<Models.CiudadesModel>();
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7279/ListCiudades/");
            clientes = JsonConvert.DeserializeObject<List<Models.CiudadesModel>>(json);

            return new JsonResult(clientes);
        }
    }
}
