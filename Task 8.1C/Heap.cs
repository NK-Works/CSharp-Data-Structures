using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace HeapSortAlgorithm
{
    public class Heap<K, D> where K : IComparable<K>
    {

        // This is a nested Node class whose purpose is to represent a node of a heap.
        private class Node : IHeapifyable<K, D>
        {
            // The Data field represents a payload.
            public D Data { get; set; }
            // The Key field is used to order elements with regard to the Binary Min (Max) Heap Policy, i.e. the key of the parent node is smaller (larger) than the key of its children.
            public K Key { get; set; }
            // The Position field reflects the location (index) of the node in the array-based internal data structure.
            public int Position { get; set; }

            public Node(K key, D value, int position)
            {
                Data = value;
                Key = key;
                Position = position;
            }

            // This is a ToString() method of the Node class.
            // It prints out a node as a tuple ('key value','payload','index')}.
            public override string ToString()
            {
                return "(" + Key.ToString() + "," + Data.ToString() + "," + Position + ")";
            }
        }

        // ---------------------------------------------------------------------------------
        // Here the description of the methods and attributes of the Heap<K, D> class starts

        public int Count { get; private set; }

        // The data nodes of the Heap<K, D> are stored internally in the List collection. 
        // Note that the element with index 0 is a dummy node.
        // The top-most element of the heap returned to the user via Min() is indexed as 1.
        private List<Node> data = new List<Node>();

        // We refer to a given comparer to order elements in the heap. 
        // Depending on the comparer, we may get either a binary Min-Heap or a binary  Max-Heap. 
        // In the former case, the comparer must order elements in the ascending order of the keys, and does this in the descending order in the latter case.
        private IComparer<K> comparer;

        // We expect the user to specify the comparer via the given argument.
        public Heap(IComparer<K> comparer)
        {
            this.comparer = comparer;

            // We use a default comparer when the user is unable to provide one. 
            // This implies the restriction on type K such as 'where K : IComparable<K>' in the class declaration.
            if (this.comparer == null) this.comparer = Comparer<K>.Default;

            // We simplify the implementation of the Heap<K, D> by creating a dummy node at position 0.
            // This allows to achieve the following property:
            // The children of a node with index i have indices 2*i and 2*i+1 (if they exist).
            data.Add(new Node(default(K), default(D), 0));
        }

        // This method returns the top-most (either a minimum or a maximum) of the heap.
        // It does not delete the element, just returns the node casted to the IHeapifyable<K, D> interface.
        public IHeapifyable<K, D> Min()
        {
            if (Count == 0) throw new InvalidOperationException("The heap is empty.");
            return data[1];
        }

        // Insertion to the Heap<K, D> is based on the private UpHeap() method
        public IHeapifyable<K, D> Insert(K key, D value)
        {
            Count++;
            Node node = new Node(key, value, Count);
            data.Add(node);
            UpHeap(Count);
            return node;
        }

        private void UpHeap(int start)
        {
            int position = start;
            while (position != 1)
            {
                if (comparer.Compare(data[position].Key, data[position / 2].Key) < 0) Swap(position, position / 2);
                position = position / 2;
            }
        }

        // This method swaps two elements in the list representing the heap. 
        // Use it when you need to swap nodes in your solution, e.g. in DownHeap() that you will need to develop.
        private void Swap(int from, int to)
        {
            Node temp = data[from];
            data[from] = data[to];
            data[to] = temp;
            data[to].Position = to;
            data[from].Position = from;
        }

        public void Clear()
        {
            for (int i = 0; i<=Count; i++) data[i].Position = -1;
            data.Clear();
            data.Add(new Node(default(K), default(D), 0));
            Count = 0;
        }

        public override string ToString()
        {
            if (Count == 0) return "[]";
            StringBuilder s = new StringBuilder();
            s.Append("[");
            for (int i = 0; i < Count; i++)
            {
                s.Append(data[i + 1]);
                if (i + 1 < Count) s.Append(",");
            }
            s.Append("]");
            return s.ToString();
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.
        
        // The down heap methed to set the tree not satisfying the min heap condition to make it so that it satisfies the condition
        private void DownHeap(int start)
        {
            // 'start' is the root(parent)
            // 'leftNode' and 'rightNode' are its left and right child respectively
            int leftNode = start * 2;  
            int rightNode = start * 2 + 1;

            if (leftNode > Count) return;   // Stop condition i.e. the leftmost node is having no child
            
            int position = leftNode; // Initially taking the smallest as the left child

            // Comparing left and right child
            if (rightNode <= Count && comparer.Compare(data[leftNode].Key, data[rightNode].Key) >= 0)
            {
                position = rightNode;  // If right child is actually smaller then making it the smallest
            }
            if (comparer.Compare(data[start].Key, data[position].Key) < 0) return;

            Swap(start, position);   // Finally swapping it with the root(parent)
            DownHeap(position);     // Calling it again to make the entire tree satisfying min heap condition 
        }
        public IHeapifyable<K, D> Delete()
        {
            if (Count is 0) throw new InvalidOperationException();

            // Taking the root node and swapping it with the last most node in the heap
            Node rootEle = data[1];
            Swap(1, Count);
            data.RemoveAt(Count);  // Removing the last most node after swapping
            Count--;
            
            DownHeap(1);   // Implementing Downheap() to check if the new tree satisfies condition for min heap
            
            rootEle.Position = -1; // Indicates that it is not a part of the heap anymore
            return rootEle;
        }

        // Builds a minimum binary heap using the specified data according to the bottom-up approach.
        public IHeapifyable<K, D>[] BuildHeap(K[] keys, D[] data)
        {
            if (Count > 0) throw new InvalidOperationException();

            // Building a tree using an array or a list
            // Checking and making it into a heap tree
            Node[] arrayOfNodesInHeap = new Node[keys.Length];

            // Inserting the nodes to the heap
            for (int i = 0; i < keys.Length; i++)
            {
                Count += 1; // Increating first to make it start from 1
                Node newNode = new Node(keys[i], data[i], Count);
                this.data.Add(newNode);
                // Adding to the array too
                arrayOfNodesInHeap[i] = newNode;
            }
            // Heapifying i.e. ensuring that the parent and child nodes are maintaining the property of min heap after being added to the tree
            for (int i = Count / 2; i > 0; i--)
            {
                DownHeap(i);
            }
            return arrayOfNodesInHeap;   
        }

        // Decreases the actual key value of node
        public void DecreaseKey(IHeapifyable<K, D> element, K new_key)
        {
            Node selNode = element as Node;
            Node elementPosition = data[selNode.Position];

            if (selNode != elementPosition) // If the node containing the element doesn't exist do this
            {
                throw new InvalidOperationException();
            }
            selNode.Key = new_key; // Change Key
            UpHeap(selNode.Position); // Perform UpHeap() to maintain the min heap property
        }

        // Deleting an element from the heap tree
        public IHeapifyable<K, D> DeleteElement(IHeapifyable<K, D> element)
        {
            Node selNode = element as Node;
            // Swapping with the last element of the heap tree
            Swap(selNode.Position, Count);

            // Remove the last element
            data.RemoveAt(Count);
            Count--;

            // Peform UpHeap() to maintain the min heap property
            UpHeap(selNode.Position);
            return selNode;
        }

        // Deletes the Kth smallest element e.g. for k = 3 it is the 3rd smallest element 
        public IHeapifyable<K, D> KthMinElement(int k)
        {
            if (Count is 0) throw new InvalidOperationException();
            if (k < 1 || k > Count) throw new ArgumentOutOfRangeException();

            // Array to store the smallest elements temporarily
            Node[] dummyDataArray = new Node[k];
            Node minNode = data[0];  // Initialising data at 0th index as the smallest

            // Removing smallest elements from the heap tree and then adding them to the array
            for (int i = 0; i < k; i++)
            {
                minNode = Delete() as Node;
                dummyDataArray[i] = minNode;
            }
            // Adding the elements back to the heap tree
            for (int i = 0; i < k; i++)
            {
                this.Insert(dummyDataArray[i].Key, dummyDataArray[i].Data);
            }
            return minNode;
        }
    }
}

/*-------------------------------------------------My Output-----------------------------------------------------
Test A: Create a min-heap by calling 'minHeap = new Heap<int, string>(new IntAscendingComparer());'
 :: SUCCESS: min-heap's state []


Test B: Run a sequence of operations:

Insert a node with name Kelly (data) and ID 1 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1)]

Insert a node with name Cindy (data) and ID 6 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(6,Cindy,2)]

Insert a node with name John (data) and ID 5 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(6,Cindy,2),(5,John,3)]

Insert a node with name Andrew (data) and ID 7 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(6,Cindy,2),(5,John,3),(7,Andrew,4)]

Insert a node with name Richard (data) and ID 8 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(6,Cindy,2),(5,John,3),(7,Andrew,4),(8,Richard,5)]

Insert a node with name Michael (data) and ID 3 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(6,Cindy,2),(3,Michael,3),(7,Andrew,4),(8,Richard,5),(5,John,6)]

Insert a node with name Guy (data) and ID 10 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(6,Cindy,2),(3,Michael,3),(7,Andrew,4),(8,Richard,5),(5,John,6),(10,Guy,7)]

Insert a node with name Elicia (data) and ID 4 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(4,Elicia,2),(3,Michael,3),(6,Cindy,4),(8,Richard,5),(5,John,6),(10,Guy,7),(7,Andrew,8)]

Insert a node with name Tom (data) and ID 2 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(2,Tom,2),(3,Michael,3),(4,Elicia,4),(8,Richard,5),(5,John,6),(10,Guy,7),(7,Andrew,8),(6,Cindy,9)]

Insert a node with name Iman (data) and ID 9 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(2,Tom,2),(3,Michael,3),(4,Elicia,4),(8,Richard,5),(5,John,6),(10,Guy,7),(7,Andrew,8),(6,Cindy,9),(9,Iman,10)]

Insert a node with name Simon (data) and ID 14 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(2,Tom,2),(3,Michael,3),(4,Elicia,4),(8,Richard,5),(5,John,6),(10,Guy,7),(7,Andrew,8),(6,Cindy,9),(9,Iman,10),(14,Simon,11)]

Insert a node with name Vicky (data) and ID 12 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(2,Tom,2),(3,Michael,3),(4,Elicia,4),(8,Richard,5),(5,John,6),(10,Guy,7),(7,Andrew,8),(6,Cindy,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12)]

Insert a node with name Kevin (data) and ID 11 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(2,Tom,2),(3,Michael,3),(4,Elicia,4),(8,Richard,5),(5,John,6),(10,Guy,7),(7,Andrew,8),(6,Cindy,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12),(11,Kevin,13)]

Insert a node with name David (data) and ID 13 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1),(2,Tom,2),(3,Michael,3),(4,Elicia,4),(8,Richard,5),(5,John,6),(10,Guy,7),(7,Andrew,8),(6,Cindy,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12),(11,Kevin,13),(13,David,14)]


Test C: Run a sequence of operations:

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(2,Tom,1),(4,Elicia,2),(3,Michael,3),(6,Cindy,4),(8,Richard,5),(5,John,6),(10,Guy,7),(7,Andrew,8),(13,David,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12),(11,Kevin,13)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(3,Michael,1),(4,Elicia,2),(5,John,3),(6,Cindy,4),(8,Richard,5),(11,Kevin,6),(10,Guy,7),(7,Andrew,8),(13,David,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(4,Elicia,1),(6,Cindy,2),(5,John,3),(7,Andrew,4),(8,Richard,5),(11,Kevin,6),(10,Guy,7),(12,Vicky,8),(13,David,9),(9,Iman,10),(14,Simon,11)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(5,John,1),(6,Cindy,2),(10,Guy,3),(7,Andrew,4),(8,Richard,5),(11,Kevin,6),(14,Simon,7),(12,Vicky,8),(13,David,9),(9,Iman,10)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(6,Cindy,1),(7,Andrew,2),(10,Guy,3),(9,Iman,4),(8,Richard,5),(11,Kevin,6),(14,Simon,7),(12,Vicky,8),(13,David,9)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(7,Andrew,1),(8,Richard,2),(10,Guy,3),(9,Iman,4),(13,David,5),(11,Kevin,6),(14,Simon,7),(12,Vicky,8)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(8,Richard,1),(9,Iman,2),(10,Guy,3),(12,Vicky,4),(13,David,5),(11,Kevin,6),(14,Simon,7)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(9,Iman,1),(12,Vicky,2),(10,Guy,3),(14,Simon,4),(13,David,5),(11,Kevin,6)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(10,Guy,1),(12,Vicky,2),(11,Kevin,3),(14,Simon,4),(13,David,5)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(11,Kevin,1),(12,Vicky,2),(13,David,3),(14,Simon,4)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(12,Vicky,1),(14,Simon,2),(13,David,3)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(13,David,1),(14,Simon,2)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(14,Simon,1)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state []


Test D: Delete the minimum element from the min-heap.
 :: SUCCESS: InvalidOperationException is thrown because the min-heap is empty


Test E: Run a sequence of operations:

Insert a node with name Kelly (data) and ID 1 (key).
 :: SUCCESS: min-heap's state [(1,Kelly,1)]

Build the min-heap for the pair of key-value arrays with
[1, 6, 5, 7, 8, 3, 10, 4, 2, 9, 14, 12, 11, 13] as keys and
[Kelly, Cindy, John, Andrew, Richard, Michael, Guy, Elicia, Tom, Iman, Simon, Vicky, Kevin, David] as data elements
 :: SUCCESS: InvalidOperationException is thrown because the min-heap is not empty


Test F: Run a sequence of operations:

Clear the min-heap.
 :: SUCCESS: min-heap's state []

Build the min-heap for the pair of key-value arrays with
[1, 6, 5, 7, 8, 3, 10, 4, 2, 9, 14, 12, 11, 13] as keys and
[Kelly, Cindy, John, Andrew, Richard, Michael, Guy, Elicia, Tom, Iman, Simon, Vicky, Kevin, David] as data elements
 :: SUCCESS: min-heap's state [(1,Kelly,1),(2,Tom,2),(3,Michael,3),(4,Elicia,4),(8,Richard,5),(5,John,6),(10,Guy,7),(6,Cindy,8),(7,Andrew,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12),(11,Kevin,13),(13,David,14)]


Test G: Run a sequence of operations:

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(2,Tom,1),(4,Elicia,2),(3,Michael,3),(6,Cindy,4),(8,Richard,5),(5,John,6),(10,Guy,7),(13,David,8),(7,Andrew,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12),(11,Kevin,13)]

Delete the minimum element from the min-heap.
 :: SUCCESS: min-heap's state [(3,Michael,1),(4,Elicia,2),(5,John,3),(6,Cindy,4),(8,Richard,5),(11,Kevin,6),(10,Guy,7),(13,David,8),(7,Andrew,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12)]

Run DecreaseKey(node,0) for node (13,David,8) by setting the new value of its key to 0
 :: SUCCESS: min-heap's state [(0,David,1),(3,Michael,2),(5,John,3),(4,Elicia,4),(8,Richard,5),(11,Kevin,6),(10,Guy,7),(6,Cindy,8),(7,Andrew,9),(9,Iman,10),(14,Simon,11),(12,Vicky,12)]


Test H: Run a sequence of operations:

Create a max-heap by calling 'maxHeap = new Heap<int, string>(new IntDescendingComparer());'
 :: SUCCESS: max-heap's state []

Build the max-heap for the pair of key-value arrays with
[1, 6, 5, 7, 8, 3, 10, 4, 2, 9, 14, 12, 11, 13] as keys and
[Kelly, Cindy, John, Andrew, Richard, Michael, Guy, Elicia, Tom, Iman, Simon, Vicky, Kevin, David] as data elements
 :: SUCCESS: max-heap's state [(14,Simon,1),(9,Iman,2),(13,David,3),(7,Andrew,4),(8,Richard,5),(12,Vicky,6),(10,Guy,7),(4,Elicia,8),(2,Tom,9),(6,Cindy,10),(1,Kelly,11),(3,Michael,12),(11,Kevin,13),(5,John,14)]


Test I: Run a sequence of operations:

Delete the Richard element from the min-heap.
 :: SUCCESS: min-heap's state [(0,David,1),(3,Michael,2),(5,John,3),(4,Elicia,4),(12,Vicky,5),(11,Kevin,6),(10,Guy,7),(6,Cindy,8),(7,Andrew,9),(9,Iman,10),(14,Simon,11)]
 :: SUCCESS: min-heap's state [(0,David,1),(3,Michael,2),(5,John,3),(4,Elicia,4),(12,Vicky,5),(11,Kevin,6),(10,Guy,7),(6,Cindy,8),(7,Andrew,9),(9,Iman,10),(14,Simon,11)]


Test J: Run a sequence of operations:
min-heap's state [(0,David,1),(3,Michael,2),(5,John,3),(4,Elicia,4),(12,Vicky,5),(11,Kevin,6),(10,Guy,7),(6,Cindy,8),(7,Andrew,9),(9,Iman,10),(14,Simon,11)]
 :: SUCCESS: 4th Node is (5,John,-1)
 :: SUCCESS: min-heap's state [(0,David,1),(3,Michael,2),(9,Iman,3),(6,Cindy,4),(4,Elicia,5),(11,Kevin,6),(10,Guy,7),(14,Simon,8),(7,Andrew,9),(12,Vicky,10),(5,John,11)]


 ------------------- SUMMARY -------------------
Tests passed: ABCDEFGHIJ */