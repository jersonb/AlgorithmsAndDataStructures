using System.Diagnostics;

var size = 20;

var random = new Random();
var array = new int[size];

for (int i = 0; i < array.Length; i++)
{
    array.SetValue(random.Next(0, size), i);
}

ulong iterations = 0;
var stopWatch = new Stopwatch();
//Console.WriteLine(string.Join(", ",array));

stopWatch.Start();

for (int partIndex = 1; partIndex < array.Length; partIndex++)
{
    var curUnsorted = array[partIndex];
    var i = 0;
    for (i = partIndex; i > 0 && array[i - 1] > curUnsorted; i--)
    {

        iterations++;
        array[i] = array[i - 1];
    }
    array[i] = curUnsorted;

}
stopWatch.Stop();
//Console.WriteLine(string.Join(", ",array));
Console.WriteLine($"{iterations} iterations: { stopWatch.ElapsedMilliseconds}ms");