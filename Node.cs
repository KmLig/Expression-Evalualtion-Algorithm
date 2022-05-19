using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_21880067
{
    public class Node
    {
        public double d_value;
        public char c_value;
        public Node next;
        public Node prev;
        public Node(double double_value)
        {
            d_value = double_value;
            next = null;
            prev = null;
        }
        public Node(char char_value)
        {
            c_value = char_value;
            next = null;
            prev = null;
        }
    }
}
