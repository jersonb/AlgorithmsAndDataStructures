
static int Factorial(int n)
{
    if (n == 0)
        return 1;

    Console.Write($"{n} ");

    return n * Factorial(n - 1);
}

//Console.WriteLine($" = {Factorial(10)}!");

static int Fibonacci(int n)
{
    if (n == 0)
        return 0;

    if (n <= 2)
        return 1;

    return Fibonacci(n - 2) + Fibonacci(n - 1);
}

static void FibonacciR(int n)
{
    if (n >= 0)
    {
        Console.Write($"{Fibonacci(n)} ");
        FibonacciR(n - 1);
    }
}

FibonacciR(8);