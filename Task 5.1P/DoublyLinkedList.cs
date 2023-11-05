using System;
using System.Text;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {

        // Here is the the nested Node<K> class 
        private class Node<K> : INode<K>
        {
            public K Value { get; set; }
            public Node<K> Next { get; set; }
            public Node<K> Previous { get; set; }

            public Node(K value, Node<K> previous, Node<K> next)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }

            // This is a ToString() method for the Node<K>
            // It represents a node as a tuple {'the previous node's value'-(the node's value)-'the next node's value')}. 
            // 'XXX' is used when the current node matches the First or the Last of the DoublyLinkedList<T>
            public override string ToString()
            {
                StringBuilder s = new StringBuilder();
                s.Append("{");
                s.Append(Previous.Previous == null ? "XXX" : Previous.Value.ToString());
                s.Append("-(");
                s.Append(Value);
                s.Append(")-");
                s.Append(Next.Next == null ? "XXX" : Next.Value.ToString());
                s.Append("}");
                return s.ToString();
            }

        }

        // Here is where the description of the methods and attributes of the DoublyLinkedList<T> class starts

        // An important aspect of the DoublyLinkedList<T> is the use of two auxiliary nodes: the Head and the Tail. 
        // The both are introduced in order to significantly simplify the implementation of the class and make insertion functionality reduced just to a AddBetween(...)
        // These properties are private, thus are invisible to a user of the data structure, but are always maintained in it, even when the DoublyLinkedList<T> is formally empty. 
        // Remember about this crucial fact when you design and code other functions of the DoublyLinkedList<T> in this task.
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public int Count { get; private set; } = 0;

        public DoublyLinkedList()
        {
            Head = new Node<T>(default(T), null, null);
            Tail = new Node<T>(default(T), Head, null);
            Head.Next = Tail;
        }

        public INode<T> First
        {
            get
            {
                if (Count == 0) return null;
                else return Head.Next;
            }
        }

        public INode<T> Last
        {
            get
            {
                if (Count == 0) return null;
                else return Tail.Previous;
            }
        }

        public INode<T> After(INode<T> node)
        {
            if (node == null) throw new NullReferenceException();
            Node<T> node_current = node as Node<T>;
            if (node_current.Previous == null || node_current.Next == null) throw new InvalidOperationException("The node referred as 'before' is no longer in the list");
            if (node_current.Next.Equals(Tail)) return null;
            else return node_current.Next;
        }

        public INode<T> AddLast(T value)
        {
            return AddBetween(value, Tail.Previous, Tail);
        }

        // This is a private method that creates a new node and inserts it in between the two given nodes referred as the previous and the next.
        // Use it when you wish to insert a new value (node) into the DoublyLinkedList<T>
        private Node<T> AddBetween(T value, Node<T> previous, Node<T> next)
        {
            Node<T> node = new Node<T>(value, previous, next);
            previous.Next = node;
            next.Previous = node;
            Count++;
            return node;
        }

        public INode<T> Find(T value)
        {
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                if (node.Value.Equals(value)) return node;
                node = node.Next;
            }
            return null;
        }

        public override string ToString()
        {
            if (Count == 0) return "[]";
            StringBuilder s = new StringBuilder();
            s.Append("[");
            int k = 0;
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                s.Append(node.ToString());
                node = node.Next;
                if (k < Count - 1) s.Append(",");
                k++;
            }
            s.Append("]");
            return s.ToString();
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.

        public INode<T> Before(INode<T> node)
        {
            if (node == null) throw new NullReferenceException();
            
            Node<T> node_current = node as Node<T>;
            if (node_current.Previous == null || node_current.Next == null) throw new InvalidOperationException("The node referred as 'after' is no longer in the list");
            
            if (node_current.Previous.Equals(Head)) return null;
            else return node_current.Previous;
        }

        public INode<T> AddFirst(T value)
        {
            return AddBetween(value, Head, Head.Next);
        }

        public INode<T> AddBefore(INode<T> before, T value)
        {
            if (before == null) throw new NullReferenceException();
            
            Node<T> node_current = before as Node<T>;
            return AddBetween(value, node_current.Previous, node_current);
        }

        public INode<T> AddAfter(INode<T> after, T value)
        {
            if (after == null) throw new NullReferenceException();
            
            Node<T> node_current = after as Node<T>;
            return AddBetween(value, node_current, node_current.Next);
        }

        public void Clear()
        {
            Head.Next = Tail;
            Tail.Previous = Head;
            Count = 0;
        }

        public void Remove(INode<T> node)
        {
            if (Count == 0) throw new InvalidOperationException();
            if (node == null) throw new NullReferenceException();
            if (Find(node.Value) == null) throw new InvalidOperationException();
            
            Node<T> node_current = node as Node<T>;
            node_current.Next.Previous = node_current.Previous;
            node_current.Previous.Next = node_current.Next;
            
            node_current.Next = null;
            node_current.Previous = null;
            Count--;
        }

        public void RemoveFirst()
        {
            Remove(First);
        }

        public void RemoveLast()
        {
            Remove(Last);
        }
    }
}

/*-----------------------------------------------My Output-------------------------------------------------------
Test A: Create a new list by calling 'DoublyLinkedList<int> vector = new DoublyLinkedList<int>( );'
 :: SUCCESS: list's state []

Test B: Add a sequence of numbers 2, 6, 8, 5, 1, 8, 5, 3, 5 with list.AddLast( )
 :: SUCCESS: list's state [{XXX-(2)-6},{2-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-8},{1-(8)-5},{8-(5)-3},{5-(3)-5},{3-(5)-XXX}]

Test C: Remove sequentially 4 last numbers with list.RemoveLast( )
 :: SUCCESS: list's state [{XXX-(2)-6},{2-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]

Test D: Add a sequence of numbers 10, 20, 30, 40, 50 with list.AddFirst( )
 :: SUCCESS: list's state [{XXX-(50)-40},{50-(40)-30},{40-(30)-20},{30-(20)-10},{20-(10)-2},{10-(2)-6},{2-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]

Test E: Remove sequentially 3 last numbers with list.RemoveFirst( )
 :: SUCCESS: list's state [{XXX-(20)-10},{20-(10)-2},{10-(2)-6},{2-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]

Test F: Run a sequence of operations:
list.Find(40);
 :: SUCCESS: list's state [{XXX-(20)-10},{20-(10)-2},{10-(2)-6},{2-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]
list.Find(0);
 :: SUCCESS: list's state [{XXX-(20)-10},{20-(10)-2},{10-(2)-6},{2-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]
list.Find(2);
 :: SUCCESS: list's state [{XXX-(20)-10},{20-(10)-2},{10-(2)-6},{2-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]

Test G: Run a sequence of operations:
Add 100 before the node with 2 with list.AddBefore(2,100)
 :: SUCCESS: list's state [{XXX-(20)-10},{20-(10)-100},{10-(100)-2},{100-(2)-6},{2-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]
Add 200 after the node with 2 with list.AddAfter(2,200)
 :: SUCCESS: list's state [{XXX-(20)-10},{20-(10)-100},{10-(100)-2},{100-(2)-200},{2-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]
Add 300 before node list.First with list.AddBefore(list.First,300)
 :: SUCCESS: list's state [{XXX-(300)-20},{300-(20)-10},{20-(10)-100},{10-(100)-2},{100-(2)-200},{2-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]
Add 400 after node list.First with list.AddAfter(list.First,400)
 :: SUCCESS: list's state [{XXX-(300)-400},{300-(400)-20},{400-(20)-10},{20-(10)-100},{10-(100)-2},{100-(2)-200},{2-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-1},{5-(1)-XXX}]
Add 500 before node list.First with list.AddBefore(list.Last,500)
 :: SUCCESS: list's state [{XXX-(300)-400},{300-(400)-20},{400-(20)-10},{20-(10)-100},{10-(100)-2},{100-(2)-200},{2-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-500},{5-(500)-1},{500-(1)-XXX}]
Add 600 after node list.First with list.AddAfter(list.Last,600)
 :: SUCCESS: list's state [{XXX-(300)-400},{300-(400)-20},{400-(20)-10},{20-(10)-100},{10-(100)-2},{100-(2)-200},{2-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-500},{5-(500)-1},{500-(1)-600},{1-(600)-XXX}]

Test H: Run a sequence of operations:
Remove the node list.First with list.Remove(list.First)
 :: SUCCESS: list's state [{XXX-(400)-20},{400-(20)-10},{20-(10)-100},{10-(100)-2},{100-(2)-200},{2-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-500},{5-(500)-1},{500-(1)-600},{1-(600)-XXX}]
Remove the node list.Last with list.Remove(list.Last)
 :: SUCCESS: list's state [{XXX-(400)-20},{400-(20)-10},{20-(10)-100},{10-(100)-2},{100-(2)-200},{2-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-500},{5-(500)-1},{500-(1)-XXX}]
Remove the node list.Before, which is before the node containing element 2, with list.Remove(list.Before(...))
 :: SUCCESS: list's state [{XXX-(400)-20},{400-(20)-10},{20-(10)-2},{10-(2)-200},{2-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-500},{5-(500)-1},{500-(1)-XXX}]
Remove the node containing element 2 with list.Remove(...)
 :: SUCCESS: list's state [{XXX-(400)-20},{400-(20)-10},{20-(10)-200},{10-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-500},{5-(500)-1},{500-(1)-XXX}]

Test I: Remove the node containing element 2, which has been recently deleted, with list.Remove(...)
 :: SUCCESS: list's state [{XXX-(400)-20},{400-(20)-10},{20-(10)-200},{10-(200)-6},{200-(6)-8},{6-(8)-5},{8-(5)-500},{5-(500)-1},{500-(1)-XXX}]

Test J: Clear the content of the vector via calling vector.Clear();
 :: SUCCESS: list's state []

Test K: Remove last element for the empty list with list.RemoveLast()
 :: SUCCESS: list's state []


 ------------------- SUMMARY -------------------

| This Code is made by Anneshu Nag, Student ID- 2210994760 |
Tests passed: ABCDEFGHIJK */
