#include <iostream>
#include <string>
using namespace std;

string input;
int pos = 0;

// Function declarations
bool E(), Eprime(), T(), Tprime(), F();

// Match and move ahead
bool match(char expected) {
    if (input[pos] == expected) {
        pos++;
        return true;
    }
    return false;
}

// E -> T E'
bool E() {
    return T() && Eprime();
}

// E' -> + T E' | e
bool Eprime() {
    if (input[pos] == '+') {
        pos++;
        return T() && Eprime();
    }
    return true;  // e
}

// T -> F T'
bool T() {
    return F() && Tprime();
}

// T' -> * F T' | e
bool Tprime() {
    if (input[pos] == '*') {
        pos++;
        return F() && Tprime();
    }
    return true;  // e
}

// F -> (E) | id
bool F() {
    if (input[pos] == 'i' && input[pos + 1] == 'd') {
        pos += 2;
        return true;
    } else if (input[pos] == '(') {
        pos++;
        if (E() && input[pos] == ')') {
            pos++;
            return true;
        }
        return false;
    }
    return false;
}

// Main
int main() {
    cout << "Enter input string: ";
    cin >> input;
    input += "$";  // End marker

    if (E() && input[pos] == '$') {
        cout << "Grammar is LL(1) after removing left recursion.\n";
        cout << "String is parsed successfully.\n";
    } else {
        cout << "Parsing failed. String not accepted.\n";
    }

    return 0;
}

