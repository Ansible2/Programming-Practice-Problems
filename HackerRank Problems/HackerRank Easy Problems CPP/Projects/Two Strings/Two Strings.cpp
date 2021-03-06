//#include <bits/stdc++.h>
#include <vector>
#include <string>
#include <unordered_map>
#include <unordered_set>
#include <iostream>

#define AND &&

using namespace std;

string ltrim(const string&);
string rtrim(const string&);

/*
 * Complete the 'twoStrings' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts following parameters:
 *  1. STRING s1
 *  2. STRING s2
 */

string twoStrings(string string1, string string2) {
    unordered_set<char> string_1_set = unordered_set<char>(string1.begin(), string1.end());
    unordered_set<char> string_2_set = unordered_set<char>(string2.begin(), string2.end());

    auto string2End = string_2_set.end();
    for (char character : string_1_set) {

        auto found = string_2_set.find(character);
        if (found != string2End) {
            return "YES";
        }
    }

    return "NO";

    // first attempt
    /*
    bool shareSubstring = false;
    auto string2End = string_2_set.end();
    for (char character : string_1_set) {
        
        auto found = string_2_set.find(character);
        if (found != string2End) {
            shareSubstring = true;
            break;
        }
    }


    if (shareSubstring) {
        return "YES";
    }
    else {
        return "NO";
    }
    */
}

int main()
{
    ofstream fout(getenv("OUTPUT_PATH"));

    string q_temp;
    getline(cin, q_temp);

    int q = stoi(ltrim(rtrim(q_temp)));

    for (int q_itr = 0; q_itr < q; q_itr++) {
        string s1;
        getline(cin, s1);

        string s2;
        getline(cin, s2);

        string result = twoStrings(s1, s2);

        fout << result << "\n";
    }

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
