
using System;

public class Round_Robin
{
    // Function to calculate waiting time for each process in Round Robin scheduling
    static void findWaitingTime(int[] processes, int n, int[] bt, int[] wt, int quantum, int[] arrival_time)
    {
        // Create an array to store the remaining burst time for each process
        int[] rem_bt = new int[n];

        // Initialize rem_bt array with the burst times of the processes
        for (int i = 0; i < n; i++)
            rem_bt[i] = bt[i];

        // Initialize time variable to track the total time elapsed
        int t = 0;

        Console.WriteLine();
        Console.WriteLine("Order of execution");

        while (true)
        {
            // Flag to check if all processes are done
            bool done = true;

            for (int i = 0; i < n; i++)
            {
                // Check if the process is not done and has arrived by the current time
                if (rem_bt[i] > 0 && arrival_time[i] <= t)
                {
                    done = false;

                    // If remaining burst time is greater than the quantum, execute for the quantum
                    if (rem_bt[i] > quantum)
                    {
                        t += quantum;
                        rem_bt[i] -= quantum;
                        Console.Write("|p" + processes[i] + "|");
                    }
                    // If remaining burst time is less than or equal to the quantum, execute for the remaining burst time
                    else
                    {
                        t = t + rem_bt[i];
                        wt[i] = t - bt[i] - arrival_time[i];
                        rem_bt[i] = 0;
                        Console.Write("|p" + processes[i] + "|");
                    }
                }
            }

            // If all processes are done, break the loop
            if (done == true)
                break;
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    static void findTurnAroundTime(int[] processes, int n, int[] bt, int[] wt, int[] tat)
    {
        for (int i = 0; i < n; i++)
            tat[i] = bt[i] + wt[i];
    }

    static void findavgTime(int[] processes, int n, int[] bt, int quantum, int[] arrival_time)
    {
        int[] wt = new int[n];
        int[] tat = new int[n];

        // Variables to store total waiting time and total turnaround time
        int total_wt = 0, total_tat = 0;

        findWaitingTime(processes, n, bt, wt, quantum, arrival_time);
        findTurnAroundTime(processes, n, bt, wt, tat);

        // Display the header for the output table
        Console.WriteLine("Processes " + " Burst time " + " Arrival time " + " Waiting time " + " Turn around time");

        for (int i = 0; i < n; i++)
        {
            total_wt = total_wt + wt[i];
            total_tat = total_tat + tat[i];
            Console.WriteLine(" " + (i + 1) + "\t\t" + bt[i] + "\t " + arrival_time[i] + "\t\t " + wt[i] + "\t\t " + tat[i]);
        }

        // Calculate and display average waiting time
        Console.WriteLine("Average waiting time = " + (float)total_wt / (float)n);

        // Calculate and display average turnaround time
        Console.Write("Average turn around time = " + (float)total_tat / (float)n);
    }

    public static void Main()
    {
        int[] processes = { 1, 2, 3 };
        int n = processes.Length;
        int[] burst_time = { 10, 5, 8 };
        int[] arrival_time = { 4, 2, 0 };
        int quantum = 4;

        // Call the function to calculate and display average waiting time and average turnaround time
        findavgTime(processes, n, burst_time, quantum, arrival_time);
    }
}
