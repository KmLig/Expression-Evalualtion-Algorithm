using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_21880067
{
    public class Queue
    {
        Node head;
        Node tail;
        public Queue()
        {
            head = null;
            tail = null;
        }
        public void Enqueue(double value)
        {
            Node newNode = new Node(value);
            //Kiem tra hang doi day, voi DSLK co the bo qua
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
        }
        public double Dequeue()
        {
            //Kiem tra hang doi rong
            if (IsEmpty())
            {
                throw new Exception("Queue is empty!");
            }
            double value = head.d_value;
            head = head.next;
            return value;
        }
        public double GetHead()
        {
            // Kiem tra hang doi rong
            if (IsEmpty())
            {
                throw new Exception("Queue is empty!");
            }
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
    }
}
