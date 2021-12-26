using System.Diagnostics;

var size = 100_000;

var random = new Random();
var array = new int[size];

for (int i = 0; i < array.Length; i++)
{
    array.SetValue(random.Next(0, size), i);
}

ulong iterations = 0;
var stopWatch = new Stopwatch();
stopWatch.Start();

for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
{
    int largestAt = 0;

    for (int i = 1; i <= partIndex; i++)
    {
        iterations++;

        if (array[i] > array[largestAt])
            largestAt = i;

        int temp = array[largestAt];
        array[largestAt] = array[partIndex];
        array[partIndex] = temp;
    }
}
stopWatch.Stop();

Console.WriteLine($"{iterations} iterations: { stopWatch.ElapsedMilliseconds}ms");