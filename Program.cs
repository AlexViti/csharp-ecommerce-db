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

    for (int i = 0; i < 5; i++)
    {
        Random rand = new();
        Order order = new()
        {
            CostumerId = rand.Next(1, 3),
            Date = DateTime.Now,
            Status = "Pending",
        };
        List<OrderProduct> orders = new();
        for (int j = 0; j < rand.Next(1, 4); j++)
        {
            Product product = db.Products.First(p => p.Id == j + 1);
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
        db.Orders.Add(order);
        db.OrderProducts.AddRange(orders);
    }

    //db.Orders.First(o => o.Id == 1).Status = "Completed";
    Order? _order = db.Orders.Find(2);
    if (_order != null)
    {
        db.Orders.Remove(_order);
    }

    Product _product = db.Products.Find(db.OrderProducts.First().ProductId);
    db.Products.Remove(_product);
    db.SaveChanges();
}