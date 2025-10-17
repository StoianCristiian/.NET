using System;
using System.Collections.Generic;
using System.Linq;

void ShowInfo(object obj)
{
    switch (obj)
    {
        case Task t:
            Console.WriteLine($"Task: {t.Title}, Completed: {t.IsCompleted}");
            break;
        case Project p:
            Console.WriteLine($"Project: {p.Name}, Tasks Count: {p.Tasks.Count}");
            break;
        default:
            Console.WriteLine("Unknown type");
            break;
    }
}


var tasks = new List<Task>
{
    new Task("Task1", false, DateTimeOffset.Now.AddDays(-1)),
    new Task("Task2", false, DateTimeOffset.Now.AddDays(2)),
    new Task("Task3", true, DateTimeOffset.Now.AddDays(5)),
};

Console.Write("Enter a task to complete: ");
var inputTitle = Console.ReadLine();

for (int i = 0; i < tasks.Count; i++)
{
    if (tasks[i].Title.Equals(inputTitle, StringComparison.OrdinalIgnoreCase))
    {
        tasks[i] = tasks[i] with { IsCompleted = true };
        Console.WriteLine($"{tasks[i].Title} marked as completed!");
        break;
    }
}

Console.WriteLine("All tasks: ");
foreach (var task in tasks)
{
    Console.WriteLine($"{task.Title} - Compelted: {task.IsCompleted}");
}

ShowInfo(tasks[0]);
ShowInfo(new Project("Demo", tasks));
ShowInfo("random string");

var overdueTasks = tasks.Where(static task =>
    task.DueDate < DateTimeOffset.Now && !task.IsCompleted);

Console.WriteLine($"Overdue and not completed tasks: ");
foreach (var task in overdueTasks)
{
    Console.WriteLine($"{task.Title} - Due: {task.DueDate}");
}