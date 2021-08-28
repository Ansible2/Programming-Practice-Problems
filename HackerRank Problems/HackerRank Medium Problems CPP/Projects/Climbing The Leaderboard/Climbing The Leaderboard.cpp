//#include <bits/stdc++.h>
#include <vector>
#include <string>
#include <unordered_map>
#include <unordered_set>
#include <set>
#include <iostream>

#define AND &&

using namespace std;

string ltrim(const string&);
string rtrim(const string&);
vector<string> split(const string&);

/*
 * Complete the 'climbingLeaderboard' function below.
 *
 * The function is expected to return an INTEGER_ARRAY.
 * The function accepts following parameters:
 *  1. INTEGER_ARRAY ranked
 *  2. INTEGER_ARRAY player
 */

vector<int> climbingLeaderboard(vector<int> leaderboardScores, vector<int> playerScores) {

    // sorting in reverse (greatest at front) order so that we can start at the top of the leaderboard and work downward
    set<int, std::greater<int>> uniqueScores{ leaderboardScores.begin(), leaderboardScores.end() };
    int numberOfUniqueScores{ (int)uniqueScores.size() };
    vector<int> leaderboardTruncated{ uniqueScores.begin(), uniqueScores.end() };


    vector<int> ranks{};
    
    int numberOfPlayerScores{ (int)playerScores.size() };
    int playerScoreIndex{ numberOfPlayerScores - 1 };
    int leaderboardPosition = 1;
    while (playerScoreIndex >= 0) {
        
        int currentPlayerScore{ playerScores[playerScoreIndex] };
        if (leaderboardPosition <= numberOfUniqueScores) {
            int leaderboardIndex{ leaderboardPosition - 1 };
            int leaderboardPosScore{ leaderboardTruncated.at(leaderboardIndex) };

            if (currentPlayerScore > leaderboardPosScore) {
                ranks.push_back(leaderboardPosition);
                playerScoreIndex--;

            }
            else if (currentPlayerScore < leaderboardPosScore) {
                leaderboardPosition++;

            }
            else if (currentPlayerScore == leaderboardPosScore) {
                ranks.push_back(leaderboardPosition);
                playerScoreIndex--;

                // if we have two or more equal player scores in a row
                if (playerScoreIndex >= 0 && currentPlayerScore != playerScores[playerScoreIndex]) {
                    leaderboardPosition++;
                }

            }
        }
        else { // scores below every position on the leaderboard
            ranks.push_back(leaderboardPosition);
            playerScoreIndex--;
        }
    }

    std::reverse(ranks.begin(), ranks.end());
    return ranks;
}

int main()
{
    ofstream fout(getenv("OUTPUT_PATH"));

    string ranked_count_temp;
    getline(cin, ranked_count_temp);

    int ranked_count = stoi(ltrim(rtrim(ranked_count_temp)));

    string ranked_temp_temp;
    getline(cin, ranked_temp_temp);

    vector<string> ranked_temp = split(rtrim(ranked_temp_temp));

    vector<int> ranked(ranked_count);

    for (int i = 0; i < ranked_count; i++) {
        int ranked_item = stoi(ranked_temp[i]);

        ranked[i] = ranked_item;
    }

    string player_count_temp;
    getline(cin, player_count_temp);

    int player_count = stoi(ltrim(rtrim(player_count_temp)));

    string player_temp_temp;
    getline(cin, player_temp_temp);

    vector<string> player_temp = split(rtrim(player_temp_temp));

    vector<int> player(player_count);

    for (int i = 0; i < player_count; i++) {
        int player_item = stoi(player_temp[i]);

        player[i] = player_item;
    }

    vector<int> result = climbingLeaderboard(ranked, player);

    for (size_t i = 0; i < result.size(); i++) {
        fout << result[i];

        if (i != result.size() - 1) {
            fout << "\n";
        }
    }

    fout << "\n";

    fout.close();

    return 0;
}

string ltrim(const string& str) {
    string s(str);

    s.erase(
        s.begin(),
        find_if(s.begin(), s.end(), not1(ptr_fun<int, int>(isspace)))
    );

    return s;
}

string rtrim(const string& str) {
    string s(str);

    s.erase(
        find_if(s.rbegin(), s.rend(), not1(ptr_fun<int, int>(isspace))).base(),
        s.end()
    );

    return s;
}

vector<string> split(const string& str) {
    vector<string> tokens;

    string::size_type start = 0;
    string::size_type end = 0;

    while ((end = str.find(" ", start)) != string::npos) {
        tokens.push_back(str.substr(start, end - start));

        start = end + 1;
    }

    tokens.push_back(str.substr(start));

    return tokens;
}
