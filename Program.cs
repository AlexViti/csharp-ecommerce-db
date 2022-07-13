/*
using (ShopContext db = new ShopContext())
{
    for (int i = 1; i < 4; i++)
    {
        Product p = new Product
        {
            Name = "Product " + i,
            Price = 10.00M * i,
            Description = "This is a product description"
        };
        db.Products.Add(p);
    }
    db.SaveChanges();

    Costumer costumer = new()
    {
        Name = "Alessio",
        Surname = "Vitiello",
        Email = "avitiello@boolean.edu"
    };

    db.Costumers.Add(costumer);

    costumer = new()
    {
        Name = "Laura",
        Surname = "Margherita",
        Email = "lmargherita@boolean.edu"
    };

    db.Costumers.Add(costumer);
    db.SaveChanges();

    for (int i = 0; i < 5; i++)
    {
        Random rand = new();
        Costumer cost = db.Costumers.OrderBy(c => c.Id).Take(rand.Next(1, db.Costumers.Count())).Last();
        Order order = new()
        {
            Costumer = cost,
            CostumerId = cost.Id,
            Date = DateTime.Now,
            Status = "Pending",
        };
        List<OrderProduct> orders = new();

        List<Product> products = db.Products.ToList();
        for (int j = 0; j < rand.Next(0, products.Count); j++)
        {
            Product product = products[j];
            orders.Add(new OrderProduct
            {
                OrderId = order.Id,
                Order = order,
                ProductId = product.Id,
                Product = product,
                Quantity = rand.Next(1, 5)
            });
        }
        order.Amount = orders.Sum(o => o.Quantity * o.Product.Price);
        order.OrderProducts = orders;
        db.Orders.Add(order);
        db.OrderProducts.AddRange(orders);
    }

    db.SaveChanges();

    /*db.Orders.First(o => o.Id == 1).Status = "Completed";
    Order? _order = db.Orders.Find(2);
    if (_order != null)
    {
        db.Orders.Remove(_order);
    }

    Product _product = db.Products.Find(db.OrderProducts.First().ProductId);
    db.Products.Remove(_product);
    db.SaveChanges();
}
*/

    using (ShopContext db = new ShopContext())
{
    Console.WriteLine("Inserisci il nome dell'utente per vedere i suoi ordini");
    string input = Console.ReadLine();
    Costumer? costumer = db.Costumers.Where(c => c.Name.Contains(input) || c.Surname.Contains(input)).First();
    while (costumer == null)
    {
        Console.WriteLine("Nessun utente trovato");
        input = Console.ReadLine();
        costumer = db.Costumers.Where(c => c.Name.Contains(input) || c.Surname.Contains(input)).First();
    }
    List<Order>? orders = db.Orders.Where(o => o.Costumer == costumer).ToList<Order>();
    if (orders.Count == 0)
        Console.WriteLine("Nessun ordine trovato");
    else
    {
        foreach(Order order in orders)
        {
            Console.WriteLine();
            Console.WriteLine($"Id ordine: {order.Id}");
            Console.WriteLine($"Nome utente:{order.Costumer.Name} {order.Costumer.Surname}");
            Console.WriteLine("Prodotti:");
            foreach (OrderProduct orderProduct in db.OrderProducts.Where(op => op.OrderId == order.Id).ToList())
            {
                Console.WriteLine($"{db.Products.Find(orderProduct.ProductId).Name} - {orderProduct.Quantity}");
            }
        }
    }
}