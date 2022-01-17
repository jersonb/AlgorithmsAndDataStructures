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
Console.WriteLine(string.Join(", ", array));
stopWatch.Start();


int[] aux = new int[array.Length];
Sort(0, array.Length - 1);

void Sort(int low, int high)
{
    if (high <= low)
        return;

    int mid = (high + low) / 2;
    Sort(low, mid);
    Sort(mid + 1, high);
    Merge(low, mid, high);
}

void Merge(int low, int mid, int high)
{
    if (array[mid] <= array[mid + 1])
        return;

    int i = low;
    int j = mid + 1;

    Array.Copy(array, low, aux, low, high - low + 1);

    for (int k = low; k <= high; k++)
    {
        if (i > mid) array[k] = aux[j++];
        else if (j > high)
            array[k] = aux[i++];
        else if (aux[j] < aux[i])
            array[k] = aux[j++];
        else
            array[k] = aux[i++];
            
        iterations++;
    }
}

stopWatch.Stop();
Console.WriteLine(string.Join(", ", array));

Console.WriteLine($"{iterations} iterations: { stopWatch.ElapsedMilliseconds}ms");