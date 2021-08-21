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
    public static int getNearestIncriment(int number)
    {
        int incriment = 5;

        int newNumber = Math.Abs(number + (incriment / 2));
        newNumber -= newNumber % incriment;

        return newNumber;
    }

    /*
     * Complete the 'gradingStudents' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY grades as parameter.
     */

    public static List<int> gradingStudents(List<int> grades)
    {
        int minDontRound = 38; 
        for (var index = 0; index < grades.Count; index++)
        {
            var grade = grades[index];

            if (grade >= minDontRound)
            {
                int nearestGrade = getNearestIncriment(grade);
                // don't need to check if < 3 applies as it will have to be in order to round up with getNearestIncriment function
                if (nearestGrade > grade)
                {
                    grades[index] = nearestGrade;
                }
            }
        }

        return grades;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        List<int> result = Result.gradingStudents(grades);

        Console.WriteLine();
        foreach (int number in result)
        {
            Console.WriteLine(number);
        }

        //textWriter.WriteLine(String.Join("\n", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
