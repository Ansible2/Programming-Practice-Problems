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
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int diagonalDifference(List<List<int>> matrix)
    {
        int numberOfColumns = matrix.Count;
        int lengthOfRow = matrix[0].Count;

        int maxNumberOfDiagonals = Math.Min(numberOfColumns, lengthOfRow);

        int total_1 = 0;
        int total_2 = 0;

        int currentRow = 0;
        int column_1 = 0;
        int column_2 = maxNumberOfDiagonals - 1;
        for (int i = 1; i <= maxNumberOfDiagonals; i++)
        {
            total_1 += matrix[currentRow][column_1];
            total_2 += matrix[currentRow][column_2];

            currentRow += 1;
            column_1 += 1;
            column_2 -= 1;
        }

        int differnce = Math.Abs(total_1 - total_2);

        return differnce;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
