using System;

namespace Exercise2_EcommerceSearch
{
    class Product
    {
        public int ProductId;
        public string ProductName;
        public string Category;

        public Product(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }

        public override string ToString()
        {
            return "Product[id=" + ProductId + ", name=" + ProductName + ", category=" + Category + "]";
        }
    }

    class ProductSearch
    {
        public static Product LinearSearch(Product[] products, string targetName)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (string.Equals(products[i].ProductName, targetName, StringComparison.OrdinalIgnoreCase))
                {
                    return products[i];
                }
            }
            return null;
        }

        public static Product BinarySearch(Product[] sortedProducts, string targetName)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int cmp = string.Compare(sortedProducts[mid].ProductName, targetName, StringComparison.OrdinalIgnoreCase);

                if (cmp == 0)
                    return sortedProducts[mid];
                else if (cmp < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product(1, "Laptop", "Electronics"),
                new Product(2, "Headphones", "Electronics"),
                new Product(3, "Notebook", "Stationery"),
                new Product(4, "Backpack", "Accessories"),
                new Product(5, "Mouse", "Electronics")
            };

            Product[] sortedProducts = (Product[])products.Clone();
            Array.Sort(sortedProducts, (a, b) => string.Compare(a.ProductName, b.ProductName, StringComparison.OrdinalIgnoreCase));

            string target = "Notebook";

            Console.WriteLine("=== Linear Search ===");
            Product result1 = LinearSearch(products, target);
            Console.WriteLine(result1 != null ? "Found: " + result1 : "Not found");

            Console.WriteLine("\n=== Binary Search (sorted array) ===");
            Product result2 = BinarySearch(sortedProducts, target);
            Console.WriteLine(result2 != null ? "Found: " + result2 : "Not found");

            Console.WriteLine("\n=== Complexity Comparison ===");
            Console.WriteLine("Linear Search  - O(n)     - works on any array");
            Console.WriteLine("Binary Search  - O(log n) - requires sorted array");
            Console.WriteLine("For n=1,000,000: linear ~ 1,000,000 steps vs binary ~ 20 steps");
        }
    }
}
