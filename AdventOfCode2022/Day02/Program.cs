// See https://aka.ms/new-console-template for more information

var myChoices = new Dictionary<string, int> { { "X", 1 }, { "Y", 2 }, { "Z", 3 } };
var totalPoints = 0;
var secondTotalPoints = 0;
foreach (var line in File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day02\Data.txt"))
{
    if (!string.IsNullOrEmpty(line))
    {
        var arguments = line.Split(" ");
        totalPoints += CalculateRoundPoint(arguments[0], arguments[1]);
        secondTotalPoints += CalculateSecondRoundPoint(arguments[0], arguments[1]);
    }
}

Console.WriteLine(totalPoints);
Console.WriteLine(secondTotalPoints);
Console.ReadLine();

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
int CalculateSecondRoundPoint(string opponentChoice, string myChoice)
{
    switch (opponentChoice)
    {
        case "A":
            switch (myChoice)
            {
                case "X":
                    return 0 + myChoices["Z"];
                case "Y":
                    return 3 + myChoices["X"];
                case "Z":
                    return 6 + myChoices["Y"];
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
                    return 0 + myChoices["Y"];
                case "Y":
                    return 3 + myChoices["Z"];
                case "Z":
                    return 6 + myChoices["X"];
            }

            break;
    }

    return 0;
}