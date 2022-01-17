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
//Console.WriteLine(string.Join(", ",array));
stopWatch.Start();

int gap = 1;
while (gap <= array.Length / 3)
    gap = 3 * gap + 1;

while (gap >= 1)
{
    for (var i = gap; i < array.Length; i++)
    {
        for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
        {
            iterations++;

            int temp = array[j];
            array[j] = array[j - gap];
            array[j - gap] = temp;
        }
    }
    gap /= 3;
}

stopWatch.Stop();
//Console.WriteLine(string.Join(", ",array));

Console.WriteLine($"{iterations} iterations: { stopWatch.ElapsedMilliseconds}ms");