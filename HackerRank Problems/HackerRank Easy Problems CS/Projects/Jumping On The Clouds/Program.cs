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
     * Complete the 'jumpingOnClouds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY c as parameter.
     */

    public static int jumpingOnClouds(List<int> cloudsToJumpOn)
    {
        int safeCloud = 0;
        int totalJumps = 0;

        for (int index = 0; index < cloudsToJumpOn.Count - 1; index++)
        {
            if (cloudsToJumpOn[index] == safeCloud)
            {
                index++;
            }
            totalJumps++;
        }

        /*
        int numberOfClouds = cloudsToJumpOn.Count;
        int totalJumps = 0;
        int thunderHead = 1;
        int lastIndex = numberOfClouds - 1;

        for (int index = 0; index < numberOfClouds; index++)
        {
            int furthestPossibleCloudPos = index + 2;
            if (furthestPossibleCloudPos <= lastIndex && cloudsToJumpOn[furthestPossibleCloudPos] != thunderHead)
            {
                index++;
                totalJumps++;
            } else if (index != lastIndex)
            {
                totalJumps++;
            }
        }
        */
        return totalJumps;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

        int result = Result.jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
