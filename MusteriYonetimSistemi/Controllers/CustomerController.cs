using Microsoft.AspNetCore.Mvc;
using MusteriYonetimSistemi.Models;
using MusteriYonetimSistemi.Models.ViewModels;

namespace MusteriYonetimSistemi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient _httpClient;

        public CustomerController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> AllCustomers()
        {
            return View(await _httpClient.GetFromJsonAsync<List<Customer>>("https://localhost:7225/api/Customer"));
        }



        public async Task<IActionResult> CustomerByID(int CustomerID)
        {
            
            try
            {
                string link = "https://localhost:7225/api/Customer" + "/" + CustomerID;
                var resp = await _httpClient.GetFromJsonAsync<Customer>(link);
                return Json(resp);
            }
            catch (Exception ex)
            {
                ViewBag.customer = "Customer was not found..";
                //log error
                return View();
            }

            
            
        }

        public async Task<IActionResult> CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerViewModel customer)
        {
            
            var postTask = await _httpClient.PostAsJsonAsync<CustomerViewModel>("https://localhost:7225/api/Customer", customer);

            var result = postTask.IsSuccessStatusCode;
            if (result)
            {
                return RedirectToAction("AllCustomers");
            }
            return View();
        }

        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            string link = "https://localhost:7225/api/Customer/" + customer.CustomerID;
            var postTask = await _httpClient.PutAsJsonAsync<Customer>(link, customer);

            var result = postTask.IsSuccessStatusCode;
          
                return RedirectToAction("AllCustomers");
           

        }

        public async Task<IActionResult> DeleteCustomer(int CustomerID)
        {
            try
            {
                string link = "https://localhost:7225/api/Customer/" + CustomerID;
                var postTask = await _httpClient.DeleteFromJsonAsync<bool>(link);
                if (!postTask)
                {
                    throw new Exception("Invalid Id");
                }
            }
            catch (Exception ex)
            {
                ViewBag.customer = "Customer was not found..";
                //log error
                return RedirectToAction("AllCustomers");
            }


            return RedirectToAction("AllCustomers");

        }

        public async Task<IActionResult> ViewOrder(int id)
        {
            try
            {
                string link = "https://localhost:7225/api/Customer" + "/" + id;
                var postTask = await _httpClient.DeleteFromJsonAsync<Customer>(link);
            }
            catch (Exception ex)
            {
                ViewBag.customer = "Customer was not found..";
                //log error
                return RedirectToAction("AllCustomers");
            }


            return RedirectToAction("AllCustomers");

        }
    }
}
