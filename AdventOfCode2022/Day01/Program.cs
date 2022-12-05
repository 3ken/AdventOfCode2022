var calorieCountPerBackpack = new List<int>();

var currentCalories = 0;
foreach (var line in File.ReadLines(@"C:\Git\AdventOfCode2022\Day01\Data.txt"))
{
    if (string.IsNullOrEmpty(line))
    {
        calorieCountPerBackpack.Add(currentCalories);
        currentCalories = 0;
    }
    else
    {
        currentCalories += int.Parse(line);
    }
}

var topCalorieCount = calorieCountPerBackpack.Max();
Console.WriteLine("Top calorie count " + topCalorieCount);
var topThreeCaloriesCountSum = calorieCountPerBackpack.OrderByDescending(x => x).Take(3).Sum();
Console.WriteLine("Top three calorie count sum: " + topThreeCaloriesCountSum);
Console.ReadLine();