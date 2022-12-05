﻿// See https://aka.ms/new-console-template for more information

var myChoices = new Dictionary<string, int>
{
    { "X", 1 },
    { "Y", 2 },
    { "Z", 3 }
};

var opponentChoices = new List<string> { "A", "B", "C" };

var rountPoint = CalculateRoundPoint("", "");

int CalculateRoundPoint(string opponentChoice, string myChoice)
{
    switch (opponentChoice)
    {
        case "A":
            switch (myChoice)
            {
                case "X":
                    return 3 + myChoices["X"];
                case "Y":
                    return 6 + myChoices["Y"];
                case "Z":
                    return 0 + myChoices["Z"];
            }

            break;
        case "B":
            switch (myChoice)
            {
                case "X":
                    return 0 + myChoices["X"];
                case "Y":
                    return 3 + myChoices["Y"];
                case "Z":
                    return 6 + myChoices["Z"];
            }

            break;
        case "C":
            switch (myChoice)
            {
                case "X":
                    return 6 + myChoices["X"];
                case "Y":
                    return 0 + myChoices["Y"];
                case "Z":
                    return 3 + myChoices["Z"];
            }

            break;
    }

    return 0;
}