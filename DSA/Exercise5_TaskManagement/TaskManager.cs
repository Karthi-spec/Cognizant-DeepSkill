using System;

namespace Exercise5_TaskManagement
{
    class Task
    {
        public int TaskId;
        public string TaskName;
        public string Status;
        public Task Next;

        public Task(int taskId, string taskName, string status)
        {
            TaskId = taskId;
            TaskName = taskName;
            Status = status;
            Next = null;
        }

        public override string ToString()
        {
            return "Task[id=" + TaskId + ", name=" + TaskName + ", status=" + Status + "]";
        }
    }

    class TaskManager
    {
        Task head = null;

        public void AddTask(int id, string name, string status)
        {
            Task newTask = new Task(id, name, status);
            newTask.Next = head;
            head = newTask;
            Console.WriteLine("Added: " + newTask);
        }

        public Task SearchTask(int id)
        {
            Task current = head;
            while (current != null)
            {
                if (current.TaskId == id) return current;
                current = current.Next;
            }
            return null;
        }

        public void Traverse()
        {
            Console.WriteLine("\n--- Task List (head to tail) ---");
            Task current = head;
            while (current != null)
            {
                Console.WriteLine("  " + current);
                current = current.Next;
            }
            Console.WriteLine("--------------------------------\n");
        }

        public bool DeleteTask(int id)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return false;
            }

            if (head.TaskId == id)
            {
                Console.WriteLine("Deleting head: " + head);
                head = head.Next;
                return true;
            }

            Task current = head;
            while (current.Next != null)
            {
                if (current.Next.TaskId == id)
                {
                    Console.WriteLine("Deleting: " + current.Next);
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            Console.WriteLine("Task ID " + id + " not found.");
            return false;
        }

        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            manager.AddTask(1, "Set up database", "Done");
            manager.AddTask(2, "Build REST API", "In Progress");
            manager.AddTask(3, "Write unit tests", "Pending");
            manager.AddTask(4, "Deploy to staging", "Pending");

            manager.Traverse();

            Task found = manager.SearchTask(2);
            Console.WriteLine("Search: " + (found != null ? found.ToString() : "Not found"));

            manager.DeleteTask(3);
            manager.Traverse();

            Console.WriteLine("=== Complexity Summary ===");
            Console.WriteLine("Add (head) -> O(1)");
            Console.WriteLine("Search     -> O(n)");
            Console.WriteLine("Traverse   -> O(n)");
            Console.WriteLine("Delete     -> O(n)");
            Console.WriteLine("\nNo fixed size needed, unlike an array");
        }
    }
}
