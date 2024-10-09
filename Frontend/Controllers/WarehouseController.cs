using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;


namespace Frontend.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly HttpClient _httpClient;
        public WarehouseController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                string apiUrl = "https://localhost:7215/api/Warehouse/get-warehouses";
                var response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var model = System.Text.Json.JsonSerializer.Deserialize<List<Warehouse>>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(model);
                }
                else
                {
                    ViewBag.ErrorMessage = "There was an error fetching data from the API.";
                    return View(new List<MeasurementUnit>());
                }

            }
            catch (Exception ex)
            {

                return View("Error");
            }


        }
        [HttpPost]
        public async Task Create([FromBody] Warehouse warehouse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var jsonData = JsonConvert.SerializeObject(warehouse);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    await _httpClient.PostAsync("https://localhost:7215/api/Warehouse/create-warehouse", content);

                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }
        [HttpPost]
        public async Task Update([FromBody] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(warehouse);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await _httpClient.PostAsync("https://localhost:7215/api/Warehouse/update-warehouse", content);

            }


        }
        [HttpPost]
        public async Task Delete([FromBody] int id)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.DeleteAsync("https://localhost:7215/api/MeasurementUnit/delete-measurement-unit/" + id);
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string apiUrl = $"https://localhost:7215/api/InventoryStock/get-inventories-by-warehouse-id?warehouseId={id}";
                string modelurl = "https://localhost:7215/api/Warehouse/get-warehouses";
                var response = await _httpClient.GetAsync(apiUrl);
                string jsonResponseModel = await GetDatas(modelurl);
                if (response != null || jsonResponseModel != null)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var model = System.Text.Json.JsonSerializer.Deserialize<List<Inventory>>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    var warehouse = System.Text.Json.JsonSerializer.Deserialize<List<Warehouse>>(jsonResponseModel, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View("Details", Tuple.Create(model, warehouse));
                }
                else
                {
                    ViewBag.ErrorMessage = "There was an error fetching data from the API.";
                    return View(new List<Inventory>());
                }

            }
            catch (Exception ex)
            {

                return View("Error");
            }

        }
        public async Task<string> GetDatas(string uri)
        {
            string brandUrl = uri;
            var response = await _httpClient.GetAsync(brandUrl);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            return null;
        }
    }
}
          

    
