// See https://aka.ms/new-console-template for more information

using (ShopContext db = new ShopContext())
{
    for (int i = 1; i < 4; i++)
    {
        Product product = new Product
        {
            Name = "Product " + i,
            Price = 10.00M * i,
            Description = "This is a product description"
        };
        db.Products.Add(product);
    }
    db.SaveChanges();
}
