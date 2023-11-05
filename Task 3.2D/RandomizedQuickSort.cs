/* This code is made by Anneshu Nag, Student ID- 2210994760  */
/*                    Dated- 28/08/2023                      */

using System;
using System.Collections.Generic;

namespace Vector
{
    /* This is the code for the Quick Sort Algorithm with Random Pivot */
    public class RandomizedQuickSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            QuickSort<K>(sequence, comparer, 0, sequence.Length - 1);
        }
        
        // Recursive QuickSort method
        public void QuickSort<K>(K[] sequence, IComparer<K> comparer, int lowest, int highest) where K : IComparable<K>
        {
            // Base case: only sort if there's more than one element
            if (lowest < highest)
            {
                // Randomly select a pivot index and rearrange elements
                int rndIndex = RandomPivoting(sequence, comparer, lowest, highest);
                
                // Recursively sort elements on both sides of the pivot
                QuickSort(sequence, comparer, lowest, rndIndex - 1);
                QuickSort(sequence, comparer, rndIndex + 1, highest);
            }
        }

        // Random pivot selection and rearrangement
        private int RandomPivoting<K>(K[] sequence, IComparer<K> comparer, int lowest, int highest) where K : IComparable<K>
        {
            Random random = new Random();
            int assignRndIdx = random.Next(lowest, highest);
            
            K pivot = seql.gnRndIdx] = sequence[highest];
            sequence[highest] = pivot;

            // Call PivotIndex method to find the correct pivot index
            return PivotIndex(sequence, comparer, lowest, highest);
        }

        // Find the correct pivot index
        private int PivotIndex<K>(K[] sequence, IComparer<K> comparer, int lowest, int highest) where K : IComparable<K>
        {
            K pivot = sequence[highest];
            K temp;

            int pivotIdxValue = lowest;
            for (int j = lowest; j < highest; j++)
            {
                if (comparer.Compare(sequence[j], pivot) <= 0)
                {
                    temp = sequence[j];
                    sequence[j] = sequence[pivotIdxValue];
                    sequence[pivotIdxValue] = temp;
                    pivotIdxValue++;
                }
            }
            // Place the pivot element at its correct index
            sequence[highest] = sequence[pivotIdxValue];
            sequence[pivotIdxValue] = pivot;

            // Return the pivot index after rearrangement
            return pivotIdxValue;
        }
    }
}