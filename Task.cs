using System;
using System.Collections.Generic;

class Task
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }
    public Task Next { get; set; }

    public Task(int taskId, string taskName, int priority, DateTime dueDate)
    {
        TaskId = taskId;
        TaskName = taskName;
        Priority = priority;
        DueDate = dueDate;
        Next = null;
    }
}

class CircularTaskList
{
    private Task head;
    private Task current;

    public void AddAtBeginning(int taskId, string taskName, int priority, DateTime dueDate)
    {
        Task newTask = new Task(taskId, taskName, priority, dueDate);
        if (head == null)
        {
            head = newTask;
            head.Next = head;
            current = head;
            return;
        }

        Task last = head;
        while (last.Next != head)
            last = last.Next;

        newTask.Next = head;
        last.Next = newTask;
        head = newTask;
    }

    public void AddAtEnd(int taskId, string taskName, int priority, DateTime dueDate)
    {
        if (head == null)
        {
            AddAtBeginning(taskId, taskName, priority, dueDate);
            return;
        }

        Task newTask = new Task(taskId, taskName, priority, dueDate);
        Task last = head;
        while (last.Next != head)
            last = last.Next;

        last.Next = newTask;
        newTask.Next = head;
    }

    public void AddAtPosition(int position, int taskId, string taskName, int priority, DateTime dueDate)
    {
        if (position < 1 || head == null)
            return;

        if (position == 1)
        {
            AddAtBeginning(taskId, taskName, priority, dueDate);
            return;
        }

        Task newTask = new Task(taskId, taskName, priority, dueDate);
        Task current = head;
        for (int i = 1; i < position - 1 && current.Next != head; i++)
            current = current.Next;

        newTask.Next = current.Next;
        current.Next = newTask;
    }

    public void RemoveByTaskId(int taskId)
    {
        if (head == null)
            return;

        if (head.TaskId == taskId)
        {
            if (head.Next == head)
            {
                head = null;
                current = null;
                return;
            }

            Task last = head;
            while (last.Next != head)
                last = last.Next;

            head = head.Next;
            last.Next = head;
            if (current.TaskId == taskId)
                current = head;
            return;
        }

        Task prev = head;
        Task curr = head.Next;
        while (curr != head)
        {
            if (curr.TaskId == taskId)
            {
                prev.Next = curr.Next;
                if (current == curr)
                    current = curr.Next;
                return;
            }
            prev = curr;
            curr = curr.Next;
        }
    }

    public Task ViewCurrentTask()
    {
        return current;
    }

    public void MoveToNextTask()
    {
        if (current != null)
            current = current.Next;
    }

    public List<Task> SearchByPriority(int priority)
    {
        List<Task> results = new List<Task>();
        if (head == null)
            return results;

        Task current = head;
        do
        {
            if (current.Priority == priority)
                results.Add(current);
            current = current.Next;
        } while (current != head);

        return results;
    }

    public void DisplayAllTasks()
    {
        if (head == null)
            return;

        Task current = head;
        do
        {
            Console.WriteLine($"Task ID: {current.TaskId}, Name: {current.TaskName}, Priority: {current.Priority}, Due: {current.DueDate:d}");
            current = current.Next;
        } while (current != head);
    }
}

class Program
{
    static void Main()
    {
        CircularTaskList scheduler = new CircularTaskList();
        
        scheduler.AddAtEnd(1, "Complete Report", 1, DateTime.Now.AddDays(1));
        scheduler.AddAtEnd(2, "Review Code", 2, DateTime.Now.AddDays(2));
        scheduler.AddAtBeginning(3, "Team Meeting", 1, DateTime.Now);
        
        Console.WriteLine("All Tasks:");
        scheduler.DisplayAllTasks();
        
        var currentTask = scheduler.ViewCurrentTask();
        Console.WriteLine($"\nCurrent Task: {currentTask.TaskName}");
        
        scheduler.MoveToNextTask();
        currentTask = scheduler.ViewCurrentTask();
        Console.WriteLine($"Next Task: {currentTask.TaskName}");
        
        var highPriorityTasks = scheduler.SearchByPriority(1);
        Console.WriteLine("\nHigh Priority Tasks:");
        foreach (var task in highPriorityTasks)
            Console.WriteLine($"{task.TaskName} (Due: {task.DueDate:d})");
    }
}