using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_21880067
{
    public class Stack_Double
    {
        public Node head; 
        public Node tail;
        public Stack_Double()
        {
            head = null;
            tail = null;
        }        
        public void Push(double value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }
        public double Pop()
        {
            //if (IsEmpty())
            //{
            //    throw new Exception("Stack is empty!");
            //}
            double value = head.d_value;
            head = head.next;
            return value;
        }
        public double Peek()
        {
            //if (IsEmpty())
            //{
            //    throw new Exception("Stack is empty");
            //}
            return head.d_value;
        }
        public bool IsEmpty()
        {
            if (head == null)
            {                
                return true;
            }
            return false;
            // hoac co the viet return head == null;
        }
        public int Count()
        {
            int count = 0;
            Node currentNodeDD = head;
            while (currentNodeDD != null)
            {
                currentNodeDD = currentNodeDD.next;
                count++;
            }
            return count;
        }
    }
}
