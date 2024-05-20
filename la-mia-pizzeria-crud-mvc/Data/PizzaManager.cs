using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_crud_mvc.Data
{
    public static class PizzaManager
    {
        public static int CountPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.Count();
        }
        public static List<Pizza> GetAllPizza()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.ToList();
        }

        public static Pizza GetPizza(int id, bool WithCategories = true)
        {
            using PizzaContext db = new PizzaContext();
            if(WithCategories)
                return db.Pizzas.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();
            return db.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static void AddPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }


        public static bool UpdatePizza(int id, Action<Pizza> edit)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
                return false;

            edit(pizza);

            db.SaveChanges();

            return true;
        }

        public static bool DeletePizza(int id)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = PizzaManager.GetPizza(id);

            if (pizza == null)
                return false;

            db.Pizzas.Remove(pizza);
            db.SaveChanges();

            return true;
        }
        public static List<Category> GetAllCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }

        public static void Seed()
        {
            if(PizzaManager.CountPizzas() == 0)
            {
               PizzaManager.AddPizza(new Pizza("Bufala", "Pomodoro, Mozzarella di Bufala", "bufala.jfif", 10));
               PizzaManager.AddPizza(new Pizza("Diavola", "Pomodoro, Mozzarella di Bufala, Salame", "diavola.jpg", 8));
               PizzaManager.AddPizza(new Pizza("Funghi", "Pomodoro, Funghi", "funghi.jfif", 8));
               PizzaManager.AddPizza(new Pizza("Zucchine", "Zucchine, Mozzarella", "zucchine.jfif", 9));
               PizzaManager.AddPizza(new Pizza("Boscaiola", "Pomodoro, Mozzarella, Funghi", "boscaiola.jpg", 11));
            }
        }
        //public static List<Pizza> ListPizza = new List<Pizza>();
        //public static Pizza CreatePizza(string name, string description, string image, decimal price)
        //{
        //    Pizza pizza = new Pizza(name, description, image, price);
        //    return pizza;
        //}
        //public static void AddPizza(Pizza pizza)
        //{
        //    ListPizza.Add(pizza);
        //}
    }
}
