/* This code is made by Anneshu Nag, Student ID- 2210994760  */
/*                    Dated- 28/08/2023                      */

using System;
using System.Collections.Generic;

namespace Vector
{
    /* This is the code for the Merge Sort Algorithm with Iterative (Bottom-Up) approach */
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int actualSize = sequence.Length;
            K[] dummyArray = new K[actualSize]; // Temporary array to hold merged elements

            // Iterate over different sizes of subarrays for bottom-up merge sort
            for (int currentSize = 1; currentSize < actualSize; currentSize *= 2)
            {
                for (int startIndex = 0; startIndex < actualSize - currentSize; startIndex += currentSize * 2)
                {
                    int mid = startIndex + currentSize - 1;
                    int endIndex = Math.Min(startIndex + currentSize * 2 - 1, actualSize - 1);

                    // Merge subarrays into the dummyArray
                    Merge(sequence, comparer, dummyArray, startIndex, mid, endIndex);
                }
            }
        }

        // Merge two sorted subarrays into the original sequence
        private void Merge<K>(K[] sequence, IComparer<K> comparer, K[] mytempArray, int startIdx, int midIdx, int endIdx) where K : IComparable<K>
        {
            int startArr1 = startIdx;
            int startArr2 = midIdx + 1;
            int dummyIdx = startIdx;
            int finalIdx = endIdx;

            // Compare and merge elements from subarrays into the temporary array
            while (startArr1 <= midIdx && startArr2 <= finalIdx)
            {
                if (comparer.Compare(sequence[startArr1], sequence[startArr2]) <= 0)
                {
                    mytempArray[dummyIdx++] = sequence[startArr1++];
                }
                else
                {
                    mytempArray[dummyIdx++] = sequence[startArr2++];
                }
            }

            // Copy remaining elements from the first subarray
            while (startArr1 <= midIdx)
            {
                mytempArray[dummyIdx++] = sequence[startArr1++];
            }

            // Copy remaining elements from the second subarray
            while (startArr2 <= finalIdx)
            {
                mytempArray[dummyIdx++] = sequence[startArr2++];
            }

            // Copy elements from the temporary array back to the original sequence
            for (dummyIdx = startIdx; dummyIdx <= finalIdx; dummyIdx++)
            {
                sequence[dummyIdx] = mytempArray[dummyIdx];
            }
        }
    }
}