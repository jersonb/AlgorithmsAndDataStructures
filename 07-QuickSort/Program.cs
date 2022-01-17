using System.Diagnostics;

var size = 100_000;
// var size = 20;

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

Sort(0, array.Length - 1);

void Sort(int low, int high)
{
    if (high <= low)
        return;
    int j = Partition(low, high);
    iterations++;
    Sort(low, j - 1);
    Sort(j + 1, high);

}

int Partition(int low, int high)
{
    int i = low;
    int j = high + 1;

    int pivot = array[low];
    while (true)
    {
        while (array[++i] < pivot)
        {
            if (i == high)
                break;
        }

        while (pivot < array[--j])
        {
            if (j == low)
                break;
        }

        if (i >= j)
            break;

        Swap(array, i, j);
    }
    Swap(array, low, j);
    return j;
}

static void Swap(int[] array, int i, int j)
{
    if (i == j)
        return;
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}
stopWatch.Stop();
//Console.WriteLine(string.Join(", ",array));
Console.WriteLine($"{iterations} iterations: { stopWatch.ElapsedMilliseconds}ms");