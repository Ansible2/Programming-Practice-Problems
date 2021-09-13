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

class Result
{

    /*
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> numberList_1, List<int> numberList_2)
    {
        int numberInBetween = 0;
        //numberList_1.Sort();
        //numberList_2.Sort();
        
        for (int i = numberList_1.Min(); i <= numberList_2.Min(); i++)
        {
            var count_1 = numberList_1.Count(x => i % x == 0);
            if (count_1 == numberList_1.Count)
            {
                var count_2 = numberList_2.Count(x => x % i == 0);
                if (count_2 == numberList_2.Count)
                {
                    numberInBetween++;
                }
            }
        }

        return numberInBetween;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        Console.WriteLine(total);
        //textWriter.WriteLine(total);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
