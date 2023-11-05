/* This code is made by Anneshu Nag, Student ID- 2210994760  */
/*                    Dated- 26/08/2023                      */

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

    /* This is the code for Bubble Sort Algorithm*/
    public class BubbleSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            // If there is no element in the array then do this 
            if (sequence.Length == 0) return;  

            // Outer loop for the passes (Length - 1) times or (1 to length)
            for (int i = 1; i < sequence.Length; i++)
            {
                // Inner loop iterates over the unsorted part of the sequence (Length  - i)
                for (int j = 0; j < sequence.Length - i; j++)
                {
                    // Compare the current element with the next element
                    if (comparer.Compare(sequence[j], sequence[j + 1]) > 0)
                    {
                        // If the current element is greater than the next element, swap them to move the larger element towards the end
                        K tempStore = sequence[j];
                        sequence[j] = sequence[j + 1];
                        sequence[j + 1] = tempStore;
                    }
                }
            }
        }
    }
/* This is the code for Selection Sort Algorithm*/
    public class SelectionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            // If there is no element in the array then do this 
            if (sequence.Length == 0) return;  

            // Outer loop iterates for the passes
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                int baseIdx = i; // Index of the current "minimum" element

                // Getting the index of the minimum element in the unsorted array
                for (int j = i + 1; j < sequence.Length; j++)
                {
                    if (comparer.Compare(sequence[baseIdx],sequence[j]) > 0)
                    {
                        baseIdx = j;   // Update the index of the minimum element
                    }
                }

                // If the current minimum element is not at its correct position (i), swap it with the element at index i
                if (baseIdx != i)
                {
                    K tempStore = sequence[i];
                    sequence[i] = sequence[baseIdx];
                    sequence[baseIdx] = tempStore;
                }
            }
        }
    }
    /* This is the code for Insertion Sort Algorithm*/
    public class InsertionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            // If there is no element in the array then do this 
            if (sequence.Length == 0) return;  

            // Outer loop iterates passes
            for (int i = 1; i < sequence.Length; i++)
            {
                K nextElement = sequence[i];
                int j = i - 1;

                // Move elements that are greater than 'nextElement' one position to the right until we find the correct position for 'nextElement'
                while (j >= 0 && comparer.Compare(sequence[j], nextElement) > 0)
                {
                    sequence[j + 1] = sequence[j];   // Move the element to the right
                    j--;   // Move one position to the left
                }

                // Place 'nextElement' in its correct sorted position
                sequence[j + 1] = nextElement;
            }
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
                if (vector[i] % 2 > vector[i + 1] % 2) return false;
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100 + k.Next(900);

            Vector<int> vector = new Vector<int>(problem_size);

            // ------------------ Default Sort ----------------------------------
            try
            {
                Console.WriteLine("\nTest A: Sort integer numbers applying Default Sort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = null;
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.Write("Intital data: ");   // Changes done here as the given code was not printing the array and was showing 'Vector.Vector`1[System.Int32]' instead of the array
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
                Console.WriteLine("\nTest B: Sort integer numbers applying Default Sort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = null;
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
                Console.WriteLine("\nTest C: Sort integer numbers applying Default Sort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = null;
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



            // ------------------ BubbleSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest D: Sort integer numbers applying BubbleSort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new BubbleSort();
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
                Console.WriteLine("\nTest E: Sort integer numbers applying BubbleSort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new BubbleSort();
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
                Console.WriteLine("\nTest F: Sort integer numbers applying BubbleSort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new BubbleSort();
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
                    Console.Write(vector[i].ToString());   // This result doesn't match with the result given but the test is showing Success
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



            // ------------------ SelectionSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest G: Sort integer numbers applying SelectionSort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new SelectionSort();
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
                Console.WriteLine("\nTest H: Sort integer numbers applying SelectionSort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new SelectionSort();
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
                Console.WriteLine("\nTest I: Sort integer numbers applying SelectionSort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new SelectionSort();
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



            // ------------------ InsertionSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest J: Sort integer numbers applying InsertionSort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new InsertionSort();
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
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest K: Sort integer numbers applying InsertionSort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new InsertionSort();
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
                result = result + "K";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest L: Sort integer numbers applying InsertionSort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new InsertionSort();
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
                result = result + "L";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("\n| This Code is made by Anneshu Nag, Student ID- 2210994760 |");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}

/*-----------------------------------------------MY OUTPUT---------------------------------------------------------

Test A: Sort integer numbers applying Default Sort with AscendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995
 :: SUCCESS

Test B: Sort integer numbers applying Default Sort with DescendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100
 :: SUCCESS

Test C: Sort integer numbers applying Default Sort with EvenNumberFirstComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 724, 596, 958, 752, 120, 122, 966, 772, 722, 100, 780, 312, 236, 213, 995, 263, 175, 299, 511, 333
 :: SUCCESS

Test D: Sort integer numbers applying BubbleSort with AscendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995
 :: SUCCESS

Test E: Sort integer numbers applying BubbleSort with DescendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100
 :: SUCCESS

Test F: Sort integer numbers applying BubbleSort with EvenNumberFirstComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 236, 312, 780, 100, 722, 966, 724, 122, 120, 752, 958, 596, 772, 333, 511, 213, 263, 175, 299, 995
 :: SUCCESS

Test G: Sort integer numbers applying SelectionSort with AscendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995

Test I: Sort integer numbers applying SelectionSort with EvenNumberFirstComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 236, 312, 780, 100, 722, 966, 724, 122, 120, 752, 958, 596, 772, 175, 511, 333, 213, 299, 995, 263
 :: SUCCESS

Test J: Sort integer numbers applying InsertionSort with AscendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995
 :: SUCCESS

Test K: Sort integer numbers applying InsertionSort with DescendingIntComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100
 :: SUCCESS

Test L: Sort integer numbers applying InsertionSort with EvenNumberFirstComparer:
Intital data: 333, 236, 312, 780, 100, 722, 511, 966, 213, 724, 122, 120, 263, 175, 752, 958, 596, 299, 995, 772
Resulting order: 236, 312, 780, 100, 722, 966, 724, 122, 120, 752, 958, 596, 772, 333, 511, 213, 263, 175, 299, 995
 :: SUCCESS


 ------------------- SUMMARY -------------------

| This Code is made by Anneshu Nag, Student ID- 2210994760 |
Tests passed: ABCDEFGHIJKL */