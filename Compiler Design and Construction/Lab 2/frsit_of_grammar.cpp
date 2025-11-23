#include <iostream>
#include <vector>
#include <string>
#include <cctype> // for isupper()
using namespace std;

int numProductions;
vector<string> productions; // Stores all grammar productions

// Function declarations
void findFirst(string& result, char symbol);
void addToResult(string& result, char value);

int main() {
    char symbol, choice;
    string result;

    cout << "How many productions? ";
    cin >> numProductions;
    cin.ignore(); // clear input buffer

    productions.resize(numProductions);

    // Input productions
    for (int i = 0; i < numProductions; i++) {
        cout << "Enter production " << (i + 1) << " (e.g., E=TR): ";
        getline(cin, productions[i]);
    }

    do {
        cout << "\nFind FIRST of: ";
        cin >> symbol;

        result.clear(); // empty previous result
        findFirst(result, symbol); // compute FIRST

        // Display the result
        cout << "FIRST(" << symbol << ") = { ";
        for (int i = 0; i < result.length(); i++) {
            cout << result[i] << " ";
        }
        cout << "}" << endl;

        cout << "Do you want to continue? (y/n): ";
        cin >> choice;
    } while (choice == 'y' || choice == 'Y');

    return 0;
}

// Function to find FIRST of a symbol
void findFirst(string& result, char symbol) {
    string tempResult;
    bool hasEpsilon;

    // If the symbol is a terminal (not uppercase), FIRST = itself
    if (!isupper(symbol)) {
        addToResult(result, symbol);
        return;
    }

    // Go through all productions
    for (int i = 0; i < numProductions; i++) {
        if (productions[i][0] == symbol) { // If LHS matches
            if (productions[i][2] == '$') { // epsilon production
                addToResult(result, '$');
            } else {
                int j = 2; // RHS starts at index 2 (after =)
                hasEpsilon = false;

                while (j < productions[i].length()) {
                    tempResult.clear();
                    findFirst(tempResult, productions[i][j]); // recursive call

                    // Add all symbols from tempResult to final result
                    for (int k = 0; k < tempResult.length(); k++) {
                        addToResult(result, tempResult[k]);
                    }

                    // Check if epsilon ($) is in tempResult
                    hasEpsilon = false;
                    for (int k = 0; k < tempResult.length(); k++) {
                        if (tempResult[k] == '$') {
                            hasEpsilon = true;
                            break;
                        }
                    }

                    // If epsilon not found, stop further checking
                    if (!hasEpsilon)
                        break;

                    j++; // check next symbol if epsilon was found
                }
            }
        }
    }
}

// Function to add a symbol to the result if it's not already there
void addToResult(string& result, char value) {
    if (result.find(value) == string::npos) {
        result += value;
    }
}
