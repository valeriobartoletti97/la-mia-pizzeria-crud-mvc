using la_mia_pizzeria_crud_mvc.Data;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(PizzaManager.GetAllPizza());
        }

        public IActionResult GetPizza(int id)
        {
            return View(PizzaManager.GetPizza(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza data)
        {
            if (!ModelState.IsValid)
            {
                // Ritorniamo "data" alla view così che la form abbia di nuovo i dati inseriti
                // (anche se erronei)
                return View("Create", data);
            }

            PizzaManager.AddPizza(data);
            using (PizzaContext db = new PizzaContext())
            {
                var pizza = new Pizza(data.Name, data.Description, data.Image, data.Price);
                db.Pizzas.Add(pizza);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
