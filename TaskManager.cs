using System;
using System.ComponentModel;
using System.Dynamic;
using Microsoft.VisualBasic;
public class TaskItem
{
    public string taskDescription { get; set;}
    public bool isComplete { get; set; }

    public TaskItem (string description){
        taskDescription = description;
        isComplete = false;
    }

    public override string ToString()
    {
        return isComplete ? $"[X] {taskDescription}" : $"[] {taskDescription}";
    }
}

public class TaskManagers
{
    private List<TaskItem> tasks = new List<TaskItem>();
    private readonly string filePath = "tasks.txt";
    
    public TaskManagers()
    {
        LoadTasks();
    }

    private void LoadTasks()
    {
        if(File.Exists(filePath))
        {
            string [] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length ==2)
                {
                    TaskItem task = new TaskItem(parts[1])
                    {
                        isComplete = bool.Parse(parts[0])
                    };
                    tasks.Add(task);
                }
            }
        }
    }

    private void SaveTasks()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var task in tasks)
            {
                writer.WriteLine($" {task.isComplete} | {task.taskDescription} ");
            }
        }
    }

    public void AddTask(string description)
    {
        tasks.Add(new TaskItem(description));
        SaveTasks();
    }

    public void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i+1}. {tasks[i]}");
        }
    }

    public void CompleteTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].isComplete = true;
            SaveTasks();
        }
        else
        {Console.WriteLine("Invalid Task");
        }
    }

    public void DeleteTask(int index)
    {
        if (index>=0 && index <= tasks.Count)
        {
        tasks.RemoveAt(index);
        SaveTasks();
        }
        else
        {
            Console.WriteLine("Invalid Task number.");
        }
    }
}