var str = File.ReadLines(@"C:\Git\AdventOfCode2022\AdventOfCode2022\Day06\Data.txt").First();

var markerPosition = FindFirstMarkerPosition(str);
var messagePosition = FindFirstMessagePosition(str);

Console.WriteLine(markerPosition);
Console.WriteLine(messagePosition);


int FindFirstMarkerPosition(string s)
{
    for (var i = 4; i < s.Length; i++)
    {
        var from = i - 4;
        var to = i;
        var substring = s[from..to];
        if (substring.Distinct().Count() == 4) return i;
    }

    return 0;
}

int FindFirstMessagePosition(string s)
{
    for (var i = 14; i < s.Length; i++)
    {
        var from = i - 14;
        var to = i;
        var substring = s[from..to];
        if (substring.Distinct().Count() == 14) return i;
    }

    return 0;
}