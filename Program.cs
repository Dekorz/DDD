using DDD;
using System.ComponentModel.DataAnnotations;

CustomerRepository customerRepository = new CustomerRepository();
OrderRepository orderRepository = new OrderRepository();

Customer customer = customerRepository.GetCustomer("1");

Order order = orderRepository.GetOrder("1");

Console.WriteLine("Метод оплаты: " + customer.payMethod + ", Тип карты: " + customer.cardType);
Console.WriteLine("Адрес доставки: " + order.address + ", Товары: " + String.Join(",", order.products.Select(p => p.name)));
Console.WriteLine();

OrderService orderService = new OrderService(orderRepository);

Product product1 = new Product();
product1.id = "2";
product1.name = "Banana";
product1.price = "60 rub";
List<Product> products = new List<Product>();
products.Add(product1);

Order someNewOrder = orderService.CreateOrder("Moscow, some place", products);

var results = new List<ValidationResult>();
var context = new ValidationContext(someNewOrder);
if (Validator.TryValidateObject(someNewOrder, context, results, true))
{
    Console.WriteLine("Вау! Проверка объекта!");
    Console.WriteLine("Адрес доставки: " + someNewOrder.address);
    Console.WriteLine("Товары: " + String.Join(",", someNewOrder.products.Select(p => p.name)));
}
else
{
    foreach (var error in results)
    {
        Console.WriteLine(error.ErrorMessage);
    }
}
Console.WriteLine();

Order someNewOrderForError = orderService.CreateOrder("", products);

var results1 = new List<ValidationResult>();
var context1 = new ValidationContext(someNewOrderForError);

if (Validator.TryValidateObject(someNewOrderForError, context1, results1, true))
{
    Console.WriteLine("Вау! Проверка объекта!");
    Console.WriteLine("Адрес доставки: " + someNewOrderForError.address);
    Console.WriteLine("Товары: " + String.Join(",", someNewOrderForError.products.Select(p => p.name)));
}
else
{
    foreach (var error in results1)
    {
        Console.WriteLine(error.ErrorMessage);
        Console.WriteLine("Копипаста - плохо!");
    }
}
