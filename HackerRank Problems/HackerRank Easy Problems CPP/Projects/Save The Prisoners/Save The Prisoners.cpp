//#include <bits/stdc++.h>
#include <vector>
#include <string>
#include <unordered_map>
#include <iostream>

using namespace std;

string ltrim(const string&);
string rtrim(const string&);
vector<string> split(const string&);

/*
 * Complete the 'saveThePrisoner' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts following parameters:
 *  1. INTEGER n
 *  2. INTEGER m
 *  3. INTEGER s
 */


int saveThePrisoner(int numberOfPrisoners, int numberOfSweets, int startingChairNumber) {
    return ((numberOfSweets - 1) + (startingChairNumber - 1)) % numberOfPrisoners + 1;
}

// slow loop approach
/*
int saveThePrisoner(int numberOfPrisoners, int numberOfSweets, int startingChairNumber) {
    int currentChairNumber = startingChairNumber;
    for (int candiesPassedOut = 1; candiesPassedOut < numberOfSweets; candiesPassedOut++) {
        
        if (currentChairNumber > numberOfPrisoners) {
            currentChairNumber = 1;
        }
        currentChairNumber++;
    }

    return currentChairNumber;
}
*/

// oop slow approach
/*
class prisoner
{
private:
    int chairNumber;
    prisoner* nextChair;

public:
    void setChairNumber(int chairNumber_) {
        chairNumber = chairNumber_;
    }
    int getChairNumber() {
        return chairNumber;
    }

    void setNextChair(prisoner* nextChair_) {
        nextChair = nextChair_;
    }
    prisoner* getNextChair() {
        return nextChair;
    }

    prisoner() 
        : chairNumber(-1), nextChair(nullptr){
    }
    prisoner(int chairNumber_) 
        : chairNumber(chairNumber_), nextChair(nullptr){
    }
    prisoner(int chairNumber_, prisoner &nextChair_) 
        : chairNumber(chairNumber_), nextChair(&nextChair_){
    }

    ~prisoner() {
        //cout << "deconstructor called" << endl;
    }

};

int saveThePrisoner(int numberOfPrisoners, int numberOfSweets, int startingChairNumber) {
    prisoner* previousPrisoner{ nullptr };
    prisoner* startingPrisoner{ nullptr };
    prisoner* firstPrisoner{ nullptr };

    for (int i = 1; i <= numberOfPrisoners; i++) {
        
        prisoner* currentPrisoner = new prisoner(i);
        if (i == startingChairNumber) {
            startingPrisoner = currentPrisoner;
        }


        if (i == 1) {
            firstPrisoner = currentPrisoner;
        }
        else {
            previousPrisoner->setNextChair(currentPrisoner);

        }
        
        if (i == numberOfPrisoners) {
            currentPrisoner->setNextChair(firstPrisoner);
        }

        previousPrisoner = currentPrisoner;
    }



    int prisonerToSave = -1;
    prisoner* currentPrisonerAdd{ startingPrisoner };
    for (int i = 1; i <= numberOfSweets; i++) {
        if (i == numberOfSweets) {
            prisonerToSave = currentPrisonerAdd->getChairNumber();
            cout << "found prisoner to save" << endl;
        }
        else {
            currentPrisonerAdd = currentPrisonerAdd->getNextChair();
        }
        
    }


    prisoner* currentAddress{ nullptr };
    prisoner* nextAddress{ firstPrisoner };
    for (int i = 1; i <= numberOfPrisoners; i++) {
        currentAddress = nextAddress;
        nextAddress = currentAddress->getNextChair();
        delete currentAddress;
    }

    return prisonerToSave;
}
*/


int main()
{
    cout << saveThePrisoner(5,2,2) << endl;
    cout << saveThePrisoner(7,19,2) << endl;
    cout << saveThePrisoner(3,7,3) << endl;


    /*
    ofstream fout(getenv("OUTPUT_PATH"));

    string t_temp;
    getline(cin, t_temp);

    int t = stoi(ltrim(rtrim(t_temp)));

    for (int t_itr = 0; t_itr < t; t_itr++) {
        string first_multiple_input_temp;
        getline(cin, first_multiple_input_temp);

        vector<string> first_multiple_input = split(rtrim(first_multiple_input_temp));

        int n = stoi(first_multiple_input[0]);

        int m = stoi(first_multiple_input[1]);

        int s = stoi(first_multiple_input[2]);

        int result = saveThePrisoner(n, m, s);

        fout << result << "\n";
    }

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