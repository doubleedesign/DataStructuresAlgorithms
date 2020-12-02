using System;
using System.Text;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialise tree
            BinaryTree myTree = new BinaryTree();

            // Initialise search result variables 
            Boolean result;
            int userSearch;

            // Add values
            myTree.AddNode(2);
            myTree.AddNode(7);
            myTree.AddNode(5);
            myTree.AddNode(9);
            myTree.AddNode(4);
            myTree.AddNode(2);
            myTree.AddNode(6);
            myTree.AddNode(5);
            myTree.AddNode(11);

            // Show some sample searches
            Console.WriteLine("Searching for value 4:");
            result = myTree.SearchFor(4);
            Console.WriteLine(result.ToString());

            Console.WriteLine("Searching for value 3:");
            result = myTree.SearchFor(3);
            Console.WriteLine(result.ToString());

            // Ask the user to perform searches, handling the error if they enter something that's not an integer
            while (true) // Creates a loop that keeps asking the user for integers until they exit
            {
                Console.WriteLine("Enter an integer to search for:");
                try
                {
                    userSearch = int.Parse(Console.ReadLine());
                    result = myTree.SearchFor(userSearch);
                    if(result == true)
                    {
                        Console.WriteLine("Yes, " + userSearch + " is in my binary tree.");
                    }
                    else
                    {
                        Console.WriteLine("No, " + userSearch + " is not in my binary tree.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You entered the wrong format. I can only search for integers. Please try again.");
                } 
            }
           
        }

        /**
         * Class to create and modify the tree
         */
        public class BinaryTree
        {
            private Node root;

            // Constructor
            public BinaryTree() {
            }

            // Add a node with given integer
            public void AddNode(int data)
            {
                // If there's no root (the tree is empty), assign this node to the root and exit
                if (root == null)
                {
                    root = new Node(data);
                    return;
                }
                // Otherwise, loop through and compare the value to add to each one in the tree until we find the right spot
                else
                {
                    Node current = root; 
                    while(true)
                    {
                        // If this data is smaller than or equal to the current node's, proceed down the left
                        if(data <= current.data)
                        {
                            if(current.leftChild == null) // We've found the parent, insert here and exit
                            {
                                current.leftChild = new Node(data);
                                break;
                            }
                            else
                            {
                                current = current.leftChild; // Move the current node and continue back to the top of the loop
                            }
                        }
                        // Otherwise, i.e. the new data is larger, proceed down the right
                        else
                        {
                            if(current.rightChild == null) // We've found the parent, insert here and exit
                            {
                                current.rightChild = new Node(data);
                                break;
                            }
                            else
                            {
                                current = current.rightChild; // Move the current node and continue back to the top of the loop
                            }
                        }
                    }
                }
            }


            // Check if given data is in the binary tree
            public Boolean SearchFor(int data)
            {
                Node current = root;

                // Loop through the values until either we find the given value, or have searched them all and current becomes null
                while (current != null)
                {
                    // If the searched value is less than the current node's value, move to the left subtree
                    if(data < current.data)
                    {
                        current = current.leftChild; 
                    }
                    // If it is larger, move to the right subtree
                    else if(data > current.data)
                    {
                        current = current.rightChild; 
                    }
                    // If it is equal, we have found that the value is in the tree so return true
                    else if(data == current.data)
                    {
                        return true;
                    }
                }

                // If not found, current.data will eventually be a null value and so we return false
                return false;
            }


            /**
             * Inner class to create nodes
             */
            private class Node
            {
                public int data; // the data in this node
                public Node leftChild; 
                public Node rightChild;

                // Constructor to create the node with the initially supplied integer data
                public Node(int data)
                {
                    this.data = data;
                }

                // ToString method for cleaner output
                public override string ToString()
                {
                    return data.ToString(); 
                }
            }

        }        
    }
}
