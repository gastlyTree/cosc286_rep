using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class AVLT<T> : BST<T> where T:IComparable<T>
    {
        protected override Node<T> Balance(Node<T> nCurrent)
        {
            /*
             newRoot <-- curent node
             if current is not null
                heightDiff <-- get the height difference of current node
                if the tree is unbalanced to the right
                    rightChildDiff <-- get the height difference of current's child
                    if right child is left heavy 
                        newRoot <-- double left on current
                    else 
                        new root <-- single left on current
                else if the tree is unbalanced to the left
                    leftChildDiff <-- get the height difference of currents left child
                    if left child is right heavy
                        newRoot <-- double right on current
                    else
                        newRoot <-- single right on current
              return newRoot
             
             */
            Node<T> newRoot = nCurrent;

            if(nCurrent != null)
            {
                int heightDiff = GetHeightDifference(nCurrent);
                
                if(heightDiff < -1 )
                {


                    if(GetHeightDifference(nCurrent.Right) > 0 )
                    {
                        newRoot = DoubleLeft(nCurrent);
                    }
                    else
                    {
                        newRoot = SingleLeft(nCurrent);
                    }
                }
                else if (heightDiff > 1)
                {


                    if (GetHeightDifference(nCurrent.Left) < 0)
                    {
                        newRoot = DoubleRight(nCurrent);
                    }
                    else
                    {
                        newRoot = SingleRight(nCurrent);
                    }
                }


            }

            return newRoot;
        }

        #region Helper Methods

        /// <summary>
        /// Determines the height difference between left and right child
        /// nodes of the current node
        /// </summary>
        /// <param name="nCurrent">Current node to test height difference</param>
        /// <returns>Positive int meaning left heavy, negative meaning
        ///             right heavy. absolute value is the height diff</returns>
        public int GetHeightDifference(Node<T> nCurrent)
        {
            int iHeightLeft = -1;
            int iHeightRight = -1;
            int iHeightDiff = 0;

            if(nCurrent != null)
            {
                if(nCurrent.Right != null)
                {
                    iHeightRight = RecHeight(nCurrent.Right);
                    
                }
                if(nCurrent.Left != null)
                {
                    iHeightLeft = RecHeight(nCurrent.Left);
                }     
            }
            iHeightDiff = iHeightLeft - iHeightRight;

            return iHeightDiff;
        }

        public void testHeightDiff()
        {
            Console.WriteLine(GetHeightDifference(nRoot));
        }

        #endregion



        #region Rotation Methods

        private Node<T> SingleLeft(Node<T> nOldRoot)
        {
            //Step 1
            Node<T> nNewRoot = nOldRoot.Right;
            //Step 2
            nOldRoot.Right = nNewRoot.Left;
            //Step 3
            nNewRoot.Left = nOldRoot;
            return nNewRoot;

        }

        private Node<T> SingleRight(Node<T> nOldRoot)
        {
            //Step 1
            Node<T> nNewRoot = nOldRoot.Left;
            //Step 2
            nOldRoot.Left = nNewRoot.Right;
            //Step 3
            nNewRoot.Right = nOldRoot;
            return nNewRoot;


        }

        private Node<T> DoubleLeft(Node<T> nOldRoot)
        {

            nOldRoot.Right = SingleRight(nOldRoot.Right);
            return SingleLeft(nOldRoot);

        }

        private Node<T> DoubleRight(Node<T> nOldRoot)
        {

            nOldRoot.Left = SingleLeft(nOldRoot.Left);
            return SingleRight(nOldRoot);

        }

        #endregion
    }
}
