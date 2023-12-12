using System.ComponentModel.DataAnnotations;

namespace DDD
{
    public class MyType
    { }
    internal class Customer
    {
        public Customer(string id, string cardType, string payMethod)
        {
            this.id = id;
            this.cardType = cardType;
            this.payMethod = payMethod;

        }
        [Required]
        public string id { get; set; }
        public string cardType { get; set; }
        public string payMethod { get; set; }

    }
    class CustomerFactory
    {
        public Customer CreateCustomer(string id, string cardType, string payMethod) {
            return new Customer(id, cardType, payMethod);
        }
    }
    class CustomerRepository
    {
        public Customer GetCustomer(string id)
        {
            return new Customer(id, "MasterCard", "SberBank Online");
        }
    }

}
