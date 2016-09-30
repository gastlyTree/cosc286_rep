using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BST<T> : A_BST<T>, ICloneable where T : IComparable<T>
    {
        public BST()
        {
            //Initialize the root node to an empty tree
            nRoot = null;

            //Set the count
            iCount = 0;
        }

        //A virtual balance method that may be overridden in a child class
        protected virtual Node<T> Balance(Node<T> nCurrent)
        {
            return nCurrent;
        }  

        public override void Add(T data)
        {
            /*
            If the root does not exist
                create new node with data
            Else
                Recursively add to the tree
            Increment the count
            */
            if(nRoot == null)
            {
                nRoot = new Node<T>(data);
            }
            else
            {
                recAdd(data, nRoot);
                nRoot = Balance(nRoot);
            }
            iCount++;

        }

        private void recAdd(T data, Node<T> nCurrent)
        {
            //compare data with nCurrent's data
            int iResult = data.CompareTo(nCurrent.Data);
            //if data is less than current node's data
            if(iResult < 0)
            {
                //if nCurrent's left does not exist
                if(nCurrent.Left == null)
                {
                    //create a new node and assign to current's left child
                    nCurrent.Left = new Node<T>(data);
                }
                else
                {
                    recAdd(data, nCurrent.Left);
                    nCurrent.Left = Balance(nCurrent.Left);
                }
            }
            //else data is equal or greater than current data
            else
            {
                if (nCurrent.Right == null)
                {
                    //create a new node and assign to current's Right child
                    nCurrent.Right = new Node<T>(data);
                }
                else
                {
                    recAdd(data, nCurrent.Right);
                    nCurrent.Right = Balance(nCurrent.Right);
                }
            }
            
        }

        public override void Clear()
        {
            this.nRoot = null;
        }

        public object Clone()
        {
            //BST<T> clone = new BST<T>(); //won't work for avl tree's
            BST<T> clone = (BST<T>)Activator.CreateInstance(this.GetType());
            clone.nRoot = RecClone(this.nRoot);
            clone.iCount = this.iCount;
            return clone;
        }

        private Node<T> RecClone(Node<T> nCurrent)
        {
            Node<T> clonedNode = default(Node<T>);
            if (nCurrent.Left != null)
                clonedNode.Left = RecClone(nCurrent.Left);
            if (nCurrent.Right != null)
                clonedNode.Right = RecClone(nCurrent.Right);
            return clonedNode;


        }

        public override T Find(T data)
        {
            if (nRoot != null)
            {
                return RecFind(nRoot, data);
            }
            else
            {
                throw new ApplicationException("Root is null");
            }
        }

        private T RecFind(Node<T> nCurrent, T data)
        {
            if(nCurrent.Data.Equals(data))
            {
                return nCurrent.Data;
            }
            else if(nCurrent.Isleaf())
            {
                return default(T);
            }
            else
            {
                return RecFind(nCurrent, data);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorDepth(this);
        }

        public override int Height()
        {
            //Initialize to -1 to indicate a tree with no nodes
            int iHeight = -1;
            if(nRoot != null)
            {
                iHeight = RecHeight(nRoot);
            }
            return iHeight;
        }

        protected int RecHeight(Node<T> nCurrent)
        {
            int iHeightLeft = 0;
            int iHeightRight = 0;
            
            if(!nCurrent.Isleaf())
            {
                if (nCurrent.Left != null)
                {
                    iHeightLeft = RecHeight(nCurrent.Left) + 1;
                }
                if (nCurrent.Right != null)
                {
                    iHeightRight = RecHeight(nCurrent.Right) +1;
                }
            }
            int iHeight = 0;
            if(iHeightLeft > iHeightRight)
            {
                iHeight = iHeightLeft;
            }
            else
            {
                iHeight = iHeightRight;
            }
            return iHeight;
            
               
        }

        public void IterateBreadth(ProcessData<T> pd)
        {
            Queue<Node<T>> qNodes = new Queue<Node<T>>();
            Node<T> nCurrent = null;

            if (nRoot != null)
            {
                qNodes.Enqueue(nRoot);
            }

            while(qNodes.Count > 0)
            {
                nCurrent = qNodes.Dequeue();
                //Process the data in the current node
                pd(nCurrent.Data);
                if (nCurrent.Left != null)
                {
                    qNodes.Enqueue(nCurrent.Left);
                }
                if (nCurrent.Right != null)
                {
                    qNodes.Enqueue(nCurrent.Right);
                }
            }

        }

        //does a depth first traversal
        public override void Iterate(ProcessData<T> pd, TRAVERSALORDER to)
        {
            if(nRoot != null)
            {
                RecIterate(nRoot, pd, to);
            }
        }

        private void RecIterate(Node<T> nCurrent, ProcessData<T> pd, TRAVERSALORDER to)
        {
            if(to == TRAVERSALORDER.PRE_ORDER)
            {
                //Process the data
                pd(nCurrent.Data);
            }
            //Recurse left if the child exists
            if(nCurrent.Left != null)
            {
                RecIterate(nCurrent.Left, pd, to);
            }

            if (to == TRAVERSALORDER.IN_ORDER)
            {
                //Process the data
                pd(nCurrent.Data);
            }

            //Recurse right if the child exists
            if (nCurrent.Right != null)
            {
                RecIterate(nCurrent.Right, pd, to);
            }

            if (to == TRAVERSALORDER.POST_ORDER)
            {
                //Process the data
                pd(nCurrent.Data);
            }
        }

        public override bool Remove(T data)
        {
                bool wasRemoved = false;
                nRoot = RecRemove(nRoot, data, ref wasRemoved);
                return wasRemoved;
           
        }

        private Node<T> RecRemove(Node<T> nCurrent, T data, ref bool wasRemoved)
        {
            T tSubstitute = default(T);
            int iCompare = 0;

            if(nCurrent != null)
            {
                iCompare = data.CompareTo(nCurrent.Data);
                if (iCompare < 0 )
                {
                    nCurrent.Left = RecRemove(nCurrent.Left, data, ref wasRemoved);
                    nCurrent.Left = Balance(nCurrent.Left);
                }
                else if(iCompare > 0)
                {
                    nCurrent.Right = RecRemove(nCurrent.Right, data, ref wasRemoved);
                    nCurrent.Right = Balance(nCurrent.Right);
                }
                else
                {
                    wasRemoved = true;
                    if(nCurrent.Isleaf())
                    {
                        iCount--;
                        nCurrent = null;
                        
                    }
                    else
                    {
                        if (nCurrent.Left != null)
                        {
                            tSubstitute = RecFindLargest(nCurrent.Left);
                            nCurrent.Data = tSubstitute;
                            nCurrent.Left = RecRemove(nCurrent.Left, tSubstitute, ref wasRemoved);
                            nCurrent.Left = Balance(nCurrent.Left);
                        }
                        else
                        {
                            tSubstitute = RecFindSmallest(nCurrent.Right);
                            nCurrent.Data = tSubstitute;
                            nCurrent.Left = RecRemove(nCurrent.Right, tSubstitute, ref wasRemoved);
                            nCurrent.Right = Balance(nCurrent.Right);
                        }
                    }
                    
                }
                
            }
            return nCurrent;

        }

        public T FindSmallest()
        {
            if(nRoot != null)
            {
                return RecFindSmallest(nRoot);
            }
            else
            {
                throw new ApplicationException("Root is null");
            }
        }

        private T RecFindSmallest(Node<T> nCurrent)
        {
            T tData = default(T);

                if (nCurrent.Left != null)
                {
                    tData = RecFindSmallest(nCurrent.Left);
                }
                else
                {
                    tData = nCurrent.Data;
                }
                

            return tData;
        }

        public T FindLargest()
        {
            if (nRoot != null)
            {
                return RecFindLargest(nRoot);
            }
            else
            {
                throw new ApplicationException("Root is null");
            }
        }

        private T RecFindLargest(Node<T> nCurrent)
        {
            T tData = default(T);

            if (nCurrent.Right != null)
            {
                tData = RecFindLargest(nCurrent.Right);
            }
            else
            {
                tData = nCurrent.Data;
            }


            return tData;
        }

        #region Enumerator Implementations

        private class EnumeratorBreadth : IEnumerator<T>
        {
            private BST<T> parent = null;
            private Node<T> nCurrent = null;
            private Queue<Node<T>> qNodes = null;

            public EnumeratorBreadth(BST<T> parent)
            {
                this.parent = parent;
                Reset();
            }

            public T Current
            {
                get
                {
                    return nCurrent.Data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return nCurrent.Data;
                }
            }

            public void Dispose()
            {
                parent = null;
                nCurrent = null;
                qNodes = null;

            }
            public bool MoveNext()
            {
                bool bMoved = false;
                if (qNodes.Count > 0)
                {
                    bMoved = true;
                    nCurrent = qNodes.Dequeue();
                    if (nCurrent.Left != null)
                    {
                        qNodes.Enqueue(nCurrent.Left);
                    }
                    if (nCurrent.Right != null)
                    {
                        qNodes.Enqueue(nCurrent.Right);
                    }
                    
                }

                return bMoved;
            }

            public void Reset()
            {
                //Instantiate the stack
                qNodes = new Queue<Node<T>>();
                //Push the root node onto the stack
                if (parent.nRoot != null)
                {
                    qNodes.Enqueue(parent.nRoot);
                }
                //set current to null
                nCurrent = null;

            }
        }

        private class EnumeratorDepth : IEnumerator<T>
        {
            private BST<T> parent = null;
            private Node<T> nCurrent = null;
            private Stack<Node<T>> sNodes = null;

            public EnumeratorDepth(BST<T> parent)
            {
                this.parent = parent;
                Reset();
            }

            public T Current
            {
                get
                {
                    return nCurrent.Data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return nCurrent.Data;
                }
            }

            public void Dispose()
            {
                parent = null;
                nCurrent = null;
                sNodes = null;

            }
            public bool MoveNext()
            {
                bool bMoved = false;
                if(sNodes.Count > 0)
                {
                    bMoved = true;
                    nCurrent = sNodes.Pop();
                    if(nCurrent.Right != null)
                    {
                        sNodes.Push(nCurrent.Right);
                    }
                    if(nCurrent.Left != null)
                    {
                        sNodes.Push(nCurrent.Left);
                    }
                }

                return bMoved;
            }

            public void Reset()
            {
                //Instantiate the stack
                sNodes = new Stack<Node<T>>();
                //Push the root node onto the stack
                if(parent.nRoot != null)
                {
                    sNodes.Push(parent.nRoot);
                }
                //set current to null
                nCurrent = null;

            }
        }


        #endregion
    }
}
