using System;
using System.Collections.Generic;

class Process
{
    public string Name { get; set; }
    public int ArrivalTime { get; set; }
    public int BurstTime { get; set; }
}

class Program
{
    static void Main()
    {
        List<Process> processes = new List<Process>
        {
            new Process { Name = "P1", ArrivalTime = 1, BurstTime = 10 },
            new Process { Name = "P2", ArrivalTime = 0, BurstTime = 5 },
            new Process { Name = "P3", ArrivalTime = 2, BurstTime = 8 },
        };

        // Sort the processes based on arrival time (FCFS)
        processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));

        Console.WriteLine("FCFS Scheduling:");

        int currentTime = 0;
        int turnAroundTime = 0;
        int waitingTime = 0;

        Console.WriteLine("Processes\t" + "Arrival Time\t" + "Burst time\t" + "Turn around time\t" + "Waiting time");
        foreach (var process in processes)
        {

            Console.Write(process.Name);
            Console.Write("\t\t" + process.ArrivalTime);
            Console.Write("\t\t" + process.BurstTime );

            currentTime += process.BurstTime;
            turnAroundTime = currentTime - process.ArrivalTime;
            waitingTime = turnAroundTime - process.BurstTime;
            Console.Write("\t\t" + turnAroundTime);
            Console.Write("\t\t\t" + waitingTime + "\n");
        }
    }
}

