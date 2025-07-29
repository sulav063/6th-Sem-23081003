#include <iostream>
#include <vector>
using namespace std;

vector<string> stackSymbols;
string input = "id+id*id";
int i = 0;

void printStack() {
    cout << "Stack: ";
    for (size_t j = 0; j < stackSymbols.size(); ++j) {
        cout << stackSymbols[j] << " ";
    }
    cout << endl;
}

bool reduce() {
    int n = stackSymbols.size();

    if (n >= 3 && stackSymbols[n - 3] == "T" && stackSymbols[n - 2] == "*" && stackSymbols[n - 1] == "F") {
        cout << "Reduce: T * F -> T\n";
        stackSymbols.erase(stackSymbols.end() - 3, stackSymbols.end());
        stackSymbols.push_back("T");
        return true;
    }

    if (n >= 3 && stackSymbols[n - 3] == "E" && stackSymbols[n - 2] == "+" && stackSymbols[n - 1] == "T") {
        if (i < (int)input.length() && input[i] == '*') return false; // delay reduction if * ahead
        cout << "Reduce: E + T -> E\n";
        stackSymbols.erase(stackSymbols.end() - 3, stackSymbols.end());
        stackSymbols.push_back("E");
        return true;
    }

    if (n >= 1 && stackSymbols[n - 1] == "id") {
        cout << "Reduce: id -> F\n";
        stackSymbols.back() = "F";
        return true;
    }

    if (n >= 1 && stackSymbols[n - 1] == "F") {
        cout << "Reduce: F -> T\n";
        stackSymbols.back() = "T";
        return true;
    }

    if (n >= 1 && stackSymbols[n - 1] == "T") {
        if (i < (int)input.length() && input[i] == '*') return false; // delay T -> E if * ahead
        cout << "Reduce: T -> E\n";
        stackSymbols.back() = "E";
        return true;
    }

    return false;
}

int main() {
    while (i < (int)input.length()) {
        if (input.substr(i, 2) == "id") {
            cout << "Shift: id\n";
            stackSymbols.push_back("id");
            i += 2;
        } else {
            cout << "Shift: " << input[i] << "\n";
            stackSymbols.push_back(string(1, input[i++]));
        }

        while (reduce()) printStack();
        printStack();
    }

    while (reduce()) printStack();

    if (stackSymbols.size() == 1 && stackSymbols[0] == "E")
        cout << "Input string accepted!\n";
    else
        cout << "Input string rejected!\n";

    return 0;
}

