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

            Console.WriteLine("Done");
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
