using System;
using System.Collections.Generic;

class Process
{
    public int ProcessId { get; set; }
    public int BurstTime { get; set; }
    public int RemainingTime { get; set; }
    public int Priority { get; set; }
    public int WaitingTime { get; set; }
    public int TurnaroundTime { get; set; }
    public Process Next { get; set; }

    public Process(int processId, int burstTime, int priority)
    {
        ProcessId = processId;
        BurstTime = burstTime;
        RemainingTime = burstTime;
        Priority = priority;
        WaitingTime = 0;
        TurnaroundTime = 0;
        Next = null;
    }
}

class RoundRobinScheduler
{
    private Process head;
    private Process tail;
    private int timeQuantum;
    private int completedProcesses;
    private int totalProcesses;

    public RoundRobinScheduler(int quantum)
    {
        timeQuantum = quantum;
        completedProcesses = 0;
        totalProcesses = 0;
    }

    public void AddProcess(int processId, int burstTime, int priority)
    {
        Process newProcess = new Process(processId, burstTime, priority);
        totalProcesses++;

        if (head == null)
        {
            head = tail = newProcess;
            newProcess.Next = head;
            return;
        }

        tail.Next = newProcess;
        newProcess.Next = head;
        tail = newProcess;
    }

    public void RemoveProcess(Process process)
    {
        if (head == null) return;

        if (head == tail)
        {
            head = tail = null;
            return;
        }

        Process current = head;
        while (current.Next != process)
            current = current.Next;

        if (process == head)
            head = head.Next;
        if (process == tail)
            tail = current;

        current.Next = process.Next;
        completedProcesses++;
    }

    public void RunScheduler()
    {
        int currentTime = 0;
        Process current = head;
        List<Process> completed = new List<Process>();

        while (completedProcesses < totalProcesses)
        {
            if (current == null) break;

            Console.WriteLine($"\nTime {currentTime}: Executing Process {current.ProcessId}");
            DisplayQueue();

            if (current.RemainingTime <= timeQuantum)
            {
                currentTime += current.RemainingTime;
                current.RemainingTime = 0;
                current.TurnaroundTime = currentTime;
                current.WaitingTime = current.TurnaroundTime - current.BurstTime;
                completed.Add(current);
                Process toRemove = current;
                current = current.Next;
                RemoveProcess(toRemove);
            }
            else
            {
                currentTime += timeQuantum;
                current.RemainingTime -= timeQuantum;
                Process temp = current;
                current = current.Next;
            }
        }

        DisplayStatistics(completed);
    }

    public void DisplayQueue()
    {
        if (head == null) return;

        Process current = head;
        do
        {
            Console.WriteLine($"Process {current.ProcessId}: Remaining Time = {current.RemainingTime}");
            current = current.Next;
        } while (current != head);
    }

    private void DisplayStatistics(List<Process> completed)
    {
        double avgWaitingTime = completed.Average(p => p.WaitingTime);
        double avgTurnaroundTime = completed.Average(p => p.TurnaroundTime);

        Console.WriteLine("\nFinal Statistics:");
        Console.WriteLine($"Average Waiting Time: {avgWaitingTime:F2}");
        Console.WriteLine($"Average Turnaround Time: {avgTurnaroundTime:F2}");

        Console.WriteLine("\nPer Process Statistics:");
        foreach (var process in completed)
        {
            Console.WriteLine($"Process {process.ProcessId}:");
            Console.WriteLine($"  Waiting Time: {process.WaitingTime}");
            Console.WriteLine($"  Turnaround Time: {process.TurnaroundTime}");
        }
    }
}

class Program
{
    static void Main()
    {
        RoundRobinScheduler scheduler = new RoundRobinScheduler(3);
        
        scheduler.AddProcess(1, 8, 1);
        scheduler.AddProcess(2, 4, 2);
        scheduler.AddProcess(3, 6, 1);
        
        Console.WriteLine("Starting Round Robin Scheduling...");
        scheduler.RunScheduler();
    }
}