#include <iostream>
#include <cctype>  // for isupper
#include <cstring> // for strcpy, strcat
using namespace std;

int numOfProductions;
char productionSet[10][10]; // Store productions like A->aB

void FIRST(char* Result, char symbol);
void addToResultSet(char Result[], char symbol);

int main()
{
    int i;
    char choice, symbol;
    char result[20];

    cout << "How many productions? ";
    cin >> numOfProductions;

    // Input productions
    for (i = 0; i < numOfProductions; i++)
    {
        cout << "Enter production " << (i + 1) << " (e.g., A->aB): ";
        cin >> productionSet[i];
    }

    do
    {
        cout << "\nFind the FIRST of: ";
        cin >> symbol;

        // Clear result
        result[0] = '\0';

        FIRST(result, symbol); // Get FIRST of symbol

        cout << "FIRST(" << symbol << ") = { ";
        for (i = 0; result[i] != '\0'; i++)
            cout << result[i] << " ";
        cout << "}\n";

        cout << "Press 'y' to continue: ";
        cin >> choice;

    } while (choice == 'y' || choice == 'Y');

    return 0;
}

// Function to add symbol to FIRST set (if not already present)
void addToResultSet(char Result[], char symbol)
{
    for (int i = 0; Result[i] != '\0'; i++)
    {
        if (Result[i] == symbol)
            return; // already in set
    }

    int len = strlen(Result);
    Result[len] = symbol;
    Result[len + 1] = '\0';
}

// Function to compute FIRST(symbol)
void FIRST(char* Result, char symbol)
{
    char subResult[20];
    int foundEpsilon;

    // If terminal, FIRST(symbol) = symbol
    if (!isupper(symbol))
    {
        addToResultSet(Result, symbol);
        return;
    }

    // For non-terminal
    for (int i = 0; i < numOfProductions; i++)
    {
        if (productionSet[i][0] == symbol) // Match LHS
        {
            if (productionSet[i][2] == '$') // epsilon
            {
                addToResultSet(Result, '$');
            }
            else
            {
                int j = 2;
                while (productionSet[i][j] != '\0')
                {
                    foundEpsilon = 0;
                    subResult[0] = '\0';

                    FIRST(subResult, productionSet[i][j]);

                    // Add all from subResult to Result
                    for (int k = 0; subResult[k] != '\0'; k++)
                        addToResultSet(Result, subResult[k]);

                    // If subResult contains epsilon
                    for (int k = 0; subResult[k] != '\0'; k++)
                    {
                        if (subResult[k] == '$')
                        {
                            foundEpsilon = 1;
                            break;
                        }
                    }

                    if (!foundEpsilon)
                        break; // stop if no epsilon

                    j++; // continue with next symbol
                }
            }
        }
    }
}

