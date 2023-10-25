using System.Linq;
using System.Collections.Concurrent;

Random rnd = new Random();

Console.Write("Enter array size: ");
int size = Convert.ToInt32(Console.ReadLine());

int[] arr = new int[size];

Console.WriteLine("\nArray with random valuse:\n");
SetRandomValue(arr);
PrintArray(arr);

Console.Write("\n\nEnter element which u wanna find in the array: ");
int value = Convert.ToInt32(Console.ReadLine());


Task taskRemoveDuplicates = Task.Run(() => 
{
    Console.WriteLine("\nArray after deleting same elements:\n");
    arr = RemoveDuplicates(arr);
    PrintArray(arr);
});

Task taskSort = taskRemoveDuplicates.ContinueWith(task => 
{
    Console.WriteLine("\n\nArray after sorting elements:\n");
    SortArray(arr);
    PrintArray(arr);
});

Task taskSearch = taskSort.ContinueWith(task => 
{
    Console.WriteLine($"\n\nYour value found: {IsFound(arr, value)}");
});

Console.ReadLine();

int[] SetRandomValue(int[] arr) 
{
    for (int i = 0; i < arr.Length; ++i)
        arr[i] = rnd.Next(1, 25);

    return arr;
}

void PrintArray(int[] arr) 
{
    for (int i = 0; i < arr.Length; ++i)
        Console.Write($"{arr[i]}\t");
}

int[] RemoveDuplicates(int[] arr)
{
    int[] uniqueArr = arr.Distinct().ToArray();

    return uniqueArr;
}

int[] SortArray(int[] arr)
{
    Array.Sort(arr);
    return arr;
}

bool IsFound(int[] arr, int value)
{
    int index = Array.BinarySearch(arr, value);
    
    if (index >= 0)
        return true;

    return false;
}