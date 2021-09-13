//#include <bits/stdc++.h>
#include <vector>
#include <string>
#include <unordered_map>
#include <iostream>
#include <math.h>
#include <algorithm>

using namespace std;

string ltrim(const string&);
string rtrim(const string&);
vector<string> split(const string&);

/*
 * Complete the 'getTotalX' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts following parameters:
 *  1. INTEGER_ARRAY a
 *  2. INTEGER_ARRAY b
 */

int getTotalX(vector<int> list_1, vector<int> list_2) {
    int numberOfSets = 0;

    auto list_1_min{ *min_element(list_1.begin(), list_1.end()) };
    auto list_2_min{ *min_element(list_2.begin(), list_2.end()) };
    for (int i = list_1_min; i <= list_2_min; i++) {
        
        if (all_of( list_1.begin(), list_1.end(), [i](int x) {return i % x == 0; } ) ) {
            if (all_of(list_2.begin(), list_2.end(), [i](int x) {return x % i == 0;}) ) {
                numberOfSets++;
            }
        }
    }


    return numberOfSets;
}

int main()
{
    vector<int> list_1{ 2,4 };
    vector<int> list_2{ 16,32,96 };

    cout << getTotalX(list_1,list_2);
    /*
    ofstream fout(getenv("OUTPUT_PATH"));

    string first_multiple_input_temp;
    getline(cin, first_multiple_input_temp);

    vector<string> first_multiple_input = split(rtrim(first_multiple_input_temp));

    int n = stoi(first_multiple_input[0]);

    int m = stoi(first_multiple_input[1]);

    string arr_temp_temp;
    getline(cin, arr_temp_temp);

    vector<string> arr_temp = split(rtrim(arr_temp_temp));

    vector<int> arr(n);

    for (int i = 0; i < n; i++) {
        int arr_item = stoi(arr_temp[i]);

        arr[i] = arr_item;
    }

    string brr_temp_temp;
    getline(cin, brr_temp_temp);

    vector<string> brr_temp = split(rtrim(brr_temp_temp));

    vector<int> brr(m);

    for (int i = 0; i < m; i++) {
        int brr_item = stoi(brr_temp[i]);

        brr[i] = brr_item;
    }

    int total = getTotalX(arr, brr);

    fout << total << "\n";

    fout.close();
    */

    return 0;
}

/*
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
*/