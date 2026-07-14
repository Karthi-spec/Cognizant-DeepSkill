using RetailInventory.Data;
using RetailInventory.Models;
using var context=new AppDbContext();
var electronics=new Category{Name="Electronics"};
var groceries=new Category{Name="Groceries"};
await context.Categories.AddRangeAsync(electronics,groceries);
await context.Products.AddRangeAsync(
    new Product{Name="Laptop",Price=75000,Category=electronics},
    new Product{Name="Rice Bag",Price=1200,Category=groceries});
await context.SaveChangesAsync();
Console.WriteLine("Data Inserted Successfully");