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
