// See https://aka.ms/new-console-template for more information

using (ShopContext db = new ShopContext())
{
    /*    for (int i = 1; i < 4; i++)
        {
            Product product = new Product
            {
                Name = "Product " + i,
                Price = 10.00M * i,
                Description = "This is a product description"
            };
            db.Products.Add(product);
        }
        db.SaveChanges();*/

/*    Costumer costumer = new()
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

    db.SaveChanges();*/

    
    for(int i = 0; i < 5; i++)
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
            Product product = db.Products.First(p => p.Id == j+1);
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
    db.SaveChanges();
}