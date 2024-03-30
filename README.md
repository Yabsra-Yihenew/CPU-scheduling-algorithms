1) FCFS (First-Come, First-Served) is one of the simplest CPU scheduling algorithms used in operating systems. 
  In FCFS scheduling, processes are executed in the order they arrive in the ready queue. 
  When a process enters the ready queue, it is placed at the end of the queue, and the CPU scheduler selects the process at the front of the queue for execution.
  
  The code is written in C# explaining how FCFS algorithm operates and in addition it calculates Turn around time and waiting time for each processes.
  

2) Non-preemptive priority scheduling is a CPU scheduling algorithm where each process is assigned a priority. 
  The CPU scheduler selects the process with the highest priority for execution. In case of ties, FCFS (First-Come, First-Served) order may be used to break the tie.
  
  When a process enters the ready queue, it is placed according to its priority. The CPU scheduler then selects the process with 
  the highest priority from the ready queue for execution. Once a process starts executing, it continues until it either completes its CPU burst. 
  During this time, no other process can preempt it.
  Upon completion of execution the process leaves the CPU, and the scheduler selects the next process with the highest priority from the ready queue.
  
  This scheduling algorithm ensures that higher priority processes are executed first.

3) Preemptive priority scheduling is a C# code implements preemptive priority scheduling for a set of processes. It simulates process execution by selecting the process with the       highest priority at each time step and executing it until completion.

4) Round Robin scheduling C# code demonstrates the Round Robin scheduling algorithm, a preemptive scheduling method commonly used in operating systems. It iterates through processes in a cyclic manner, allocating each a fixed time quantum for execution before moving to the next process. If a process's burst time exceeds the quantum, it's temporarily suspended, allowing other processes to execute. The code calculates and displays the waiting time (time spent waiting in the ready queue) and turnaround time (total time taken from arrival to completion) for each process, along with their averages. It provides insight into how the Round Robin algorithm handles process execution, particularly in scenarios with different arrival times and burst times.

6) Shortest Remaining Time First (SRTF) scheduling algorithm, a preemptive approach where the processor is allocated to the process with the smallest remaining burst time. It initializes a list of processes with arrival times and burst times, sorts them based on arrival times, and iterates through them, selecting eligible processes for execution. The selected process is executed for a time quantum of 1 unit, and if its burst time becomes 0, it's considered completed. The code efficiently handles process execution, prioritizing shorter jobs, and displays information about the selected process being executed. This SRTF algorithm aims to minimize average waiting and turnaround times by dynamically scheduling processes based on their remaining execution times.
