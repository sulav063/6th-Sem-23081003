#include <iostream>
#include <string>
using namespace std;

struct Node {
    string name;
    bool final;
    Node* a;
    Node* b;

    Node() {
        name = "";
        final = false;
        a = NULL;
        b = NULL;
    }

    void set(string n, bool f) {
        name = n;
        final = f;
        a = NULL;
        b = NULL;
    }
};

class DFA {
public:
    Node start, mid, accept, dead;
    Node* current;

    DFA() {
        // Initialize nodes
        start.set("start", false);
        mid.set("mid", false);
        accept.set("accept", true);
        dead.set("dead", false);

        // Transitions from start
        start.a = &mid;
        start.b = &dead;

        // Transitions from mid
        mid.a = &mid;
        mid.b = &accept;

        // Transitions from accept
        accept.a = &mid;
        accept.b = &accept;

        // Transitions from dead
        dead.a = &dead;
        dead.b = &dead;

        current = &start;
    }

    bool test(string input) {
        current = &start;

        for (int i = 0; i < input.length(); i++) {
            char c = input[i];
            if (c == 'a') {
                current = current->a;
            } else if (c == 'b') {
                current = current->b;
            } else {
                return false; // invalid character
            }

            if (current == &dead) {
                return false;
            }
        }

        return current == &accept;
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

