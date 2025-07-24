#include <iostream>
#include <string>
using namespace std;

class DFA {
    int state;
 
public:
    DFA() {
        state = 0; // start at q0
    }

    bool test(string input) {
        state = 0;

        for (int i = 0; i < input.length(); i++) {
            char c = input[i];

            switch (state) {
                case 0:
                    if (c == 'a') state = 1;
                    else if (c == 'b') state = 0;
                    else return false;
                    break;

                case 1:
                    if (c == 'a') state = 1;
                    else if (c == 'b') state = 2;
                    else return false;
                    break;

                case 2:
                    if (c == 'a') state = 1;
                    else if (c == 'b') state = 3;
                    else return false;
                    break;

                case 3:
                    if (c == 'a') state = 1;
                    else if (c == 'b') state = 0;
                    else return false;
                    break;
            }
        }

        return state == 3; // q3 is the final state
    }
};

int main() {
    DFA dfa;
    string input;
    cout << "Enter a string (only a and b): ";
    cin >> input;

    if (dfa.test(input)) {
        cout << input << " is accepted." << endl;
    } else {
        cout << input << " is rejected." << endl;
    }

    return 0;
}

