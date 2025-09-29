using System;

class Program
{
    static void Main()
    {
        // First order
        Address address1 = new Address("123 ED Drive", "Harare", "H", "Zimbabwe");
        Customer customer1 = new Customer("Emmerson Mnagangwa", address1);

        Product product1a = new Product("CPU", "D840", 888.99, 1);
        Product product1b = new Product("Mouse", "M456", 21.50, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1a);
        order1.AddProduct(product1b);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        // Second order
        Address address2 = new Address("456 Nkomo Drive", "Bulawayo", "BYO", "Zimbabwe");
        Customer customer2 = new Customer("Kembo Mohadhi", address2);

        Product product2a = new Product("USB Flash", "K789", 5.00, 1);
        Product product2b = new Product("Screen", "MN012", 30.00, 2);
        Product product2c = new Product("Printer", "U345", 300.00, 3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2a);
        order2.AddProduct(product2b);
        order2.AddProduct(product2c);

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
