using Microsoft.AspNetCore.Mvc;
using Semana10SalesMVC.WEB.Service;

namespace Semana10SalesMVC.WEB.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var customers = await CustomerService.GetAll();
            return View(customers);        
        }
        
    }
}
