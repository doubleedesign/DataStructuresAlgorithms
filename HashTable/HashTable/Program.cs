using System;
using System.Collections;

namespace HashTable
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Initialise phone book
            PhoneBook myPhoneBook = new PhoneBook();

            // Add values
            myPhoneBook.AddRow("Lucie", 0312897654);
            myPhoneBook.AddRow("Nancy", 0436123897);
            myPhoneBook.AddRow("Jamie", 0412345789);
            myPhoneBook.AddRow("Davis", 0326654321);
            myPhoneBook.AddRow("Marissa", 0415888999);

            // Display to user
            myPhoneBook.Display();

            // Ask the user for a number to search
            while (true) // Asks repeatedly until they exit
            {
                Console.WriteLine("\nEnter a phone number to search for");
                try
                {
                    int searchValue = int.Parse(Console.ReadLine());
                    myPhoneBook.Search(searchValue);
                }
                // Catch exception that occurs when the user enters a string
                catch (FormatException)
                {
                    Console.WriteLine("I can only search for numbers. Please try again");
                }
                // Catch exception that occurs when the number entered is too long for an Int32
                catch (OverflowException)
                {
                    Console.WriteLine("That number is too long, please try again");
                }
            }
        }


        // Class for my phone book hashtable
        class PhoneBook
        {
            // How many values can our table store? (Because arrays are of a fixed size in C#)
            static int size = 100;

            // How many digits do we expect a phone number to be? (Helps with formatting issues)
            static int phoneNoLength = 10;

            // The table is essentially an array of int-string pairs, so let's declare that
            Tuple<String, int>[] tableRows = new Tuple<String, int>[size];


            // Hash function to map a given phone number to a position in the array of the given size
            // by using the modulus operator (remainder of division) to choose the position
            public int hashThis(int number)
            {
                int remainder = number % size;

                return remainder;
            }


            // Method to add a row to the phone book
            public void AddRow(String name, int phoneNumber)
            {
                // Work out where to put this row by running the hash function on the phone number
                int position = hashThis(phoneNumber);

                // The key-value pair
                Tuple<String, int> rowData = new Tuple<String, int>(name, phoneNumber);

                // Add the "row" tuple to the "table" array in the calculated position
                tableRows[position] = rowData;               
            }


            // Method to search for a phone number
            public void Search(int phoneNumber)
            {
                // Use our hash function to work out where the number would have been positioned
                int position = hashThis(phoneNumber);

                // Get the row and if it's populated, show it
                try
                {
                    Tuple<String, int> result = tableRows[position];
                    string formattedRow = FormatTableRow(result);
                    Console.WriteLine(formattedRow);
                }
                // Catch exception that occurs when the number is not in the array
                catch(NullReferenceException)
                {
                    Console.WriteLine("Number not found, please try again");
                }
            }


            // Method to display the table to the user
            public void Display()
            {
                // Loop through the array
                for(int i = 0; i < size; i++) {

                    if(tableRows[i] != null) // ignore rows with null values, i.e. empty rows
                    {
                        // Get the data stored at this position in the array
                        Tuple<String, int> storedData = tableRows[i];

                        // Format it using our FormatTableRow utility function
                        string formattedRow = FormatTableRow(storedData);

                        // Output it to the user
                        Console.WriteLine(formattedRow);
                    }
                }
            }


            // Utility method to format a phone number as a string
            // (Using this because storing the numbers as integers strips leading 0s)
            public string FormatPhoneNumber(int number)
            {
                return number.ToString().PadLeft(phoneNoLength, '0');
            }
               

            // Utility method to output a formatted table row
            public string FormatTableRow(Tuple<String, int> rowData)
            {
                // Get just the name out of our tuple
                String name = rowData.Item1;

                // Get just the number and then format it using our FormatPhoneNumber utility function
                int number = rowData.Item2;
                string formattedNumber = FormatPhoneNumber(number);

                // Return the row in "Name: number" format
                return name + ": " + formattedNumber;
            }
        }
    }
}
