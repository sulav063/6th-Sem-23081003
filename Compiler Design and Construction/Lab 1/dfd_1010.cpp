#include <iostream>
#include <string>
using namespace std;

struct Node {
    string name;
    bool final;
    Node* zero;
    Node* one;

    Node() {
        name = "";
        final = false;
        zero = NULL;
        one = NULL;
    }

    void set(string n, bool f) {
        name = n;
        final = f;
        zero = NULL;
        one = NULL;
    }
};

class DFA {
public:
    Node q0, q1, q2, q3, q4, dead;
    Node* current;

    DFA() {
        // Initialize nodes
        q0.set("q0", false);
        q1.set("q1", false);
        q2.set("q2", false);
        q3.set("q3", false);
        q4.set("q4", true);
        dead.set("dead", false);

        // Transitions from q0
        q0.one = &q1;
        q0.zero = &dead;

        // Transitions from q1
        q1.zero = &q2;
        q1.one = &dead;

        // Transitions from q2
        q2.one = &q3;
        q2.zero = &dead;

        // Transitions from q3
        q3.zero = &q4;
        q3.one = &dead;

        // Transitions from q4
        q4.zero = &dead;
        q4.one = &dead;

        // Dead state
        dead.zero = &dead;
        dead.one = &dead;

        current = &q0;
    }

    bool test(string input) {
        current = &q0;
        for (int i = 0; i < input.length(); i++) {
            char c = input[i];
            if (c == '0') {
                current = current->zero;
            } else if (c == '1') {
                current = current->one;
            } else {
                return false; // Invalid character
            }

            if (current == &dead) {
                return false;
            }
        }
        return current->final;
    }
};

int main() {
    DFA dfa;
    string input;
    cout << "Enter input string: ";
    cin >> input;

    if (dfa.test(input)) {
        cout << input << " is accepted." << endl;
    } else {
        cout << input << " is rejected." << endl;
    }

    return 0;
}
