/*
    Author: Clinton Daniel
    Date: 1/10/2019
    Comments: This script demonstrates how Big O notation can be used to
              represent the scaling and time it would take to run an array.
              The run time of Big O notation is O(n). Big O is how the run 
              time scales with respect to the input variable.
    Code: This code was adapted from a YouTube video at https://www.youtube.com/watch?v=UxaB1pPHrHE
          by Scott Duffy. Accessed on 1/10/2019. This code was adapted for teaching purposes only. 
*/

using System;

namespace Big_0
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate an instance of an integer array of size 20000 elements
            int[] testArray = new int[20000];

            // O(1) = Constant time to run the algorithm with respect to the size of the input; it doesn't take longer with more input
            PerformSomeAction_01(testArray);

            // O(n) = Scales linearly with respect to the amount of input; Twice the amount to data will take roughly twice as much time
            PerformSomeAction_On(testArray);

            // O(n^2) = Where n is the size of the array, the amount of time it will take this algorithm to run in this method will increase with response to n^2
            PerformSomeAction_On2(testArray);

            // O(log n) - This method executes a basic binary search algorithm
            PerformSomeAction_Ologn(testArray);

            Console.WriteLine("Press any key to exit the program ... ");
            Console.ReadKey(true);
           
        }

        // This method accepts the testArray as an argument and demonstrates O(1)
        static void PerformSomeAction_01(int[] inArray)
        {
            // O(1)
            int loopCount = 0;

            inArray[0] = 1;
            loopCount++;

            Console.WriteLine("O(1) complete in " + loopCount.ToString() + " steps.");
        } // End of PerformSomeAction_O1

        // This method accepts the testArray as an argument and demonstrates O(n)
        static void PerformSomeAction_On(int[] inArray)
        {
            //O(n)
            int loopCount = 0;

            for(int i=0; i < inArray.Length; i++)
            {
                loopCount++;
                inArray[i] = i;
            }
            Console.WriteLine("O(n) complete in " + loopCount.ToString() + " steps.");
            return;
        } // End of PerformSomeAction_On

        // This method accepts the testArray as an argument and demonstrates O(n^2)
        static void PerformSomeAction_On2(int[] inArray)
        {
            // O(n^2)
            int loopCount = 0;
            // Here you are running a loop within a loop. Maybe you are running an expensive search.  
            // Perhaps there is a worse case scenario and a match is not found in the search. So
            // you are looking at the worse case if the outer and inner loops complete with no 
            // interruption. This may take a while and may perform poorly. 
            for(int i = 0;i < inArray.Length; i++)
            {
                for(int j = 0; j < inArray.Length; j++)
                {
                    loopCount++;
                }
            }
            Console.WriteLine("O(n^2) complete in " + loopCount.ToString() + " steps.");
        } // End of PerformSomeAction_On2

        // This method accepts the testArray as an argument and demonstrates O(log n)
        // This is a basic example of a binary search algorithm
        static void PerformSomeAction_Ologn(int[] inArray)
        {
            // O(log n)
            // 2^x = n
            int loopCount = 0;
            // Generate a random number here
            Random rnd = new Random();
            // Now find the random number in the inArray
            int NumberToFind = rnd.Next(0, inArray.Length);
            // Set the Upper to 19999
            int Upper = inArray.Length - 1;
            // Set the Lower to 0
            int Lower = 0;
            // Get the half way point (ie. 9999 if the Upper is 19999
            int indexi = (int)Math.Floor(Upper / 2.0);
            // Start at 20,000 and keep cutting the number of elements in half until we get to
            // the number that was randomly generated. 
            while(NumberToFind != inArray[indexi])
            {
                loopCount++;
                // If the Random number to find is less than helf way between 0 19999 (or 9999)
                if(NumberToFind < inArray[indexi])
                {
                    Upper = indexi;
                    indexi = Lower + (int)Math.Floor((Upper - Lower) / 2.0);
                }
                else
                {
                    Lower = indexi;
                    indexi = Lower + (int)Math.Floor((Upper - Lower) / 2.0);
                }
            } // End of while loop
            Console.WriteLine("O(log n) complete in " + loopCount.ToString() + " steps.");
        } // End of PerformSomeAction_Ologsn

    }
}
