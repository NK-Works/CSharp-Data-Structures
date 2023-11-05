/* This code is made by Anneshu Nag, Student ID- 2210994760  */
/*                    Dated- 28/08/2023                      */

using System;
using System.Collections.Generic;

namespace Vector
{
    /* This is the code for the Merge Sort Algorithm with Recursive (Top-Down) approach */
    public class MergeSortTopDown : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            MergeSort<K>(sequence, comparer);
        }

        // Recursive (Top-Down) Merge Sort method
        private void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int arraySize = sequence.Length;
            int midPoint = arraySize / 2;

            // Base case: If array size is more than 1, divide and sort
            if (arraySize > 1)
            {
                // Create child arrays for left and right subarrays
                K[] childArrayLeft = new K[midPoint];
                K[] childArrayRight = new K[sequence.Length - midPoint];

                // Populate childArrayLeft with elements from the left half of the sequence
                for (int i = 0; i < midPoint; i++)
                {
                    childArrayLeft[i] = sequence[i];
                }

                // Populate childArrayRight with elements from the right half of the sequence
                for (int i = midPoint; i < sequence.Length; i++)
                {
                    childArrayRight[i - midPoint] = sequence[i];
                }

                // Recursively sort both child arrays
                MergeSort(childArrayLeft, comparer);
                MergeSort(childArrayRight, comparer);

                // Merge the sorted child arrays back into the parent array
                Merge(sequence, comparer, childArrayLeft, childArrayRight);
            }
        }

        // Merge two sorted child arrays into the parent array
        private void Merge<K>(K[] parentArray, IComparer<K> comparer, K[] childArrayLeft, K[] childArrayRight) where K : IComparable<K>
        {
            int childIdxi = 0, childIdxj = 0;

            // Merge process: Compare and merge elements from child arrays into the parent array
            while (childIdxi + childIdxj < parentArray.Length)
            {
                if (childIdxj == childArrayRight.Length || (childIdxi < childArrayLeft.Length && comparer.Compare(childArrayLeft[childIdxi], childArrayRight[childIdxj]) < 0))
                {
                    // If the current element from childArrayLeft is smaller, place it in parentArray
                    parentArray[childIdxi + childIdxj] = childArrayLeft[childIdxi++];
                }
                else
                {
                    // If the current element from childArrayRight is smaller, place it in parentArray
                    parentArray[childIdxi + childIdxj] = childArrayRight[childIdxj++];
                }
            }
        }
    }
}
