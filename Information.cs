using System;
using System.Collections.Generic;
using System.Text;
namespace HW3
{
    class Node { protected Node next = null; }
    class Information : Node
    {
        public Information Next
        {
            get { return next as Information; }
            set { next = value; }
        }
        public char Instruction;
        public char Data;
        public Information(char instruction, char data)
        {
            Instruction = instruction;
            Data = data;
        }
        public override string ToString()
        {
            return String.Format("{0}{1}", Instruction, Data);
        }
       
    }
}
    
