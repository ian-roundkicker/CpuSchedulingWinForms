using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public static class Algorithms
    {
        public static void fcfsAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int npX2 = np * 2;

            double[] bp = new double[np];
            double[] wtp = new double[np];
            string[] output1 = new string[npX2];
            double twt = 0.0, awt; 
            int num;

            DialogResult result = MessageBox.Show("First Come First Serve Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    //MessageBox.Show("Enter Burst time for P" + (num + 1) + ":", "Burst time for Process", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    //Console.WriteLine("\nEnter Burst time for P" + (num + 1) + ":");

                    string input =
                    Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time: ",
                                                       "Burst time for P" + (num + 1),
                                                       "",
                                                       -1, -1);

                    bp[num] = Convert.ToInt64(input);

                    //var input = Console.ReadLine();
                    //bp[num] = Convert.ToInt32(input);
                }

                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        wtp[num] = 0;
                    }
                    else
                    {
                        wtp[num] = wtp[num - 1] + bp[num - 1];
                        MessageBox.Show("Waiting time for P" + (num + 1) + " = " + wtp[num], "Job Queue", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                awt = twt / np;
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + awt + " sec(s)", "Average Awaiting Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (result == DialogResult.No)
            {
                //this.Hide();
                //Form1 frm = new Form1();
                //frm.ShowDialog();
            }
        }

        public static void sjfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] bp = new double[np];
            double[] wtp = new double[np];
            double[] p = new double[np];
            double twt = 0.0, awt; 
            int x, num;
            double temp = 0.0;
            bool found = false;

            DialogResult result = MessageBox.Show("Shortest Job First Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    p[num] = bp[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (p[num] > p[num + 1])
                        {
                            temp = p[num];
                            p[num] = p[num + 1];
                            p[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time:", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + p[num - 1];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void priorityAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            DialogResult result = MessageBox.Show("Priority Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                double[] bp = new double[np];
                double[] wtp = new double[np + 1];
                int[] p = new int[np];
                int[] sp = new int[np];
                int x, num;
                double twt = 0.0;
                double awt;
                int temp = 0;
                bool found = false;
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    string input2 =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter priority: ",
                                                           "Priority for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    p[num] = Convert.ToInt16(input2);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    sp[num] = p[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (sp[num] > sp[num + 1])
                        {
                            temp = sp[num];
                            sp[num] = sp[num + 1];
                            sp[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + bp[temp];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Console.WriteLine("\n\nAverage waiting time: " + (awt = twt / np));
                //Console.ReadLine();
            }
            else
            {
                //this.Hide();
            }
        }

        public static void roundRobinAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int i, counter = 0;
            double total = 0.0;
            double timeQuantum;
            double waitTime = 0, turnaroundTime = 0;
            double averageWaitTime, averageTurnaroundTime;
            double[] arrivalTime = new double[10];
            double[] burstTime = new double[10];
            double[] temp = new double[10];
            int x = np;

            DialogResult result = MessageBox.Show("Round Robin Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (i = 0; i < np; i++)
                {
                    string arrivalInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ",
                                                               "Arrival time for P" + (i + 1),
                                                               "",
                                                               -1, -1);

                    arrivalTime[i] = Convert.ToInt64(arrivalInput);

                    string burstInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                               "Burst time for P" + (i + 1),
                                                               "",
                                                               -1, -1);

                    burstTime[i] = Convert.ToInt64(burstInput);

                    temp[i] = burstTime[i];
                }
                string timeQuantumInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter time quantum: ", "Time Quantum",
                                                               "",
                                                               -1, -1);

                timeQuantum = Convert.ToInt64(timeQuantumInput);
                Helper.QuantumTime = timeQuantumInput;

                for (total = 0, i = 0; x != 0;)
                {
                    if (temp[i] <= timeQuantum && temp[i] > 0)
                    {
                        total = total + temp[i];
                        temp[i] = 0;
                        counter = 1;
                    }
                    else if (temp[i] > 0)
                    {
                        temp[i] = temp[i] - timeQuantum;
                        total = total + timeQuantum;
                    }
                    if (temp[i] == 0 && counter == 1)
                    {
                        x--;
                        //printf("nProcess[%d]tt%dtt %dttt %d", i + 1, burst_time[i], total - arrival_time[i], total - arrival_time[i] - burst_time[i]);
                        MessageBox.Show("Turnaround time for Process " + (i + 1) + " : " + (total - arrivalTime[i]), "Turnaround time for Process " + (i + 1), MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + (i + 1) + " : " + (total - arrivalTime[i] - burstTime[i]), "Wait time for Process " + (i + 1), MessageBoxButtons.OK);
                        turnaroundTime = (turnaroundTime + total - arrivalTime[i]);
                        waitTime = (waitTime + total - arrivalTime[i] - burstTime[i]);                        
                        counter = 0;
                    }
                    if (i == np - 1)
                    {
                        i = 0;
                    }
                    else if (arrivalTime[i + 1] <= total)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                averageWaitTime = Convert.ToInt64(waitTime * 1.0 / np);
                averageTurnaroundTime = Convert.ToInt64(turnaroundTime * 1.0 / np);
                MessageBox.Show("Average wait time for " + np + " processes: " + averageWaitTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + np + " processes: " + averageTurnaroundTime + " sec(s)", "", MessageBoxButtons.OK);
            }
        }
        //new stuff below here
        // ==========================================================
        class Node
        {
            public Node next;
            public Int32 start_time;
            public Int32 burst_time;
            public Int32 remaining_time;
            public static Int32 id_static = 0;
            public Int32 id = ++id_static;
            public Int32 turnaround_time = 0;
            public Int32 waiting_time = 0;

            public Node(Int32 start_time, Int32 burst_time)
            {
                this.start_time = start_time;
                this.burst_time = burst_time;
                this.remaining_time = burst_time;
            }

            //Note: Only use this function on the queue sorted by start_time
            // Fixes inserting before head, properly sorted by start_time
            public Node insertByStart(Int32 start_time, Int32 burst_time)
            {
                if (start_time < this.start_time) // New node should come before current
                {
                    Node newNode = new Node(start_time, burst_time);
                    newNode.next = this;
                    return newNode;
                }
                else
                {
                    if (next == null)
                    {
                        next = new Node(start_time, burst_time);
                    }
                    else
                    {
                        next = next.insertByStart(start_time, burst_time);
                    }
                    return this;
                }
            }


            //Note: Only use this function on the queue sorted by remaining_time
            public Node insertByRemaining(Node node_from_start_queue)
            {
                Node thing_to_return = node_from_start_queue.next;
                if (next == null)
                {
                    next = node_from_start_queue;
                    next.next = null;
                }
                else if (next.remaining_time > node_from_start_queue.remaining_time) // should be >, not <
                {
                    node_from_start_queue.next = next;
                    next = node_from_start_queue;
                }
                else
                {
                    next.insertByRemaining(node_from_start_queue);
                }
                return thing_to_return;
            }

            public static void resetID()
            {
                id_static = 0;
            }

            public LinkedList<ProcessRepresentation> toLinkedList()
            {
                LinkedList<ProcessRepresentation> list = new LinkedList<ProcessRepresentation>();
                for (Node temp = this; temp != null; temp = temp.next)
                {
                    list.AddLast(new ProcessRepresentation(temp));
                }
                return list;
            }
        }

        static Node create_queue(Int32 np)
        {
            Node start_time_queue = null;
            for (Int32 i = 0; i < np; i++)//NOTE, TIME AND UTILIZATION TIME ARE USED AS TEMPORARY VARIABLES, THEIR MAIN PURPOSE APPEARS LATER
            {
                Int32 arr_time = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox(
                    $"Enter arrival time:",
                    $"Arrival time for P{i + 1}",
                    "", -1, -1));
                Int32 burst_time = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox(
                    $"Enter burst time:",
                    $"Burst time for P{i + 1}",
                    "", -1, -1));
                if (start_time_queue == null)
                    start_time_queue = new Node(arr_time, burst_time);
                else
                    start_time_queue = start_time_queue.insertByStart(arr_time, burst_time);
            }
            return start_time_queue;

        }


        public static void SRTFAlgorithm(string userInput)
        {
            /*My notes: 
             * srtf algorithm
             * Two queues
             * one sorted by start time (ascending)
             * one sorted by remaining time (ascending)
             * 
             * Loop until no processes remaining in the start time queue (stq) nor the remaining time queue (rtq):
             * while the first process in stq is the same value as the current time:
             * add the process into the remaining time queue (place it in like the insertion sort)
             * 
             * remaining_time-- on first variable in rtq
             * turnaround time++ on all variables in rtq
             * waiting time++ on all variables after first variable in rtq
             * 
             * sort 1st into rtq
             */
            Int32 time = 0;
            Int32 utilization_time = 0;
            Node start_time_queue;
            Node remaining_time_queue = null;
            LinkedList<ProcessRepresentation> completed_list = new LinkedList<ProcessRepresentation>();
            DialogResult result = MessageBox.Show("Shortest Remaining Task First", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                start_time_queue = create_queue(Convert.ToInt32(userInput));


                //at this point, we have all processes inside the start queue sorted ascendedly by start time
                //this loop is for the whole scheduling process:
                while (start_time_queue != null || remaining_time_queue != null)
                {
                
                    //places the processes that have started into the remaining time queue
                    while (start_time_queue != null && time == start_time_queue.start_time)
                    {
                        if (remaining_time_queue!= null && start_time_queue.remaining_time < remaining_time_queue.remaining_time)
                        {
                            Node temp = start_time_queue;
                            start_time_queue = start_time_queue.next;
                            temp.next = remaining_time_queue;
                            remaining_time_queue = temp;
                        }
                        else if (remaining_time_queue != null)
                        {
                            start_time_queue = remaining_time_queue.insertByRemaining(start_time_queue);
                        }
                        else
                        {
                            remaining_time_queue = start_time_queue;
                            start_time_queue = start_time_queue.next;
                            remaining_time_queue.next = null;
                        }
                        
                    }
                    
                    
                    if (remaining_time_queue != null)
                    {
                        remaining_time_queue.remaining_time--;
                        utilization_time++;
                    }
                    for(Node temp = remaining_time_queue; temp != null; temp = temp.next)
                    {
                        if (temp != remaining_time_queue)
                        {
                            temp.waiting_time++;
                        }
                        temp.turnaround_time++;
                    }
                    if (remaining_time_queue != null && remaining_time_queue.remaining_time == 0)
                    {
                        MessageBox.Show("Turnaround time for Process " + remaining_time_queue.id + " : " + remaining_time_queue.turnaround_time, "Turnaround time for Process " + remaining_time_queue.id, MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + remaining_time_queue.id + " : " + remaining_time_queue.waiting_time, "Wait time for Process " + remaining_time_queue.id, MessageBoxButtons.OK);
                        completed_list.AddLast(new ProcessRepresentation(remaining_time_queue));
                        remaining_time_queue = remaining_time_queue.next;
                    }
                    ++time;
                }
                MessageBox.Show("CPU utilization for all processes " + (100 * (double)utilization_time / time).ToString("F2") + "%");
                MessageBox.Show("Throughput: " + (Convert.ToDouble(userInput) / time).ToString("F2") + " processes per tick");
                MessageBox.Show("Average turnaround time for all processes: " + (completed_list.Sum(x => x.getTurnaroundTime()) / (double) completed_list.Count).ToString("F2") + " ticks");
                MessageBox.Show("Average wait time for all processes: " + (completed_list.Sum(x => x.getWaitingTime()) / (double) completed_list.Count).ToString("F2") + " ticks");
                Node.resetID();
            }
        }

        public static void HRRNAlgorithm(string userInput)
        {
            /*My notes on HRRN:
             * To keep track of:
             * Arrival Time
             * Burst Time
             * Turnaround Time
             * Wait Time
             * System Time
             * Using a LinkedList for active elements because then we won't have to iterate through complete list of elements.
             * Using stq again because it's simple and efficient
             * 
             * while there is at least one element in the LinkedList (I'll call it the active list, AL) or stq
             * if there are no elements in AL
             * system_time=AL.get(0).arrivalTime
             * while (the first element in stq's arrival_time <= system_time)
             * transfer the element from stq to AL, probably using some new method, too (also, set stq to stq.next)
             * element.wait_time+=(system_time-arrivaltime) (Note: this is intended to catch up with wait_time during the previous active process's burst time)
             * get the position of the highest response ratio (probably store it in a temp variable)
             * go to that element, turnaround_time = wait_time + burst_time
             * after storing burst time in a temp variable, kick the element from AL
             * for all elements in AL, wait_time+=temp_burst_time
             * system_time+=temp_burst_time
             */
            DialogResult result = MessageBox.Show("Highest Response Ratio Next", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            Node start_time_queue;
            Int32 time = 0;
            Int32 utilization_time = 0;
            if (result == DialogResult.Yes)
            {
                //for the first thing being entered into the queue
                start_time_queue = create_queue(Convert.ToInt32(userInput));
                Node.resetID();
                LinkedList<ProcessRepresentation> active_list = new LinkedList<ProcessRepresentation>();
                LinkedList<ProcessRepresentation> stq_list = start_time_queue.toLinkedList();
                LinkedList<ProcessRepresentation> completed_list = new LinkedList<ProcessRepresentation>();
                while (active_list.Count > 0 || stq_list.Count > 0)
                {
                    //make sure that the system time is at least the arrival time of the first process in stq, unless the first process in stq should already be in AL
                    if (active_list.Count == 0 && stq_list.First().getArrivalTime() > time)
                    {
                        time = stq_list.First().getArrivalTime();
                    }
                    while (stq_list.Count > 0 && stq_list.First().getArrivalTime() <= time) //add all elements into AL where arrival time <= system time
                    {
                        active_list.AddLast(stq_list.First());
                        stq_list.RemoveFirst(); //remove from stq
                        //catch up with missed wait time, this should be 0 if system time = arrival time, so processes not playing "catch up" should not be affected
                        active_list.Last().wait(time - active_list.Last().getArrivalTime());
                    }
                    if (active_list.Count > 0) //something is bursting if we are in here
                    {
                        ProcessRepresentation highest_response_ratio = active_list.First(); //pointer to the element in AL with the highest response ratio
                        foreach (ProcessRepresentation process in active_list)
                        {
                            if (1.0+(double) process.getWaitingTime()/process.getBurstTime() > 1.0+(double) highest_response_ratio.getWaitingTime()/highest_response_ratio.getBurstTime())
                            {
                                highest_response_ratio = process;
                            }
                        }
                        active_list.Remove(highest_response_ratio); //remove the element from AL so that we can iterate through the rest of the elements in a bit
                        highest_response_ratio.burst(highest_response_ratio.getBurstTime());
                        completed_list.AddLast(highest_response_ratio);
                        foreach (ProcessRepresentation process in active_list)
                        {
                            process.wait(highest_response_ratio.getBurstTime());
                        }
                        time += highest_response_ratio.getBurstTime();
                        utilization_time += highest_response_ratio.getBurstTime();
                        MessageBox.Show("Turnaround time for Process " + highest_response_ratio.getID() + " : " + highest_response_ratio.getTurnaroundTime(), "Turnaround time for Process " + highest_response_ratio.getID(), MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + highest_response_ratio.getID() + " : " + highest_response_ratio.getWaitingTime(), "Wait time for Process " + highest_response_ratio.getID(), MessageBoxButtons.OK);
                    }
                }
                MessageBox.Show("CPU utilization for all processes " + (100* (double) utilization_time /time).ToString("F2")+"%");
                MessageBox.Show("Throughput: " + (Convert.ToDouble(userInput) / time).ToString("F2")+" processes per tick");
                MessageBox.Show("Average turnaround time for all processes: " + (completed_list.Sum(x => x.getTurnaroundTime()) / (double)completed_list.Count).ToString("F2") + " ticks");
                MessageBox.Show("Average wait time for all processes: " + (completed_list.Sum(x => x.getWaitingTime()) / (double)completed_list.Count).ToString("F2") + " ticks");
            }
        }

        //represents a process
        class ProcessRepresentation
        {
            private Int32 arrival_time;
            private Int32 burst_time;
            private Int32 turnaround_time;
            private Int32 wait_time;
            private Int32 id;
            //since we are only using processes from the start time queue, we can use the node from the stq in the contructor
            public ProcessRepresentation(Node input)
            {
                this.arrival_time = input.start_time;
                this.burst_time = input.burst_time;
                turnaround_time = input.turnaround_time;
                wait_time = input.waiting_time;
                id = input.id;
            }

            public Int32 getTurnaroundTime()
            {
                return turnaround_time;
            }

            public Int32 getID()
            {
                return id;
            }

            public Int32 getArrivalTime()
            {
                return arrival_time;
            }

            public Int32 getBurstTime()
            {
                return burst_time;
            }

            public Int32 getWaitingTime()
            {
                return wait_time;
            }

            public void wait(Int32 time)
            {
                wait_time += time;
                turnaround_time += time;
            }

            public void burst(Int32 time)
            {
                turnaround_time += time;
            }
        }

    }
}

