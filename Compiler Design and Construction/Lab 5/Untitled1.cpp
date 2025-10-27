#include <iostream>
#include <stack>
#include <vector>
#include <map>
#include <string>
#include <sstream>
using namespace std;

// Convert int to string (works in C++98/C++99)
string intToString(int num) {
    stringstream ss;
    ss << num;
    return ss.str();
}

// Structure for grammar rules
struct Rule {
    string lhs;
    vector<string> rhs;
    Rule() {}
    Rule(string l, vector<string> r) { lhs = l; rhs = r; }
};

// Structure for parser actions
struct Action {
    string type; // "shift", "reduce", "accept"
    int value;   // next state or rule number
    Action() {}
    Action(string t, int v) { type = t; value = v; }
};

// Function to split input into tokens
vector<string> tokenize(string input) {
    stringstream ss(input);
    string token;
    vector<string> tokens;
    while (ss >> token) {
        tokens.push_back(token);
    }
    return tokens;
}

int main() {
    cout << "Enter expression (e.g. id + id + id): ";
    string input;
    getline(cin, input);

    // Add end marker
    vector<string> tokens = tokenize(input);
    tokens.push_back("$");

    // Grammar rules
    vector<Rule> rules;
    rules.push_back(Rule("E'", vector<string>(1, "E"))); // Rule 0: E' -> E
    string arr1[] = {"E", "+", "id"};
    rules.push_back(Rule("E", vector<string>(arr1, arr1 + 3))); // Rule 1: E -> E + id
    rules.push_back(Rule("E", vector<string>(1, "id")));        // Rule 2: E -> id

    // ACTION and GOTO tables
    map<pair<int, string>, Action> action;
    map<pair<int, string>, int> goTo;

    // Fill ACTION and GOTO tables manually
    action[make_pair(0, "id")] = Action("shift", 3);
    goTo[make_pair(0, "E")] = 1;
    action[make_pair(1, "+")] = Action("shift", 2);
    action[make_pair(1, "$")] = Action("accept", 0);
    action[make_pair(2, "id")] = Action("shift", 3);
    goTo[make_pair(2, "E")] = 4;
    action[make_pair(3, "+")] = Action("reduce", 2);
    action[make_pair(3, "$")] = Action("reduce", 2);
    action[make_pair(4, "+")] = Action("reduce", 1);
    action[make_pair(4, "$")] = Action("reduce", 1);

    // Parser stacks
    stack<int> stateStack;
    stack<string> symbolStack;
    stateStack.push(0);

    cout << "\nParsing Steps:\n";
    cout << "---------------------------------------------\n";
    cout << "Stack\t\tInput\t\tAction\n";
    cout << "---------------------------------------------\n";

    int ip = 0;
    while (true) {
        int state = stateStack.top();
        string symbol = tokens[ip];
        Action act = action[make_pair(state, symbol)];

        // Print current stack and input
        stack<int> temp = stateStack;
        string st = "";
        vector<int> rev; // to print in correct order
        while (!temp.empty()) {
            rev.push_back(temp.top());
            temp.pop();
        }
        for (int i = rev.size() - 1; i >= 0; i--) {
            st += intToString(rev[i]) + " ";
        }

        cout << st << "\t\t";
        for (size_t i = ip; i < tokens.size(); i++) cout << tokens[i] << " ";
        cout << "\t\t";

        if (act.type == "shift") {
            cout << "Shift " << act.value << endl;
            symbolStack.push(symbol);
            stateStack.push(act.value);
            ip++;
        } 
        else if (act.type == "reduce") {
            Rule r = rules[act.value];
            for (size_t i = 0; i < r.rhs.size(); i++) {
                if (!symbolStack.empty()) symbolStack.pop();
                if (!stateStack.empty()) stateStack.pop();
            }
            symbolStack.push(r.lhs);
            int newState = goTo[make_pair(stateStack.top(), r.lhs)];
            stateStack.push(newState);
            cout << "Reduce by " << r.lhs << " -> ";
            for (size_t i = 0; i < r.rhs.size(); i++) cout << r.rhs[i] << " ";
            cout << endl;
        } 
        else if (act.type == "accept") {
            cout << "Accept! ? Expression is valid.\n";
            break;
        } 
        else {
            cout << "Error ?: Invalid symbol '" << symbol << "' in state " << state << endl;
            break;
        }
    }

    return 0;
}

