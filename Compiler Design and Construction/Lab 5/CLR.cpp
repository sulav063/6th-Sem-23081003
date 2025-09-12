#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <stack>
using namespace std;

// Structure for parser actions
struct Action {
    string type; // "shift", "reduce", "accept"
    int value;   // next state or rule number

    Action() {}
    Action(string t, int v) {
        type = t;
        value = v;
    }
};

// Structure for grammar rules
struct Rule {
    string lhs;
    vector<string> rhs;

    Rule() {}
    Rule(string l, const vector<string>& r) {
        lhs = l;
        rhs = r;
    }
};

int main() {
    // 1. Define grammar rules
    vector<Rule> rules;
    rules.push_back(Rule("", vector<string>(1, "E")));                 // dummy start
    rules.push_back(Rule("E", vector<string>(3, "E"))); rules[1].rhs[1] = "+"; rules[1].rhs[2] = "T";
    rules.push_back(Rule("E", vector<string>(1, "T")));
    rules.push_back(Rule("T", vector<string>(1, "F")));
    rules.push_back(Rule("F", vector<string>(1, "id")));
    rules.push_back(Rule("F", vector<string>(3, "("))); rules[5].rhs[1] = "E"; rules[5].rhs[2] = ")";

    // 2. Action and Goto tables (hardcoded minimal demo)
    map<pair<int,string>, Action> action;
    map<pair<int,string>, int> goTo;

    // State 0
    action[make_pair(0,"id")] = Action("shift",5);
    action[make_pair(0,"(")]  = Action("shift",4);
    goTo[make_pair(0,"E")] = 1;
    goTo[make_pair(0,"T")] = 2;
    goTo[make_pair(0,"F")] = 3;

    // State 1
    action[make_pair(1,"+")] = Action("shift",6);
    action[make_pair(1,"$")] = Action("accept",-1);

    // State 2
    action[make_pair(2,"+")] = Action("reduce",2);
    action[make_pair(2,")")] = Action("reduce",2);
    action[make_pair(2,"$")] = Action("reduce",2);

    // State 3
    action[make_pair(3,"+")] = Action("reduce",3);
    action[make_pair(3,"*")] = Action("shift",7);
    action[make_pair(3,")")] = Action("reduce",3);
    action[make_pair(3,"$")] = Action("reduce",3);

    // State 4
    action[make_pair(4,"id")] = Action("shift",5);
    action[make_pair(4,"(")]  = Action("shift",4);
    goTo[make_pair(4,"E")] = 8;
    goTo[make_pair(4,"T")] = 2;
    goTo[make_pair(4,"F")] = 3;

    // State 5
    action[make_pair(5,"+")] = Action("reduce",4);
    action[make_pair(5,"*")] = Action("reduce",4);
    action[make_pair(5,")")] = Action("reduce",4);
    action[make_pair(5,"$")] = Action("reduce",4);

    // State 6
    action[make_pair(6,"id")] = Action("shift",5);
    action[make_pair(6,"(")]  = Action("shift",4);
    goTo[make_pair(6,"T")] = 9;
    goTo[make_pair(6,"F")] = 3;

    // State 7
    action[make_pair(7,"id")] = Action("shift",5);
    action[make_pair(7,"(")]  = Action("shift",4);
    goTo[make_pair(7,"F")] = 10;

    // State 8
    action[make_pair(8,"+")] = Action("shift",6);
    action[make_pair(8,")")] = Action("shift",11);

    // State 9
    action[make_pair(9,"+")] = Action("reduce",1);
    action[make_pair(9,")")] = Action("reduce",1);
    action[make_pair(9,"$")] = Action("reduce",1);

    // State 10
    action[make_pair(10,"+")] = Action("reduce",3);
    action[make_pair(10,"*")] = Action("reduce",3);
    action[make_pair(10,")")] = Action("reduce",3);
    action[make_pair(10,"$")] = Action("reduce",3);

    // State 11
    action[make_pair(11,"+")] = Action("reduce",5);
    action[make_pair(11,"*")] = Action("reduce",5);
    action[make_pair(11,")")] = Action("reduce",5);
    action[make_pair(11,"$")] = Action("reduce",5);

    // 3. Initialize parser stack
    stack<int> st;
    st.push(0);

    // 4. Input string
    vector<string> input;
    input.push_back("id");
    input.push_back("+");
    input.push_back("id");
    input.push_back("$");
    int idx = 0;

    cout << "CLR Parsing steps:\n";

    while (true) {
        int state = st.top();
        string symbol = input[idx];

        if (action.find(make_pair(state,symbol)) == action.end()) {
            cout << "Error: unexpected '" << symbol << "' at position " << idx << endl;
            break;
        }

        Action act = action[make_pair(state,symbol)];

        if (act.type == "shift") {
            cout << "Shift " << symbol << endl;
            st.push(act.value);
            idx++;
        }
        else if (act.type == "reduce") {
            Rule rule = rules[act.value];
            cout << "Reduce by " << rule.lhs << " -> ";
            for (size_t i=0; i<rule.rhs.size(); i++)
                cout << rule.rhs[i] << " ";
            cout << endl;

            // Pop stack according to RHS size
            for (size_t i=0; i<rule.rhs.size(); i++) st.pop();

            // Push goto
            int topState = st.top();
            st.push(goTo[make_pair(topState, rule.lhs)]);
        }
        else if (act.type == "accept") {
            cout << "Input accepted " << endl;
            break;
        }
    }

    return 0;
}

