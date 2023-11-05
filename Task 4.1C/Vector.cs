/* This code is made by Anneshu Nag, Student ID- 2210994760  */
/*                    Dated- 03/09/2023                      */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T> : IEnumerable<T> where T : IComparable<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        public ISorter Sorter { set; get; } = new DefaultSorter();

        internal class DefaultSorter : ISorter
        {
            public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
            {
                if (comparer == null) comparer = Comparer<K>.Default;
                Array.Sort(sequence, comparer);
            }
        }

        public void Sort()
        {
            if (Sorter == null) Sorter = new DefaultSorter();
            Array.Resize(ref data, Count);
            Sorter.Sort(data, null);
        }

        public void Sort(IComparer<T> comparer)
        {
            if (Sorter == null) Sorter = new DefaultSorter();
            Array.Resize(ref data, Count);
            if (comparer == null) Sorter.Sort(data, null);
            else Sorter.Sort(data, comparer);
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.

        // My implementation from Task 1.1P => Start
        // Inserting element
        public void Insert(int index, T element)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("The index given is out of the range.");
            }

            // For Count equal to Capacity increasing the capacity by reallocating the internal array
            if (Count == Capacity)
            {
                ExtendData(DEFAULT_CAPACITY);
            }

            // For index equal to Count then adding the item to the end of the Vector<T>
            if (index == Count)
            {
                data[Count++] = element;
            }
            else
            {
                for (int i = Count - 1; i >= index; i--)
                {
                    data[i + 1] = data[i];
                }

                data[index] = element;
                Count++;
            }
        }

        public void Clear()
        {
            // Changing the length of the array to 0
            Count = 0;
        }

        public bool Contains(T element)
        {
            // Created method
            if (IndexOf(element) != -1) // Using the given IndexOf() method 
                return true;
            else
                return false;
        }

        public bool Remove(T element)
        {
            int index = IndexOf(element); // Using the IndexOf() method here

            if (index >= 0)
            {
                RemoveAt(index); // Using RemoveAt() method here
                return true;
            }
            return false;

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("The index given is out of the range.");
            }

            for (int i = index; i < Count - 1; i++)
            {
                data[i] = data[i + 1];
            }

            data[Count - 1] = default(T); // This clear the cell if there is any elemet in it (Optional)
            Count--;
        }

        public override string ToString()
        {
            // If there are no elements in the array then print this
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder myString = new StringBuilder();
            myString.Append("["); // Appending '[' before the string

            for (int i = 0; i < Count - 1; i++)
            {
                myString.Append(data[i]);
                myString.Append(", ");
            }

            myString.Append(data[Count - 1]);
            myString.Append("]"); // Appending ']' after the string

            return myString.ToString();
        }
        // My implementation from Task 1.1P => End


        // TODO: Add your methods for implementing the appropriate interface here
        // TODO: Add an Iterator as an inner class here
        public int BinarySearch(T element, IComparer<T> comparer)
        {
            // Call the private BinarySearch_Recursive method with initial parameters
            return BinarySearch_Recursive(element, comparer, 0, data.Length - 1);
        }

        public int BinarySearch(T element)
        {
            // Use the default comparer and call the private BinarySearch_Recursive method with initial parameters
            IComparer<T> comparer = Comparer<T>.Default;
            return BinarySearch_Recursive(element, comparer, 0, data.Length - 1);
        }

        // Private recursive binary search method
        private int BinarySearch_Recursive(T element, IComparer<T> comparer, int leastIdx, int maxIdx)
        {
            // Base case: If the least index is greater than the max index, the element is not found.
            if (leastIdx > maxIdx) return -1;

            else
            {
                // Calculate the middle index
                int midIdx = (leastIdx + maxIdx) / 2;

                // Compare the target element with the middle element of the current range
                int comparisonResult = comparer.Compare(element, data[midIdx]);

                if (comparisonResult == 0)
                {
                    // Return element at the middle index
                    return midIdx;
                }
                else if (comparisonResult < 0)
                {
                    // If the element is less than the middle element, search in the left side
                    return BinarySearch_Recursive(element, comparer, leastIdx, midIdx - 1);
                }
                else
                {
                    // If the element is greater than the middle element, search in the right side
                    return BinarySearch_Recursive(element, comparer, midIdx + 1, maxIdx);
                }
            }
        }

        // Implement the generic IEnumerable<T> interface
        public IEnumerator<T> GetEnumerator()
        {
            // Create and return an instance of the custom "myIterator" class
            return new myIterator(this);
        }

        // Implement the non-generic IEnumerable interface (for compatibility)
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Obtain an enumerator
            return GetEnumerator();
        }

        // Private nested class "myIterator" that implements IEnumerator<T>
        private class myIterator : IEnumerator<T>
        {
            private readonly Vector<T> myVector; // Reference to the Vector<T> being enumerated
            private int _currentIndex = -1; // Current index within the collection

            // Constructor that takes a Vector<T> as an argument
            public myIterator(Vector<T> vector)
            {
                myVector = vector;
            }

            // Get the current element in the collection
            public T Current
            {
                get
                {
                    // Check if the current index is within the valid range
                    if (_currentIndex >= 0 && _currentIndex < myVector.Count)
                    {
                        // Return the element at the current index
                        return myVector.data[_currentIndex];
                    }
                    // Return the default value for type T if index is out of range
                    return default(T);
                }
            }

            // Implement the non-generic IEnumerator's Current property (for compatibility)
            object IEnumerator.Current => Current;

            // Dispose method
            public void Dispose()
            {
                // Implementation not needed
            }

            // Move to the next element in the collection
            public bool MoveNext()
            {
                _currentIndex += 1;
                return _currentIndex < myVector.Count;
            }

            // Reset the enumerator to its initial position
            public void Reset()
            {
                // Set the current index to -1 to indicate the initial position
                _currentIndex = -1;
            }
        }
    }
}

/*----------------------------------------------------My Output-----------------------------------------------------
Test A: Apply BinarySearch searching for number 333 to array of integer numbers sorted in AscendingIntComparer:
Resulting order: [100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995]
 :: SUCCESS

Test B: Apply BinarySearch searching for number 99 to array of integer numbers sorted in AscendingIntComparer:
Resulting order: [100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995]
 :: SUCCESS

Test C: Apply BinarySearch searching for number 996 to array of integer numbers sorted in AscendingIntComparer:
Resulting order: [100, 120, 122, 175, 213, 236, 263, 299, 312, 333, 511, 596, 722, 724, 752, 772, 780, 958, 966, 995]
 :: SUCCESS

Test D: Apply BinarySearch searching for number 333 to array of integer numbers sorted in DescendingIntComparer:
Resulting order: [995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100]
 :: SUCCESS

Test E: Apply BinarySearch searching for number 994 to array of integer numbers sorted in DescendingIntComparer:
Resulting order: [995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100]
 :: SUCCESS

Test F: Apply BinarySearch searching for number 101 to array of integer numbers sorted in DescendingIntComparer:
Resulting order: [995, 966, 958, 780, 772, 752, 724, 722, 596, 511, 333, 312, 299, 263, 236, 213, 175, 122, 120, 100]
 :: SUCCESS

Test G: Run a sequence of operations:
Create a new vector by calling 'Vector<int> vector = new Vector<int>(5);'
 :: SUCCESS
Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9
 :: SUCCESS

Test H: Run a sequence of operations:
Check whether the interface IEnumerable<T> is implemented for the Vector<T> class
 :: SUCCESS
Check whether GetEnumerator() method is implemented
 :: SUCCESS

Test I: Run a sequence of operations:
Return the Enumerator of the Vector<T> and check whether it implements IEnumerator<T>
Check the initial value of Current of the Enumerator
Check the value of Current of the Enumerator after MoveNext() operation
 :: SUCCESS

Test J: Check the content of the Vector<int> by traversing it via 'foreach' statement
 :: SUCCESS

Test K: Run a sequence of operations:
Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'
Add student with record: 0[Vicky]
Add student with record: 1[Cindy]
Add student with record: 2[Tom]
Add student with record: 3[Simon]
Add student with record: 4[Richard]
Add student with record: 5[Vicky]
Add student with record: 6[Tom]
Add student with record: 7[Elicia]
Add student with record: 8[Richard]
Add student with record: 9[Cindy]
Add student with record: 10[Vicky]
Add student with record: 11[Guy]
Add student with record: 12[Richard]
Add student with record: 13[Michael]
Print the vector of students via students.ToString();
[0[Vicky], 1[Cindy], 2[Tom], 3[Simon], 4[Richard], 5[Vicky], 6[Tom], 7[Elicia], 8[Richard], 9[Cindy], 10[Vicky], 11[Guy], 12[Richard], 13[Michael]]
 :: SUCCESS

Test J: Check the content of the Vector<Student> by traversing it via 'foreach' statement
 :: SUCCESS


 ------------------- SUMMARY -------------------

| This Code is made by Anneshu Nag, Student ID- 2210994760 |
Tests passed: ABCDEFGHIJKJ*/