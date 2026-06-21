using System;
using System.Collections.Generic;

namespace Exercise1_Inventory
{
    class Product
    {
        public int ProductId;
        public string ProductName;
        public int Quantity;
        public double Price;

        public Product(int productId, string productName, int quantity, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString()
        {
            return "Product[id=" + ProductId + ", name=" + ProductName + ", qty=" + Quantity + ", price=" + Price.ToString("F2") + "]";
        }
    }

    class InventoryManager
    {
        Dictionary<int, Product> inventory = new Dictionary<int, Product>();

        public void AddProduct(Product product)
        {
            if (inventory.ContainsKey(product.ProductId))
            {
                Console.WriteLine("Product ID " + product.ProductId + " already exists. Use update instead.");
                return;
            }
            inventory[product.ProductId] = product;
            Console.WriteLine("Added: " + product);
        }

        public void UpdateProduct(int productId, int newQuantity, double newPrice)
        {
            if (!inventory.ContainsKey(productId))
            {
                Console.WriteLine("Product ID " + productId + " not found.");
                return;
            }
            Product product = inventory[productId];
            product.Quantity = newQuantity;
            product.Price = newPrice;
            Console.WriteLine("Updated: " + product);
        }

        public void DeleteProduct(int productId)
        {
            if (inventory.ContainsKey(productId))
            {
                Product removed = inventory[productId];
                inventory.Remove(productId);
                Console.WriteLine("Deleted: " + removed);
            }
            else
            {
                Console.WriteLine("Product ID " + productId + " not found.");
            }
        }

        public void DisplayInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }
            Console.WriteLine("\n--- Current Inventory ---");
            foreach (var p in inventory.Values)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("-------------------------\n");
        }

        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();

            manager.AddProduct(new Product(101, "Widget A", 200, 9.99));
            manager.AddProduct(new Product(102, "Widget B", 50, 24.99));
            manager.AddProduct(new Product(103, "Gadget X", 300, 4.49));

            manager.DisplayInventory();

            manager.UpdateProduct(102, 75, 22.99);

            manager.DeleteProduct(103);

            manager.DisplayInventory();

            manager.AddProduct(new Product(101, "Duplicate", 1, 0.01));
        }
    }
}
