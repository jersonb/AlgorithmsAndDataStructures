using System.Diagnostics;

var size = 100_000;

var random = new Random();
var array = new int[size];

for (int i = 0; i < array.Length; i++)
{
    array.SetValue(random.Next(0, 10), i);
}

ulong iterations = 0;
var stopWatch = new Stopwatch();
//Console.WriteLine(string.Join(", ",array));

stopWatch.Start();
for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
{
    for (int i = 0; i < partIndex; i++)
    {
        var j = i + 1;
        iterations++;
        if (array[i] > array[j])
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
stopWatch.Stop();
//Console.WriteLine(string.Join(", ",array));

Console.WriteLine($"{iterations} iterations: { stopWatch.ElapsedMilliseconds}ms");