using Microsoft.AspNetCore.Mvc;
using Semana10SalesMVC.WEB.Models;
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
            return PartialView(customers);        
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(int idCliente, string nombre,
            string apellido, string ciudad, string pais, string telefono)
        {
            var customer = new CustomerModel()
            {
                FirstName = nombre,
                LastName = apellido,
                City = ciudad,
                Country = pais,
                Phone = telefono
            };

            bool exito = true;
            if (idCliente == -1)
                exito = await CustomerService.Insert(customer);
            else {
                customer.Id = idCliente;
                exito = await CustomerService.Update(idCliente, customer);
            }
            return Json(exito);
        }


        
    }
}
