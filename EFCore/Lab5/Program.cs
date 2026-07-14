using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using var context=new AppDbContext();
var products=await context.Products.ToListAsync();
foreach(var p in products)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");
var product=await context.Products.FindAsync(1);
Console.WriteLine($"Found: {product?.Name}");
var expensive=await context.Products.FirstOrDefaultAsync(p=>p.Price>5000);
Console.WriteLine($"Expensive Product: {expensive?.Name}");