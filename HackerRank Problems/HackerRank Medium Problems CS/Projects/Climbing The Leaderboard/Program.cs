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
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> leaderboardScores, List<int> playerScores)
    {
        HashSet<int> uniqueScores = new HashSet<int>(leaderboardScores);
        var numberOfUniqueScores = uniqueScores.Count;
        var leaderboardTruncated = uniqueScores.ToList();
        leaderboardTruncated.Sort();
        leaderboardTruncated.Reverse();

        List<int> ranks = new List<int>();

        int numberOfPlayerScores = playerScores.Count;
        int playerScoreIndex = numberOfPlayerScores - 1; // counting down
        int leaderboardPosition = 1;
        while (playerScoreIndex >= 0)
        {
            int playerScore = playerScores[playerScoreIndex];
            if (leaderboardPosition <= numberOfUniqueScores)
            {
                int leaderboardIndex = leaderboardPosition - 1;
                int leaderboardPosScore = leaderboardTruncated[leaderboardIndex];

                if (playerScore > leaderboardPosScore)
                {
                    ranks.Add(leaderboardPosition);
                    playerScoreIndex--;
                }
                else if (playerScore < leaderboardPosScore)
                {
                    leaderboardPosition++;
                }
                else if (playerScore == leaderboardPosScore)
                {
                    ranks.Add(leaderboardPosition);
                    playerScoreIndex--;

                    // if we have two or more equal player scores in a row
                    if (playerScoreIndex >= 0 && playerScore != playerScores[playerScoreIndex])
                    {
                        leaderboardPosition++;
                    }                
                    
                }
            }
            else // scores below all the leaderboard scores
            {
                ranks.Add(leaderboardPosition);
                playerScoreIndex--;
            }
            
        }

        ranks.Reverse();
        return ranks;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        Console.WriteLine(String.Join("\n", result));
        Console.WriteLine();
        Console.WriteLine(result.Count(x => x == 1));
        Console.WriteLine(player.Count(x => x >= 295));

        //textWriter.WriteLine(String.Join("\n", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}


/*
88
88
87
85
84
84
83
82
81
81
80
80
80
80
79
79
79
79
79
79
79
79
77
75
75
74
73
73
73
71
71
71
71
71
71
70
70
69
69
68
68
68
68
67
67
67
66
66
65
65
64
64
62
61
61
60
59
59
59
59
59
59
58
57
56
56
55
55
53
52
52
51
51
51
51
51
51
51
51
51
51
51
51
51
50
50
50
50
49
49
48
48
47
47
47
45
43
42
42
41
38
36
    36
    36
36
    35
    35
    35
    35
    35
    35
34
    34
    34
    33
    33
    33
    33
    33
    32
    30
    28
    28
    28
    28
    27
    27
    27
    26
    23
    23
    22
    22
    20
    20
    20
18
18
    15
    15
    14
    14
    13
    13
11
11
    10
    10
    8
    8
    7
    6
    5
    4
    4
    4
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
    1
*/