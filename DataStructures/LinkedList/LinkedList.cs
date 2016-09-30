using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T> : A_List<T> where T : IComparable<T>
    {
        #region Attributes
        private Node head;
        #endregion

        public override void Add(T data)
        {
            head = RecAdd(head, data);
        }

        private Node RecAdd(Node current, T data)
        {
            if (current == null)
            {
                current = new Node(data);
            }
            else
            {
                current.next = RecAdd(current.next, data);
            }
            return current;
        }

        public override void Clear()
        {
            this.head = null;
        }

        public override void Insert(int index, T data)
        {
            if(index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            head = RecInsert(index, data, head);
        }

        private Node RecInsert(int index, T data, Node current)
        {
            if(index == 0)
            {
                Node added = new Node(data, current);
                current = added;
            }
            else
            {
                current.next = RecInsert(--index, data, current.next);
            }
            return current;
        }

        public override bool Remove(T data)
        {
            return RecRemove(ref head, data);
                
        }

        private bool RecRemove(ref Node current, T data)
        {
            bool found = false;
            if(current != null)
            {
                if(current.data.Equals(data))
                {
                    current = current.next;
                    found = true;
                }
                else
                {
                    found = RecRemove(ref current.next, data);
                }
            }
            return found;
        }

        public override T RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (head == null)
            {
                throw new ApplicationException();
            }
            return RecRemoveAt(index, ref head);
        }

        private T RecRemoveAt( int index, ref Node current)
        {
            T removedData = default(T);

            if (index == 0)
            {
                //get the original data
                removedData = current.data;
                current = current.next;
            }
            else
            {
                removedData = RecRemoveAt(--index, ref current.next);
            }
            return removedData;
        }

        public override T ReplaceAt(int index, T data)
        {
            if(index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            if(head == null)
            {
                throw new ApplicationException();
            }
            return RecReplaceAt(index, data, head);
        }

        private T RecReplaceAt(int index, T data, Node current)
        {
            T removedData = default(T);
            if (index == 0)
            {
                //get the original data
                removedData = current.data;
                //set current's data to new data
                current.data = data;

            }
            else
            {
                removedData = RecReplaceAt(--index, data, current.next);
            }
            return removedData;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        #region Enumerator Implementation
        private class Enumerator : IEnumerator<T>
        {
            private LinkedList<T> parent;
            private Node lastVisited; //the current node
            private Node scout; //the next node to visit

            public Enumerator(LinkedList<T> parent)
            {
                this.parent = parent;
                Reset();
            }

            public T Current
            {
                get
                {
                    return lastVisited.data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return lastVisited.data;
                }
            }

            public void Dispose()
            {
                parent = null;
                lastVisited = null;
                scout = null;
            }

            public bool MoveNext()
            {
                bool result = false;
                if (scout != null)
                {
                    result = true;
                    lastVisited = scout;
                    scout = lastVisited.next;
                }
                return result;
            }

            public void Reset()
            {
                lastVisited = null;
                scout = parent.head;
            }
        }
        #endregion

        private class Node
        {
            #region Attributes
            public T data;
            public Node next;
            #endregion

            //this is an example of constructor chaining in C#
            public Node(T data ) : this(data, null) { }

            public Node(T data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }
    }
}
