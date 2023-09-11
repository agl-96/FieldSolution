using FieldSolution.Models;
using FieldSolution.Models.Contract;
using FieldSolution.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FieldSolution.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService )
        {
            _customerService = customerService;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/")
            };
        }
        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.Get();
            return View(customers);
        }

        // GET: CustomerController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var flag = await _customerService.Delete(id);
            return View();
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool flag=await _customerService.Create(customer);
                if (flag)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View(customer);
        }

        // GET: CustomerController1/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var data = await _customerService.GetCustomerById(id);
            return  View(data);
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer customer)
        {
            try
            {
                var flag = await _customerService.Edit(id,customer);
                if (flag)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var flag=await _customerService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
