/* This code is made by Anneshu Nag, Student ID- 2210994760  */
/*                    Dated- 28/08/2023                      */

using System;
using System.Collections.Generic;

namespace Vector
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    public class EvenNumberFirstComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A % 2 - B % 2;
        }
    }

    class Tester
    {
        private static bool CheckAscending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] > vector[i + 1]) return false;
            return true;
        }

        private static bool CheckDescending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] < vector[i + 1]) return false;
            return true;
        }

        private static bool CheckEvenNumberFirst(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i]%2 > vector[i + 1]%2) return false;
            return true;
        }

        // /* This is the code for the Quick Sort Algorithm with Random Pivot */
        // public class RandomizedQuickSort : ISorter
        // {
        //     public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        //     {
        //         QuickSort<K>(sequence, comparer, 0, sequence.Length - 1);
        //     }
            
        //     // Recursive QuickSort method
        //     public void QuickSort<K>(K[] sequence, IComparer<K> comparer, int lowest, int highest) where K : IComparable<K>
        //     {
        //         // Base case: only sort if there's more than one element
        //         if (lowest < highest)
        //         {
        //             // Randomly select a pivot index and rearrange elements
        //             int rndIndex = RandomPivoting(sequence, comparer, lowest, highest);
                    
        //             // Recursively sort elements on both sides of the pivot
        //             QuickSort(sequence, comparer, lowest, rndIndex - 1);
        //             QuickSort(sequence, comparer, rndIndex + 1, highest);
        //         }
        //     }

        //     // Random pivot selection and rearrangement
        //     private int RandomPivoting<K>(K[] sequence, IComparer<K> comparer, int lowest, int highest) where K : IComparable<K>
        //     {
        //         Random random = new Random();
        //         int assignRndIdx = random.Next(lowest, highest);
                
        //         K pivot = sequence[assignRndIdx];
        //         sequence[assignRndIdx] = sequence[highest];
        //         sequence[highest] = pivot;

        //         // Call PivotIndex method to find the correct pivot index
        //         return PivotIndex(sequence, comparer, lowest, highest);
        //     }

        //     // Find the correct pivot index
        //     private int PivotIndex<K>(K[] sequence, IComparer<K> comparer, int lowest, int highest) where K : IComparable<K>
        //     {
        //         K pivot = sequence[highest];
        //         K temp;

        //         int pivotIdxValue = lowest;
        //         for (int j = lowest; j < highest; j++)
        //         {
        //             if (comparer.Compare(sequence[j], pivot) <= 0)
        //             {
        //                 temp = sequence[j];
        //                 sequence[j] = sequence[pivotIdxValue];
        //                 sequence[pivotIdxValue] = temp;
        //                 pivotIdxValue++;
        //             }
        //         }
        //         // Place the pivot element at its correct index
        //         sequence[highest] = sequence[pivotIdxValue];
        //         sequence[pivotIdxValue] = pivot;

        //         // Return the pivot index after rearrangement
        //         return pivotIdxValue;
        //     }
        // }

        // /* This is the code for the Merge Sort Algorithm with Recursive (Top-Down) approach */
        // public class MergeSortTopDown : ISorter
        // {
        //     public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        //     {
        //         MergeSort<K>(sequence, comparer);
        //     }

        //     // Recursive (Top-Down) Merge Sort method
        //     private void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        //     {
        //         int arraySize = sequence.Length;
        //         int midPoint = arraySize / 2;

        //         // Base case: If array size is more than 1, divide and sort
        //         if (arraySize > 1)
        //         {
        //             // Create child arrays for left and right subarrays
        //             K[] childArrayLeft = new K[midPoint];
        //             K[] childArrayRight = new K[sequence.Length - midPoint];

        //             // Populate childArrayLeft with elements from the left half of the sequence
        //             for (int i = 0; i < midPoint; i++)
        //             {
        //                 childArrayLeft[i] = sequence[i];
        //             }

        //             // Populate childArrayRight with elements from the right half of the sequence
        //             for (int i = midPoint; i < sequence.Length; i++)
        //             {
        //                 childArrayRight[i - midPoint] = sequence[i];
        //             }

        //             // Recursively sort both child arrays
        //             MergeSort(childArrayLeft, comparer);
        //             MergeSort(childArrayRight, comparer);

        //             // Merge the sorted child arrays back into the parent array
        //             Merge(sequence, comparer, childArrayLeft, childArrayRight);
        //         }
        //     }

        //     // Merge two sorted child arrays into the parent array
        //     private void Merge<K>(K[] parentArray, IComparer<K> comparer, K[] childArrayLeft, K[] childArrayRight) where K : IComparable<K>
        //     {
        //         int childIdxi = 0, childIdxj = 0;

        //         // Merge process: Compare and merge elements from child arrays into the parent array
        //         while (childIdxi + childIdxj < parentArray.Length)
        //         {
        //             if (childIdxj == childArrayRight.Length || (childIdxi < childArrayLeft.Length && comparer.Compare(childArrayLeft[childIdxi], childArrayRight[childIdxj]) < 0))
        //             {
        //                 // If the current element from childArrayLeft is smaller, place it in parentArray
        //                 parentArray[childIdxi + childIdxj] = childArrayLeft[childIdxi++];
        //             }
        //             else
        //             {
        //                 // If the current element from childArrayRight is smaller, place it in parentArray
        //                 parentArray[childIdxi + childIdxj] = childArrayRight[childIdxj++];
        //             }
        //         }
        //     }
        // }

        // /* This is the code for the Merge Sort Algorithm with Iterative (Bottom-Up) approach */
        // public class MergeSortBottomUp : ISorter
        // {
        //     public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        //     {
        //         int actualSize = sequence.Length;
        //         K[] dummyArray = new K[actualSize]; // Temporary array to hold merged elements

        //         // Iterate over different sizes of subarrays for bottom-up merge sort
        //         for (int currentSize = 1; currentSize < actualSize; currentSize *= 2)
        //         {
        //             for (int startIndex = 0; startIndex < actualSize - currentSize; startIndex += currentSize * 2)
        //             {
        //                 int mid = startIndex + currentSize - 1;
        //                 int endIndex = Math.Min(startIndex + currentSize * 2 - 1, actualSize - 1);

        //                 // Merge subarrays into the dummyArray
        //                 Merge(sequence, comparer, dummyArray, startIndex, mid, endIndex);
        //             }
        //         }
        //     }

        //     // Merge two sorted subarrays into the original sequence
        //     private void Merge<K>(K[] sequence, IComparer<K> comparer, K[] mytempArray, int startIdx, int midIdx, int endIdx) where K : IComparable<K>
        //     {
        //         int startArr1 = startIdx;
        //         int startArr2 = midIdx + 1;
        //         int dummyIdx = startIdx;
        //         int finalIdx = endIdx;

        //         // Compare and merge elements from subarrays into the temporary array
        //         while (startArr1 <= midIdx && startArr2 <= finalIdx)
        //         {
        //             if (comparer.Compare(sequence[startArr1], sequence[startArr2]) <= 0)
        //             {
        //                 mytempArray[dummyIdx++] = sequence[startArr1++];
        //             }
        //             else
        //             {
        //                 mytempArray[dummyIdx++] = sequence[startArr2++];
        //             }
        //         }

        //         // Copy remaining elements from the first subarray
        //         while (startArr1 <= midIdx)
        //         {
        //             mytempArray[dummyIdx++] = sequence[startArr1++];
        //         }

        //         // Copy remaining elements from the second subarray
        //         while (startArr2 <= finalIdx)
        //         {
        //             mytempArray[dummyIdx++] = sequence[startArr2++];
        //         }

        //         // Copy elements from the temporary array back to the original sequence
        //         for (dummyIdx = startIdx; dummyIdx <= finalIdx; dummyIdx++)
        //         {
        //             sequence[dummyIdx] = mytempArray[dummyIdx];
        //         }
        //     }
        // }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100+k.Next(900);

            Vector<int> vector = new Vector<int>(problem_size);


            // ------------------ RandomizedQuickSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest A: Sort integer numbers applying RandomizedQuickSort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new RandomizedQuickSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new AscendingIntComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckAscending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest B: Sort integer numbers applying RandomizedQuickSort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new RandomizedQuickSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new DescendingIntComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckDescending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest C: Sort integer numbers applying RandomizedQuickSort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new RandomizedQuickSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new EvenNumberFirstComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckEvenNumberFirst(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ MergeSortTopDown ----------------------------------

            try
            {
                Console.WriteLine("\nTest D: Sort integer numbers applying MergeSortTopDown with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new MergeSortTopDown();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new AscendingIntComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckAscending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest E: Sort integer numbers applying MergeSortTopDown with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new MergeSortTopDown();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new DescendingIntComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckDescending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest F: Sort integer numbers applying MergeSortTopDown with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new MergeSortTopDown();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new EvenNumberFirstComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckEvenNumberFirst(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ MergeSortBottomUp ----------------------------------

            try
            {
                Console.WriteLine("\nTest G: Sort integer numbers applying MergeSortBottomUp with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new MergeSortBottomUp();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new AscendingIntComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckAscending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest H: Sort integer numbers applying MergeSortBottomUp with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new MergeSortBottomUp();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new DescendingIntComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckDescending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest I: Sort integer numbers applying MergeSortBottomUp with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new MergeSortBottomUp();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                vector.Sort(new EvenNumberFirstComparer());
                Console.Write("\nResulting order: ");
                for (int i = 0; i < problem_size; i++)
                {
                    Console.Write(vector[i].ToString());
                    if (i < problem_size - 1) Console.Write(", ");
                }
                if (!CheckEvenNumberFirst(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine("\n :: SUCCESS");
                result = result + "I";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            
            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("\n | This code is made by Anneshu Nag, Student ID- 2210994760 |");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}

/* --------------------------------------------------My Output-----------------------------------------------------
Test A: Sort integer numbers applying RandomizedQuickSort with AscendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995
 :: SUCCESS

Test B: Sort integer numbers applying RandomizedQuickSort with DescendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100
 :: SUCCESS

Test C: Sort integer numbers applying RandomizedQuickSort with EvenNumberFirstComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 958, 596, 100, 722, 312, 236, 780, 724, 752, 122, 772, 966, 120, 263, 995, 175, 333, 213, 299, 511
 :: SUCCESS

Test D: Sort integer numbers applying MergeSortTopDown with AscendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995
 :: SUCCESS

Test E: Sort integer numbers applying MergeSortTopDown with DescendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100
 :: SUCCESS

Test F: Sort integer numbers applying MergeSortTopDown with EvenNumberFirstComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 772, 596, 958, 752, 120, 122, 724, 966, 722, 100, 780, 312, 236, 995, 299, 175, 263, 213, 511, 333
 :: SUCCESS

Test G: Sort integer numbers applying MergeSortBottomUp with AscendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995
 :: SUCCESS

Test H: Sort integer numbers applying MergeSortBottomUp with DescendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100
 :: SUCCESS

Test I: Sort integer numbers applying MergeSortBottomUp with EvenNumberFirstComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 236, 312, 780, 100, 722, 966, 724, 122, 120, 752, 958, 596, 772, 333, 511, 213, 263, 175, 299, 995
 :: SUCCESS


 ------------------- SUMMARY -------------------

 | This code is made by Anneshu Nag, Student ID- 2210994760 |
Tests passed: ABCDEFGHI*/
