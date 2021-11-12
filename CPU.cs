using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class CPU
    {
        private Information root = null;
        public void Push(Information newinformation)
        {
            newinformation.Next = root;
            root = newinformation;
        }
        public Information Pop()
        {
           Information information = root;
            root = root.Next;
            information.Next = null;
            return information;
        }
        public String Get(int index)
        {
            Information information = root;
            while (index > 0)
            {
                if (information == null)
                {
                    throw new IndexOutOfRangeException();
                }
                information = information.Next;
                index--;
            }
            return String.Format("{0}",information); ;
        }
    }
}
