using Microsoft.AspNetCore.Mvc;
using MusteriYonetimSistemi.Models;
using MusteriYonetimSistemi.Models.ViewModels;
using System.Net.Http;

namespace MusteriYonetimSistemi.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;

        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> AllOrders()
        {
            try
            {
                return View(await _httpClient.GetFromJsonAsync<List<CustomerOrderViewModel>>("https://localhost:7225/api/Order"));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }
        public async Task<IActionResult> GetOrderByCustomerID(int CustomerID)
        {
            string link = "https://localhost:7225/api/Order/" + CustomerID;
            try
            {
                return Json(await _httpClient.GetFromJsonAsync<List<Order>>(link));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
