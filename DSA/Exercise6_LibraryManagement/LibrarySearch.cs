using System;

namespace Exercise6_LibraryManagement
{
    class Book
    {
        public int BookId;
        public string Title;
        public string Author;

        public Book(int bookId, string title, string author)
        {
            BookId = bookId;
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return "Book[id=" + BookId + ", title=\"" + Title + "\", author=" + Author + "]";
        }
    }

    class LibrarySearch
    {
        public static Book LinearSearchByTitle(Book[] books, string target)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (string.Equals(books[i].Title, target, StringComparison.OrdinalIgnoreCase))
                {
                    return books[i];
                }
            }
            return null;
        }

        public static Book BinarySearchByTitle(Book[] sortedBooks, string target)
        {
            int left = 0;
            int right = sortedBooks.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int cmp = string.Compare(sortedBooks[mid].Title, target, StringComparison.OrdinalIgnoreCase);

                if (cmp == 0)
                    return sortedBooks[mid];
                else if (cmp < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book(1, "The Alchemist", "Paulo Coelho"),
                new Book(2, "Clean Code", "Robert C. Martin"),
                new Book(3, "Atomic Habits", "James Clear"),
                new Book(4, "Deep Work", "Cal Newport"),
                new Book(5, "Thinking Fast and Slow", "Daniel Kahneman")
            };

            Book[] sortedBooks = (Book[])books.Clone();
            Array.Sort(sortedBooks, (a, b) => string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase));

            string target = "Atomic Habits";

            Console.WriteLine("=== Linear Search ===");
            Book r1 = LinearSearchByTitle(books, target);
            Console.WriteLine(r1 != null ? "Found: " + r1 : "Not found");

            Console.WriteLine("\n=== Binary Search ===");
            Book r2 = BinarySearchByTitle(sortedBooks, target);
            Console.WriteLine(r2 != null ? "Found: " + r2 : "Not found");

            Console.WriteLine("\n=== Algorithm Guide ===");
            Console.WriteLine("Small, unsorted    -> Linear search");
            Console.WriteLine("Large, sorted      -> Binary search");
            Console.WriteLine("Large, unsorted    -> Sort once, then binary");
        }
    }
}
