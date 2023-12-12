using System.ComponentModel.DataAnnotations;

namespace DDD
{
    public class Product
    {
        [Required]
        public string id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
    }
    internal class Order
    {
        public Order(string id, string status, string address, List<Product> products)
        {
            this.id = id;
            this.status = status;
            this.address = address;
            this.products = products;
        }
        [Required]
        public string id { get; set; }
        public string status { get; set; }
        [Required]
        public string address { get; set; }
        [Required, MinLength(1)]
        public List<Product> products { get; set; }

    }
    class OrderFactory
    {
        public Order CreateOrder(string id, string status, string address, List<Product> products)
        {
            return new Order(id, status, address, products);
        }
    }
    class OrderRepository
    {
        public Order GetOrder(string id)
        {
            Product product1 = new Product();
            product1.id = "1";
            product1.name = "Shampoo";
            product1.price = "120 rub";
            List<Product> products = new List<Product>();
            products.Add(product1);
  
            return new Order("1", "Complete", "Ulitsa Pushkina", products);
        }
        public void save(Order order)
        {
            //do something
        }
    }
    class OrderService
    {
        public OrderService(OrderRepository rep)
        {
            this.rep = rep;

        }

        OrderRepository rep;

        public Order CreateOrder(string address, List<Product> products)
        {
            OrderFactory factory = new OrderFactory();
            Order order = factory.CreateOrder(Guid.NewGuid().ToString(), "InProcess", address, products);
            rep.save(order);

            return order;
        }
    }
}
