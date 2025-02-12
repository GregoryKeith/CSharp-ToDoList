using System;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        TaskManagers taskManager = new TaskManagers();
        bool running = true;
        Console.WriteLine("Welcome to the To-Do List App!");

        while (running)
        {
            Console.WriteLine(" \nChose an option:");
            Console.WriteLine("     1. View Task     ");
            Console.WriteLine("     2. Add Task     ");
            Console.WriteLine("     3. Complete Task     ");
            Console.WriteLine("     4. Delete Task     ");
            Console.WriteLine("     5. Exit     ");

            Console.WriteLine("Enter you choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                taskManager.ViewTasks();
                break;

                case "2":   
                Console.Write("Enter task description: ");
                string description = Console.ReadLine();
                taskManager.AddTask(description);
                Console.WriteLine("Got it!");
                break;

                case "3":
                    Console.Write("Enter the task number to complete: ");
                    if (int.TryParse(Console.ReadLine(), out int completeIndex))
                    {
                        taskManager.CompleteTask(completeIndex - 1);
                        Console.WriteLine("Task marked as complete!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "4":
                Console.Write("Enter the task to delete: ");
                if (int.TryParse(Console.ReadLine(), out int completedIndex))
                {
                    taskManager.DeleteTask(completedIndex-1);
                    Console.WriteLine("Task deleted");
                }
                taskManager.ViewTasks();
                break;

                case "5":
                running = false;

                Console.Write("Goodbye!");
                break;

            }
        }
    }
}