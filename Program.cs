
using System.Collections.Concurrent;

Random rnd = new Random();

Console.Write("Enter array size: ");
int size = Convert.ToInt32(Console.ReadLine());


int[] arr = new int[size];

Console.WriteLine("\nArray with random valuse:\n");
SetRandomValue(size, arr);
PrintArray(size, arr);






int[] SetRandomValue(int size, int[] arr) 
{
    for (int i = 0; i < size; ++i)
    {
        arr[i] = rnd.Next(1, 25);
    }

    return arr;
}

void PrintArray(int size, int[] arr) 
{
    for (int i = 0; i < size; ++i)
    {
        Console.Write($"{arr[i]}\t");
    }
}
