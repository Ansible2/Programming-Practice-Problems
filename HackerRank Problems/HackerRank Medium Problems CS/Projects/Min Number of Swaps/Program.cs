using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arrayToSort)
    {
        Dictionary<int, int> indexDictionary = new Dictionary<int, int>();
        for (int index = 0; index < arrayToSort.Length; index++)
        {
            indexDictionary.Add(arrayToSort[index], index);
        }



        int numberOfSwaps = 0;
        for (int index = 0; index < arrayToSort.Length; index++)
        {
            int numberThatShouldBeInPos = index + 1;
            int currentIndexOfRightNumber = indexDictionary[numberThatShouldBeInPos];

            if (currentIndexOfRightNumber != index)
            {
                numberOfSwaps++;

                int numberInCurrentIndex = arrayToSort[index];
                int numberInSwapIndex = numberThatShouldBeInPos;
                arrayToSort[index] = numberInSwapIndex;
                arrayToSort[currentIndexOfRightNumber] = numberInCurrentIndex;

                indexDictionary[numberInSwapIndex] = index;
                indexDictionary[numberInCurrentIndex] = currentIndexOfRightNumber;
            }
        }
           


        return numberOfSwaps;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);

        Console.WriteLine(res);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
