using System;

namespace Exercise3_SortingOrders
{
    class Order
    {
        public int OrderId;
        public string CustomerName;
        public double TotalPrice;

        public Order(int orderId, string customerName, double totalPrice)
        {
            OrderId = orderId;
            CustomerName = customerName;
            TotalPrice = totalPrice;
        }

        public override string ToString()
        {
            return "Order[id=" + OrderId + ", customer=" + CustomerName + ", total=" + TotalPrice.ToString("F2") + "]";
        }
    }

    class OrderSorter
    {
        public static void BubbleSort(Order[] orders)
        {
            int n = orders.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                    {
                        Order temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        public static void QuickSort(Order[] orders, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(orders, low, high);
                QuickSort(orders, low, pivotIndex - 1);
                QuickSort(orders, pivotIndex + 1, high);
            }
        }

        static int Partition(Order[] orders, int low, int high)
        {
            double pivot = orders[high].TotalPrice;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (orders[j].TotalPrice <= pivot)
                {
                    i++;
                    Order temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }

            Order temp2 = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = temp2;

            return i + 1;
        }

        static void PrintOrders(Order[] orders)
        {
            foreach (Order o in orders)
                Console.WriteLine("  " + o);
        }

        static void Main(string[] args)
        {
            Order[] original = new Order[]
            {
                new Order(1, "Alice", 250.00),
                new Order(2, "Bob", 89.99),
                new Order(3, "Charlie", 540.50),
                new Order(4, "Diana", 120.75),
                new Order(5, "Eve", 310.20)
            };

            Order[] bubbleOrders = (Order[])original.Clone();
            Console.WriteLine("Before Bubble Sort:");
            PrintOrders(bubbleOrders);
            BubbleSort(bubbleOrders);
            Console.WriteLine("After Bubble Sort (ascending totalPrice):");
            PrintOrders(bubbleOrders);

            Order[] quickOrders = (Order[])original.Clone();
            Console.WriteLine("\nBefore Quick Sort:");
            PrintOrders(quickOrders);
            QuickSort(quickOrders, 0, quickOrders.Length - 1);
            Console.WriteLine("After Quick Sort (ascending totalPrice):");
            PrintOrders(quickOrders);

            Console.WriteLine("\n=== Complexity Comparison ===");
            Console.WriteLine("Bubble Sort: O(n^2) average - only good for tiny data sets");
            Console.WriteLine("Quick Sort:  O(n log n) average - better for real use");
        }
    }
}
