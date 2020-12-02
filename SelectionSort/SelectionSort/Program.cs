using System;
using System.Text;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new sorter object
            SelectionSorter mySorter = new SelectionSorter();

            // Create an array of integers to sort
            int[] myArray = new int[5] { 5, 7, 8, 2, 6 };

            // Show them to the user
            Console.WriteLine("Data to sort:");
            Console.WriteLine(mySorter.ShowMeTheArray(myArray));

            // Call the sorter method, passing in our array of integers
            mySorter.SortThis(myArray);

            // Show the result to the user
            Console.WriteLine("Sorted data:");
            Console.WriteLine(mySorter.ShowMeTheArray(myArray));

            // Ask the user for some values
            int[] userArray = new int[5];
            Console.WriteLine("Let's sort your own array.");
            int count = 0; 
            while(count < 5)
            {
                Console.WriteLine("Please enter a number");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    userArray[count] = input;
                    count++;
                }
                catch(FormatException)
                {
                    Console.WriteLine("I can only add integers. Please try again");
                }
            }

            // Output the user's values
            Console.WriteLine("You entered this data:");
            Console.WriteLine(mySorter.ShowMeTheArray(userArray));

            // Sort them
            mySorter.SortThis(userArray);

            // Show the result to the user
            Console.WriteLine("Your sorted data:");
            Console.WriteLine(mySorter.ShowMeTheArray(userArray));
        }
    }

    // Class for my sorter
    class SelectionSorter
    {

        // Method to sort a given array
        public void SortThis(int[] values)
        {
            // How big is this array? 
            int size = values.Length;

            // Outer loop to get each item to compare
            for (int i = 0; i < size; i++)
            {

                // Inner loop to compare each unsorted item ot the current one
                for (int j = 0; j < size; j++)
                {

                    // If the outer loop value is smaller than the inner loop value:
                    if (values[i] < values[j])
                    {

                        // Bring current outer loop value into a temporary variable
                        int temp = values[i];

                        // Replace it with the one at this position in the inner loop
                        values[i] = values[j];

                        // Move the item in the temporary variable into the is inner loop position
                        values[j] = temp;
                    }
                  
                }
            }
        }


        // Method to display an array to the user
        public StringBuilder ShowMeTheArray(int[] values)
        {
            StringBuilder output = new StringBuilder(); 
            for(int i = 0; i < values.Length; i++)
            {
                output.Append(values[i] + " ");
            }

            return output; 
        }

    }
}
