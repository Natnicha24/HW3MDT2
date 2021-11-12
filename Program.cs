using System;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            string information = "", checkinputcpu1 = "", checkinputcpu2="", checkinputcpu3="", checkinputcpu4="";
            int i = 1, nof1 = 0, nof2 = 0, nof3 = 0, nof4 = 0, countinformation = 0;
            char instruction, data;
            CPU cpu1 = new CPU();
            CPU cpu2 = new CPU();
            CPU cpu3 = new CPU();
            CPU cpu4 = new CPU();
            CPU cpu5 = new CPU();
            CPU waitlist = new CPU();
            Information informationlist;

            while (true)
            {
              
                    information = Console.ReadLine();
                countinformation++;
                instruction = information[0];
                if (instruction == '?')
                {
                    break;
                }
                data = information[1];
                informationlist = new Information(instruction, data);
                    checkinputcpu1 = cpu1.Get(0);
                checkinputcpu2 = cpu2.Get(0);
                checkinputcpu3 = cpu3.Get(0);
                checkinputcpu4 = cpu4.Get(0);

                    if (nof1 == 0 || checkinputcpu1[0] == instruction)
                    {
                        if (nof1 < 3)
                        {
                            cpu1.Push(informationlist);
                            nof1++;
                            nof1 = CheckConditionCPU(nof1, cpu1, information);
                        }
                        else
                        {
                            waitlist.Push(informationlist);
                            CheckConditionWaitlist(nof1, cpu1, information, waitlist);
                        }
                    }


                    else if (nof2 == 0 || checkinputcpu2[0] == instruction)
                    {
                        if (nof2 < 3)
                        {
                            cpu2.Push(informationlist);
                            nof2++;
                            nof2 = CheckConditionCPU(nof2, cpu2, information);
                        }
                        else
                        {
                            waitlist.Push(informationlist);
                            CheckConditionWaitlist(nof2, cpu2, information, waitlist);
                        }
                    }

                    else if (nof3 == 0 || checkinputcpu3[0] == instruction)
                    {
                        if (nof3 < 3)
                        {
                            cpu3.Push(informationlist);
                            nof3++;
                            nof3 = CheckConditionCPU(nof3, cpu3, information);
                        }
                        else
                        {
                            waitlist.Push(informationlist);
                            CheckConditionWaitlist(nof3, cpu3, information, waitlist);
                        }
                    }

                    else if (nof4 == 0 || checkinputcpu4[0] == instruction)
                    {
                        if (nof4 < 3)
                        {
                            cpu4.Push(informationlist);
                            nof4++;
                            nof4 = CheckConditionCPU(nof4, cpu4, information);
                        }
                        else
                        {
                            waitlist.Push(informationlist);
                            CheckConditionWaitlist(nof4, cpu4, information, waitlist);
                        }
                    }
                    else
                    {
                        for (int n = nof1; n > 0; n--)
                        {
                            cpu1.Pop();
                        }
                        for (int n = nof2; n > 0; n--)
                        {
                            cpu2.Pop();
                        }
                        for (int n = nof3; n > 0; n--)
                        {
                            cpu3.Pop();
                        }
                        for (int n = nof4; n > 0; n--)
                        {
                            cpu4.Pop();
                        }
                        i++;
                    }
           }
            Console.WriteLine("CPU cycles needed: {0}",i);
        }
        static int CheckConditionCPU(int nofcpu, CPU cpunumber, string information)
        {
            string check = "";
            for (int n = nofcpu - 1; n > 0; n--)
            {
                check = cpunumber.Get(n);
                if (check == information)
                {
                    nofcpu--;
                    cpunumber.Pop();
                    break;

                }

            }
            return nofcpu;
        }
        static void CheckConditionWaitlist(int nofcpu, CPU cpunumber, string information, CPU waitlist)
        {
            string check = "";
            for (int n = 0; n < nofcpu; n++)
            {
                check = cpunumber.Get(n);
                if (check == information)
                {
                    waitlist.Pop();
                }
            }
        }
    }
}

