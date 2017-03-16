using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedLists.Single
{
    public class LinkedList<T> where T : IComparable
    {
        public class Node
        {
            public T data;
            public Node next;
        }

        private Node head;
        public LinkedList()
        {
            head = null;
        }

        #region add
        public bool AddFirst(Node data)
        {
            if (head == null)
            {
                head = new Node();
                head = data;
                head.next = null;
            }
            else
            {
                Node temp = new Node();
                temp = data;
                data = head;
                head = temp;
                head.next = data;
            }
            return true;
        }

        public bool AddFirst(T data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node temp = new Node();
                temp.data = data;
                AddFirst(temp);
            }
            return true;
        }

        public bool AddLast(Node data)
        {
            if (head == null)
            {
                head = new Node();
                head = data;
            }
            else
            {
                Node temp = new Node();
                temp = data;
                Node current;
                current = head;
                while (current.next != null)
                {
                    if (current.next != null)
                        current = current.next;
                }

                current.next = temp;
            }
            return true;
        }

        public bool AddLast(T data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node temp = new Node();
                temp.data = data;
                temp.next = null;
                AddLast(temp);
            }
            return true;
        }

        public bool AddAfter(T data, T location)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node temp = new Node();
                temp.data = data;
                temp.next = null;
                Node node;
                node = getNode(location);
                temp.next = node.next;
                node.next = temp;
            }

            return true;
        }

        public bool AddAfter(T data, Node location)
        {
            try
            {
                AddAfter(data, location.data);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool AddBefore(T data, T location)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node temp = new Node();
                temp.data = data;
                temp.next = null;
                Node node;
                node = getPreviousNode(location);
                if (node == null)
                {
                    temp.next = head;
                    head = temp;
                }
                else
                {
                    temp.next = node.next;
                    node.next = temp;
                }
            }

            return true;
        }

        public bool AddBefore(T data, Node location)
        {
            try
            {
                AddBefore(data, location.data);
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region remove
        public bool clear()
        {
            head = null;
            return true;
        }

        public bool removeFirst()
        {
            head = head.next;
            return true;
        }

        public bool removeLast()
        {
            Node lastNode = getLastNode();
            lastNode = getPreviousNode(lastNode.data);
            lastNode.next = null;
            return true;
        }

        public bool remove(Node node)
        {
            Node temp = getPreviousNode(node.data);
            temp.next = node.next;
            return true;
        }

        public bool remove(T node)
        {
            Node temp = getNode(node);
            remove(temp);
            return true;
        }
        #endregion

        #region traverse
        public void traverse()
        {
            Node current;
            current = this.head;
            while (current != null)
            {
                System.Console.WriteLine(current.data);
                current = current.next;
            }
            System.Console.ReadLine();
        }

        public Node getNode(T data)
        {
            Node current;
            current = head;

            while (current.next != null)
            {
                if (current.data.CompareTo(data) == 0)
                {
                    break;
                }
                current = current.next;
            }
            return current;
        }

        public Node getNextNode(T data)
        {
            Node current;
            current = head;

            while (current.next != null)
            {
                if (current.data.CompareTo(data) == 0)
                {
                    current = current.next;
                    break;
                }
                current = current.next;
            }
            return current;
        }

        public Node getPreviousNode(T data)
        {
            Node current;
            current = head;
            Node previous = null;
            while (current.next != null)
            {
                if (current.data.CompareTo(data) == 0)
                {
                    break;
                }
                previous = current;
                current = current.next;
            }
            return previous;
        }

        public Node getLastNode()
        {
            Node current;
            current = this.head;
            while (current.next != null)
            {
                current = current.next;
            }
            return current;
        }
        #endregion
    }
}
