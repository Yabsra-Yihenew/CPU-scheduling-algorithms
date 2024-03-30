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

   
}
