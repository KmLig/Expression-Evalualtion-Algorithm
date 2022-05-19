using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_21880067
{
    public class Stack_Char
    {
        Node head;
        Node tail;
        public Stack_Char()
        {
            head = null;
            tail = null;
        }
        
        public void Push(char a_value)
        {
            Node newNode = new Node(a_value);
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
        public char Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty!");
            }
            char value = head.c_value;
            head = head.next;
            return value;
        }
        public char Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }
            return head.c_value;
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
            Node current = head;
            while (current != null)
            {
                current = current.next;
                count++;
            }
            return count;
        }
    }
}
