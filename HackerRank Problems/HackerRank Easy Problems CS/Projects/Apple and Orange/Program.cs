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
     * Complete the 'countApplesAndOranges' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER s
     *  2. INTEGER t
     *  3. INTEGER a
     *  4. INTEGER b
     *  5. INTEGER_ARRAY apples
     *  6. INTEGER_ARRAY oranges
     */

    public static int getNumberOnHouse(List<int> distances, int treeLocation, int houseStart, int houseEnd)
    {
        int numberOnHouse = 0;
        foreach(var objectDist in distances)
        {
            int landingLocation = treeLocation + objectDist;
            if (landingLocation >= houseStart && landingLocation <= houseEnd)
            {
                numberOnHouse++;
            }
        }


        return numberOnHouse;
    }

    public static void countApplesAndOranges(int samsHouse_startingPoint, int samsHouse_endingPoint, int appleTreeLocation, int orangeTreeLocation, List<int> apples, List<int> oranges)
    {
        // method 2
        int numberOfApplesOnHouse = getNumberOnHouse(apples, appleTreeLocation, samsHouse_startingPoint, samsHouse_endingPoint);
        int numberOfOrangesOnHouse = getNumberOnHouse(oranges, orangeTreeLocation, samsHouse_startingPoint, samsHouse_endingPoint);

        // method 1
    /*
        int numberOfApplesOnHouse = 0;
        foreach (var appleDist in apples)
        {
            int appleLandingLocation = appleTreeLocation + appleDist;
            if (appleLandingLocation >= samsHouse_startingPoint && appleLandingLocation <= samsHouse_endingPoint)
            {
                numberOfApplesOnHouse++;
            }

        }

        int numberOfOrangesOnHouse = 0;
        foreach (var orangeDist in oranges)
        {
            int orangeLandingLocation = orangeTreeLocation + orangeDist;
            if (orangeLandingLocation >= samsHouse_startingPoint && orangeLandingLocation <= samsHouse_endingPoint)
            {
                numberOfOrangesOnHouse++;
            }

        }
    */
        Console.WriteLine(numberOfApplesOnHouse);
        Console.WriteLine(numberOfOrangesOnHouse);

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int s = Convert.ToInt32(firstMultipleInput[0]);

        int t = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int a = Convert.ToInt32(secondMultipleInput[0]);

        int b = Convert.ToInt32(secondMultipleInput[1]);

        string[] thirdMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(thirdMultipleInput[0]);

        int n = Convert.ToInt32(thirdMultipleInput[1]);

        List<int> apples = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(applesTemp => Convert.ToInt32(applesTemp)).ToList();

        List<int> oranges = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(orangesTemp => Convert.ToInt32(orangesTemp)).ToList();

        Result.countApplesAndOranges(s, t, a, b, apples, oranges);
    }
}
