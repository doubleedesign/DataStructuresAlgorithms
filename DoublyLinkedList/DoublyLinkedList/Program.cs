using System;
using System.Text;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a list
            DoublyLinkedList myList = new DoublyLinkedList();

            // Output explanation
            Console.WriteLine("Adding 3 values to the list: 5, 7, 9:");

            // Insert an element with a value of 5
            myList.AddNode(5);
            myList.AddNode(7);
            myList.AddNode(9);

            // Output the list
            Console.WriteLine("My List: " + myList.ToString());

            // Remove the tail
            Console.WriteLine("Removing the tail:");
            myList.RemoveTail();

            // Output the list again
            Console.WriteLine("My List: " + myList.ToString());

            // Insert some more elements
            Console.WriteLine("Adding 3 values to the list: 2, 4, 6:");
            myList.AddNode(2);
            myList.AddNode(4);
            myList.AddNode(6);

            // Output the list again
            Console.WriteLine("My List: " + myList.ToString());

            // Remove the tail
            Console.WriteLine("Removing the tail again:");
            myList.RemoveTail();

            // Output the list again
            Console.WriteLine("My List: " + myList.ToString());
        }
    }


    /**
     * Class to create the doubly linked list
     */
    class DoublyLinkedList
    {
        Node head;
        Node tail;
        int length;

        // Constructor to create an empty DoublyLinkedList
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            length = 0;
        }

        // Add a node to the beginning of the list, with the given data
        public void AddNode(int data)
        {
            // Create the node
            Node newNode = new Node(data); 
            
            // If the list is empty, add this node as the tail
            if(length == 0)
            {
                tail = newNode;
            }
            // Otherwise, assign it to the previous value of the current head
            else
            {
                head.prev = newNode;
            }

            // Move the head to the new node's next 
            newNode.next = head;

            // Make the new node the head
            head = newNode;

            // Update the length
            length++; 
        }

        // Remove the node at the end of the list
        public void RemoveTail()
        {
            if(length == 0)
            {
                Console.WriteLine("List is empty, nothing to delete");
            }
            else
            {
                Node thisNode = tail;
                Node prevNode = thisNode.prev;
                Node nextNode = thisNode.next;

                prevNode.next = null;
                tail = prevNode;

                // Reduce the length property by 1 because we've just removed one node
                length--;
            }
        }

        // ToString method to show the list
        public override String ToString()
        {
            if(length == 0)
            {
                return "List is empty";
            }
            else
            {
                StringBuilder myString = new StringBuilder();
                Node temp = head; 
                while (temp != null)
                {
                    myString.Append(temp.data.ToString() + ", ");
                    temp = temp.next;
                }

                return myString.ToString();
            }
        }

        /**
         * Inner class to create nodes
         */
        private class Node
        {
            // Instance variables
            public int data; // the data in this node
            public Node prev; // pointer to the previous list node
            public Node next; // pointer to the next list node

            // Constructor to create the node with the initially supplied integer data
            public Node(int data)
            {
                this.data = data;
                this.prev = null;
                this.next = null;
            }
        }
    }
}
