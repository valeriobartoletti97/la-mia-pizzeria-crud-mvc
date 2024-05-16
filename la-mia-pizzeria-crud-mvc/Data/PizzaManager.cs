namespace la_mia_pizzeria_crud_mvc.Data
{
    public static class PizzaManager
    {

        public static List<Pizza> GetAllPizza()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.ToList();
        }

        public static Pizza GetPizza(int id)
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.FirstOrDefault(p  => p.Id == id);
        }

        public static void AddPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
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
