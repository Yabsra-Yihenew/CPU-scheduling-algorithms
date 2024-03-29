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


import pandas as pd
import nltk
import re
from nltk.corpus import stopwords
""""""""from nltk.stem.porter import PorterStemmer""""""""""""""""

# Download NLTK stopwords if not already downloaded
nltk.download('stopwords')

# Read the CSV file
file_path = r'/Gaming_comments_sentiments_from_Reddit(Dataset).csv'
df = pd.read_csv(file_path)

# Data Cleaning
# Remove stop words
stop_words = set(stopwords.words('english'))
df['Comment'] = df['Comment'].apply(lambda x: ' '.join([word for word in x.split() if word.lower() not in stop_words]))
df['sentiment'] = df['sentiment'].apply(lambda x: ' '.join([word for word in x.split() if word.lower() not in stop_words]))

# Remove special characters
df['Comment'] = df['Comment'].apply(lambda x: re.sub(r'[^a-zA-Z0-9\s]', '', x))
df['sentiment'] = df['sentiment'].apply(lambda x: re.sub(r'[^a-zA-Z0-9\s]', '', x))

# Remove rows where either 'Comment' or 'sentiment' column contains null values
df.dropna(subset=['Comment', 'sentiment'], inplace=True)


# Convert the sentiment column to numeric values
sentiment_mapping = {'positive': 1, 'negative': -1, 'neutral': 0}
df['sentiment'] = df['sentiment'].map(sentiment_mapping)

# Removing duplicates
df.drop_duplicates(inplace=True)

#df['sentiment'].value_counts()
# Define the file path for the cleaned data
#cleaned_file_path = r'/ST/cleaned_data.csv'

# Save the cleaned DataFrame to a new CSV file
#df.to_csv(cleaned_file_path, index=False)

#print("Cleaned data saved successfully.")

--------------------------------------------------------------------------------------



#stemming contents of the comment section
df['stemmed_content'] = df['Comment'].apply(stemming)
print(df['stemmed_content'])
