using System;
using System.Collections.Generic;

public class Process
{
    public int Id { get; set; }            
    public int ArrivalTime { get; set; }   
    public int BurstTime { get; set; }     
}

public class SJF
{
    public static void Main()
    {
        List<Process> processes = new List<Process>()
        {
            new Process { Id = 1, ArrivalTime = 2, BurstTime = 9 },
            new Process { Id = 2, ArrivalTime = 3, BurstTime = 2 },
            new Process { Id = 3, ArrivalTime = 8, BurstTime = 5 },
            new Process { Id = 4, ArrivalTime = 1, BurstTime = 4 },
            new Process { Id = 5, ArrivalTime = 14, BurstTime = 10 }
        };

        NonPreemptiveSJF(processes);
    }

    public static void NonPreemptiveSJF(List<Process> processes)
    {
        // Initializing a list to track the processes that are currently in execution
        List<Process> currentProcess = new List<Process>();

        // Sorting the processes based on their arrival time for proper scheduling order
        processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));

        // Adding the first process (with the shortest burst time) to the list of current processes
        currentProcess.Add(processes[0]);

        int originalLength = processes.Count;

        // Removing the selected process from the list of all processes
        processes.RemoveAt(0);

        int currentTime = 0;
        currentTime += currentProcess[0].BurstTime;


        for (int i = 0; i < originalLength - 1; i++)
        {
            // Finding processes that are eligible for execution at the current time
            List<Process> eligibleProcesses = new List<Process>();

            foreach (var process in processes)
            {
                // Checking if the process has arrived by the current time
                if (currentTime >= process.ArrivalTime)
                {
                    eligibleProcesses.Add(process);
                }
            }

            // Sorting eligible processes based on their burst time (Shortest Job First)
            eligibleProcesses.Sort((p1, p2) => p1.BurstTime.CompareTo(p2.BurstTime));

            // If there are eligible processes for execution
            if (eligibleProcesses.Count > 0)
            {
                // Adding the process with the shortest burst time to the list of current processes
                currentProcess.Add(eligibleProcesses[0]);

                // Updating the total time elapsed by adding the burst time of the selected process
                currentTime += eligibleProcesses[0].BurstTime;

                // Removing the selected process from the list of all processes
                processes.Remove(eligibleProcesses[0]);
            }
        }

        // Displaying the order in which processes were executed
        foreach (var process in currentProcess)
        {
            Console.WriteLine(process.Id);
        }
    }
}
