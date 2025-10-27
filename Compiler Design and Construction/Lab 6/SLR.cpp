#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <stack>
using namespace std;

struct Action {
    string type; // "shift", "reduce", "accept"
    int value;   // next state or rule number
    Action() {}
    Action(string t, int v) { type = t; value = v; }
};

struct Rule {
    string lhs;
    vector<string> rhs;
    Rule() {}
    Rule(string l, const vector<string>& r) { lhs = l; rhs = r; }
};

int main() {
    // Grammar rules
    vector<Rule> rules;
    rules.push_back(Rule("", vector<string>(1, "E"))); // 0: dummy start
    rules.push_back(Rule("E", vector<string>(3, "E")));
    rules[1].rhs[1] = "+";
    rules[1].rhs[2] = "T";
    rules.push_back(Rule("E", vector<string>(1, "T")));   // 2
    rules.push_back(Rule("T", vector<string>(1, "F")));   // 3
    rules.push_back(Rule("F", vector<string>(1, "id")));  // 4
    rules.push_back(Rule("F", vector<string>(3, "(")));
    rules[5].rhs[1] = "E";
    rules[5].rhs[2] = ")";

    // Action & Goto tables
    map<pair<int,string>, Action> action;
    map<pair<int,string>, int> goTo;

    // ACTION table
    action[make_pair(0,"id")] = Action("shift",5);
    action[make_pair(0,"(")]  = Action("shift",4);

    action[make_pair(1,"+")] = Action("shift",6);
    action[make_pair(1,"$")] = Action("accept",-1);

    action[make_pair(2,"+")] = Action("reduce",2); // E -> T
    action[make_pair(2,")")] = Action("reduce",2);
    action[make_pair(2,"$")] = Action("reduce",2);

    action[make_pair(3,"+")] = Action("reduce",3); // T -> F
    action[make_pair(3,"*")] = Action("shift",7);
    action[make_pair(3,")")] = Action("reduce",3);
    action[make_pair(3,"$")] = Action("reduce",3);

    action[make_pair(5,"+")] = Action("reduce",4); // F -> id
    action[make_pair(5,")")] = Action("reduce",4);
    action[make_pair(5,"$")] = Action("reduce",4);

    // State 6
    action[make_pair(6,"id")] = Action("shift",5);
    action[make_pair(6,"(")]  = Action("shift",4);
    goTo[make_pair(6,"T")] = 9;
    goTo[make_pair(6,"F")] = 3;

    // State 9
    action[make_pair(9,"+")] = Action("reduce",1); // E -> E + T
    action[make_pair(9,")")] = Action("reduce",1);
    action[make_pair(9,"$")] = Action("reduce",1);

    // GOTO table
    goTo[make_pair(0,"E")] = 1;
    goTo[make_pair(0,"T")] = 2;
    goTo[make_pair(0,"F")] = 3;

    goTo[make_pair(4,"E")] = 8;
    goTo[make_pair(4,"T")] = 2;
    goTo[make_pair(4,"F")] = 3;

    // Stack
    stack<int> st;
    st.push(0);

    // ? Test input
    vector<string> input;
    input.push_back("id");
    input.push_back("+");
    input.push_back("id");
    input.push_back("$");

    int idx = 0;
    cout << "SLR Parsing steps:\n";

     while (true) {
        int state = st.top();
        string symbol = input[idx];

        if (action.find(make_pair(state,symbol)) == action.end()) {
            cout << "Error: unexpected '" << symbol
                 << "' at position " << idx << endl;
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

            // pop RHS
            for (size_t i=0; i<rule.rhs.size(); i++) st.pop();

            // goto
            int topState = st.top();
            st.push(goTo[make_pair(topState,rule.lhs)]);
        }
        else if (act.type == "accept") {
            cout << "Input accepted" << endl;
            break;
        }
    }

    return 0;
}

