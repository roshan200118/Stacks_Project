/*Roshan Nanthapalan and Ethan Spall
 * Dec.21.2017
 * Assignment 3 - a program that can hold string and double (words and numbers) up to a stack of 10.
 * The string has its own stack and the numbers has its own stack.
 * It can add words/numbers and removes words/numbers as well as display the words/numbers in the stack too.
 * You can add, subtract, multiply and divides these numbers.
 * You can also combine the words together.
 * The data last added will be at the top and to get to the bottom you must remove all the data above.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Roshan_Nanthapalan
{
    class Program
    {
        //Declaring a variable to keep track of the elements in the array
        static int doubleIndex = 5;

        //Creating an array for the double stack
        static double[] stackDouble = new double[5];

        //Create a string array called stringStack
        static string[] stringStack = new string[5];

        //An integer to store the number of values in the stringStack array
        static int numberOfValues = 5;


        static void Main(string[] args)
        {
            //Preset array for the double array (stackDouble)
            stackDouble[0] = 0;
            stackDouble[1] = 1;
            stackDouble[2] = 2;
            stackDouble[3] = 3;
            stackDouble[4] = 4;

            //Runs the loop the number of times of the length of the array to display
            //Displays the numbers stack from bottom to top (ex. 0, 1, 2, 3, 4)
            for (int i = doubleIndex - 1; i >= 0; i--)
            {
                Console.WriteLine(stackDouble[i]);
            }

            //Runs the menu loop subprogram (checks the users input)
            MenuLoop();
        }
        
        //A subprogram that puts data at the top of the stack 
        static bool PushNumbersStack(double data)
        {
            //If the array has less than 10 values
            if (stackDouble.Length < 10)
            {
                //Increase the number of elements by 1 
                doubleIndex = doubleIndex + 1; 

                //Runs the ResizeNumbersStack subprogram (resizes the array)
                ResizeNumbersStack();

                //The next element in the array is equal to data (the users input)
                stackDouble[doubleIndex - 1] = data;

                //Returns true
                return true;
            }

            //If the stack is full
            else
            {
                //Return false
                return false;
            }
        }

        //A subprogram that gets and removes the data at the top of the string
        static double PopNumbersStack()
        {
            //Decrease the number of elements by 1 
            doubleIndex = doubleIndex - 1;

            //If the stack is not empty
            if (IsEmptyNumbersStack())
            {
                //Runs the ResizeNumbersStack subprogram (resizes the array)
                ResizeNumbersStack();

                //Returns the last array element
                return stackDouble[doubleIndex - 1];
            }

            //If the stack is empty
            else
            {
                //Return 0
                return 0;
            }
        }

        //Gets the data at the top of the stack
        static double PeekNumbersStack()
        {
            //If the stack is not empty
            if (IsEmptyNumbersStack())
            {
                //Return the last element in the array
                return stackDouble[doubleIndex - 1];
            }

            //Or else return 0 
            else
            {
                return 0;
            }
        }

        //A subprogram that checks if the stack is empty 
        static bool IsEmptyNumbersStack()
        {
            //If the number of elements is less than or equal to 0, the stack is empty
            if (doubleIndex <= 0)
            {
                //Make the index 0 again
                doubleIndex = 0;

                //Return false 
                return false;
            }

            //If the stack is not empty
            else
            {
                //Return true
                return true;
            }
        }

        //A subprogram that shows the numbers in the double array (stackDouble)
        static void ShowNumbersStack()
        {
            //Runs the loop the number of times of the length of the array to display the numbers
            //Displays the numbers in the proper order
            for (int i = doubleIndex - 1; i >= 0; i--)
            {
                Console.WriteLine(stackDouble[i]);
            }
        }

        //A subprogram that resizes the double array (stackDouble) to make it smaller or bigger
        static bool ResizeNumbersStack()
        {
            //If the array length is smaller than or equal to the doubleIndex (number of elements)
            //or if the double index is 0 and the array length is 1 
            if (stackDouble.Length <= doubleIndex || doubleIndex == 0 && stackDouble.Length == 1)
            {
                //Create a bigger array that is equal to the number of values entered (doubleIndex)
                double[] bigger = new double[doubleIndex];

                //For the number of times there are elements in the array, copy the data in the bigger array
                for (int i = 0; i < stackDouble.Length; i++)
                {
                    bigger[i] = stackDouble[i];
                }

                //Make stackDouble array equal the bigger array
                stackDouble = bigger;

                //Returns true after the resize happens
                return true;
            }

            //If the array length is greater than the number of values entered (doubleIndex)
            //and there are 0 or more values entered (doubleIndex)
            else if (stackDouble.Length > doubleIndex && doubleIndex >= 0)
            {
                //Create a smaller array that is equal to the array length -1
                double[] smaller = new double[stackDouble.Length - 1];

                //For the number of times there are elements in the array minus 1, copy the data in the smaller array 
                for (int i = 0; i < stackDouble.Length - 1; i++)
                {
                    smaller[i] = stackDouble[i];
                }

                //Make stackDouble equal the smaller array
                stackDouble = smaller;

                //Returns true after the resize happens
                return true;
            }

            //If the resize didn't happen
            else
            {
                //Return false
                return false;
            }
        }

        
        //A subprogram that takes in the user input
        static void MenuLoop()
        {
            //The program is running 
            bool programRunning = true;

            //Declaring a variable for the user's input
            string command;

            //While the program is running
            while (programRunning == true)
            {
                //Declaring a variable to check if the user inputted a number
                double number;

                //Declaring a variable to convert the number back into a string
                string numberString;

                //Command equals what the user typed in
                //Trims the input so there are no spaces
                //Converts everything into lowercase letters
                command = Console.ReadLine().Trim().ToLower();

                //If the user typed in "-help"
                if (command == "-help")
                {
                    //Run the help subprogram 
                    Help();
                }

                //If the user typed in "-exit"
                else if (command == "-exit")
                {
                    //The program is not running anymore
                    programRunning = false;

                    //Exits the Console Application
                    Environment.Exit(0);
                }

                //If the input (command) can be convertted into a number
                else if (double.TryParse(command,out number))
                {
                    //Number string equals the number 
                    numberString = number.ToString();

                    //Pass on numberString to Person2Input subprogram
                    Person2Input(numberString);
                }

                //If the command is +, -, * or / 
                else if (command == "+" || command == "-" || command == "*" || command == "/")
                {
                    //Pass on the command to Person2Input subprogram
                    Person2Input(command);
                }

                //Or else 
                else
                {
                    //Pass the command to Person2Commands
                    Person2Commands(command);

                    //Person1Input(command);

                    //Person1Commands(command);
                }
            }
        }

        //A subprogram that takes in the user's input (command) and performs the correct command
        //If none of the commands matches, do nothing
        static bool Person2Commands(string command)
        {
            //If the command is "-shownumbers"
            if (command == "-shownumbers")
            {
                //Run the ShowNumbersStack subprogram
                ShowNumbersStack();

                //Returns true if it happened
                return true;
            }

            //If the command is "-undopreviousnumber"
            else if (command == "-undopreviousnumber")
            {
                //Run the PopNumbersStack subprogram
                PopNumbersStack();

                //Returns true if it happened
                return true;
            }

            //If the command is "-getpreviousnumber"
            else if (command == "-getpreviousnumber")
            {
                //Write what the last number inputted was by using the PeekNumbersStack subprogram
                Console.WriteLine("The last number was: " + PeekNumbersStack());

                //Returns true if it happened
                return true;
            }

            //Or else 
            else
            {
                //return false
                return false;
            }
        }

        //A subprogram that takes in the user's input and saves it to the stack (stackDouble array)
        static void Person2Input(string data)
        {
            //Declaring a variable to check if the input can be converted to a number
            double number;

            //If data is an operator and the number of values entered is only 1 (the stack has 1 number)
            if (data == "+" && doubleIndex <= 1 || data == "-" && doubleIndex <= 1 || data == "*" && doubleIndex <= 1 || data == "/" && doubleIndex <= 1)
            {
                //Write "Operand expected but not found" because you need 2 numbers
                Console.WriteLine("Operand expected but not found");
            }

            //If data is a + sign
            else if (data == "+")
            {
                //Add the top 2 numbers
                stackDouble[doubleIndex - 2] = stackDouble[doubleIndex - 1] + stackDouble[doubleIndex - 2];

                //Decrease the numbers of values entered (doubleIndex) by 1 
                doubleIndex--;

                //Run the resize subprogram
                ResizeNumbersStack();
            }

            //If data is a - sign
            else if (data == "-")
            {
                //Subtract the bottom number (second recent) from the top number (most recent)
                stackDouble[doubleIndex - 2] = stackDouble[doubleIndex - 1] - stackDouble[doubleIndex - 2];

                //Decrease the numbers of values entered (doubleIndex) by 1 
                doubleIndex--;

                //Run the resize subprogram
                ResizeNumbersStack();
            }

            //If data is a * sign
            else if (data == "*")
            {
                //Multipy the top 2 numbers 
                stackDouble[doubleIndex - 2] = stackDouble[doubleIndex - 1] * stackDouble[doubleIndex - 2];

                //Decrease the numbers of values entered (doubleIndex) by 1 
                doubleIndex--;

                //Run the resize subprogram
                ResizeNumbersStack();
            }

            //If data is a / sign
            else if (data == "/")
            {
                //Divide the top number (most recent) by the bottom number (second recent number)
                stackDouble[doubleIndex - 2] = stackDouble[doubleIndex - 1] / stackDouble[doubleIndex - 2];

                //Decrease the numbers of values entered (doubleIndex) by 1 
                doubleIndex--;

                //Run the resize subprogram
                ResizeNumbersStack();
            }

            //If the user's input can be converted to a number
            if (double.TryParse(data, out number))
            {
                //Pass it on to the PushNumbersStack subprogram
                PushNumbersStack(number);
            }
        }

        //Subprogram that puts data on the top of the stack
        static bool PushStringStack(string data)
        {
            //Stores the data if the number of already stored values is less than or = to 10
            if (numberOfValues < 10)
            {
                //Saves the data into the array
                stringStack[numberOfValues] = data; 
         
                //Number of values increases
                numberOfValues++;
         
                //Call the subprogram to check if the array needs to bne resized
                ResizeStringStack();
         
                return true;
            }

            else
            {
                return false;
            }
        }


        static string PopStringStack()
        {
            //Check to see if the array is not empty
            if (IsEmptyStringStack() == false)
            {
                //Decrease number of entered values by 1
                numberOfValues--;

                //Checks if the array needs to be resized
                ResizeStringStack();

                //Return the new sized array
                return stringStack[numberOfValues - 1];
            }
            //If the stack is empty
            else
            {
                return null;
            }
        }

        static string PeekStringStack()
        {
            //Checks if the stack is not empty
            if (IsEmptyStringStack() == false)
            {
                //Returns the index at the top of the stack
                return stringStack[numberOfValues - 1];
            }
            //If the stack is empty
            else
            {
                return null;
            }
        }

        //Checks if the stack is empty
        static bool IsEmptyStringStack()
        {
            //If the number of entered values is 0 then the stack is empty; return true
            if (numberOfValues == 0)
            {
                return true;
            }
            //If not then return false
            else
            {
                return false;
            }
        }

        static void ShowStringStack()
        {
            //Displays the full stack in order
            for (int i = numberOfValues - 1; i >= 0; i--)
            {
                Console.WriteLine(stringStack[i]);
            }
        }

        //Subprogram to check if the array needs to be resized
        static bool ResizeStringStack()
        {
            //If the array length is greater or equal to the number of values stored then the array is resized
            if (stringStack.Length >= numberOfValues)
            {
                //create a larger array to resize into
                string[] larger = new string[stringStack.Length + 1];
                for (int i = 0; i < larger.Length; i++)
                {
                    //Copy the smaller array into the larger one
                    larger[i] = stringStack[i];
                }
                //Make the original equal to the resized array
                stringStack = larger;
                return true;
            }
            //Resize the array if the length of the array is smaller than the number of values entered and the number of values is greater than 0
            else if (stringStack.Length <= numberOfValues && numberOfValues > 0)
            {
                //Create a smaller array to be resized into
                string[] smaller = new string[stringStack.Length - 1];
                for (int i = 0; i < stringStack.Length; i++)
                {
                    //Copy the values of the larger array into the smaller array
                    smaller[i] = stringStack[i];
                }
                //Make the original equal to the resized array
                stringStack = smaller;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //Help menu that displays when the command is called
        static void Help()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                 Help Menu:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\n" + "-showStrings: Print out the contents of the string stack");
            Console.WriteLine("\r\n" + "-showNumbers: Print out the contents of the numbers stack");
            Console.WriteLine("\r\n" + "-undoPreviousString: Remove the last string that the user typed in, if there was one");
            Console.WriteLine("\r\n" + "-undoPreviousNumber: Remove the last number that the user typed in, if there was one");
            Console.WriteLine("\r\n" + "-getPreviousString: Get, but do not remove, the last string that the user typed in, if there was one");
            Console.WriteLine("\r\n" + "-getPreviousNumber: Get, but do not remove, the last number that the user typed in, if there was one");
            Console.WriteLine("\r\n" + "-help:  Show all the commands and their3 descriptions");
            Console.WriteLine("\r\n" + "-exit:  Exit the menu loop");
        }

        //Subprogram for running the commands for person1
        static bool Person1Commands(string command)
        {
            //Run the ShowStringStack command if the text is entered
            if (command == "-showstrings")
            {
                ShowStringStack();
                return true;
            }
            //Run the PopStringStack command if the text is entered
            else if (command == "-undopreviousstring")
            {
                PopStringStack();
                return true;
            }
            //Run the PeekStringStack command and print the string on a line
            else if (command == "-getpreviousstring")
            {
                Console.WriteLine("The previous string was: " + PeekStringStack());
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool Person1Input(string command)
        {
            //Create a bool to check if the input is a string
            bool IsInputANumber = false;

            //Create a double to check if the input is a string
            double checkNumber;

            if (double.TryParse(command, out checkNumber))
            {
                IsInputANumber = true;
                return false;
            }

            else if (IsInputANumber == false && command != "+" && command != "-" && command != "*" && command != "/")
            {
                //Saves the input into the top of the stack
                PushStringStack(command);
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
