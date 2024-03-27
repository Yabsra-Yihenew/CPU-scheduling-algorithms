using System;
using System.Collections.Generic;

public class Process
{
    public int Id { get; set; }            
    public int ArrivalTime { get; set; }   
    public int BurstTime { get; set; }     
    public int Priority { get; set; }   
}

public class PreemptivePriorityScheduler
{
    public static void Main()
    {
        List<Process> processes = new List<Process>()
        {
            new Process { Id = 1, ArrivalTime = 2, BurstTime = 9, Priority = 3 },
            new Process { Id = 2, ArrivalTime = 3, BurstTime = 2, Priority = 1 },
            new Process { Id = 3, ArrivalTime = 0, BurstTime = 5, Priority = 2 },
            new Process { Id = 4, ArrivalTime = 1, BurstTime = 4, Priority = 4 },
            new Process { Id = 5, ArrivalTime = 14, BurstTime = 10, Priority = 5 }
        };

        PreemptivePriorityScheduling(processes);
    }

    public static void PreemptivePriorityScheduling(List<Process> processes)
    {
        // Initializing a list to track the processes that are currently in execution
        List<Process> currentProcess = new List<Process>();

        // Sorting the processes based on their arrival time for proper scheduling order
        processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));

        int totalTime = 0;

        // Looping until all processes are executed
        while (currentProcess.Count < processes.Count)
        {
            // Finding processes that are eligible for execution at the current time
            List<Process> eligibleProcesses = new List<Process>();

            foreach (var process in processes)
            {
                // Checking if the process has arrived and is not already in execution
                if (process.ArrivalTime <= totalTime && !currentProcess.Contains(process))
                {
                    eligibleProcesses.Add(process);
                }
            }

            // If there are eligible processes for execution
            if (eligibleProcesses.Count > 0)
            {
                // Sorting eligible processes based on their priority
                eligibleProcesses.Sort((p1, p2) => p1.Priority.CompareTo(p2.Priority));

                // Selecting the process with the highest priority
                Process selectedProcess = eligibleProcesses[0];

                // Displaying information about the execution of the selected process
                if (currentProcess.Count == 0 || currentProcess[0].Id != selectedProcess.Id)
                {
                    Console.WriteLine("Executing process " + selectedProcess.Id);
                }

                totalTime += 1;  // Assuming time quantum is 1 unit for simplicity
                selectedProcess.BurstTime -= 1;

                // If the selected process has completed its execution, add it to the list of executed processes
                if (selectedProcess.BurstTime == 0)
                {
                    currentProcess.Add(selectedProcess);
                }
            }
            else
            {
                totalTime++;  // Incrementing time if no process is eligible for execution at the current time
            }
        }
        
    }
}



