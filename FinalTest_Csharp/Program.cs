using System;
using System.Threading;
class HelloWorld
{
    static int size;
    static int[] arr = new int[100];
    static string[] menu = new string[] { "1) Input data", "2) Sort Small To Big", "3) Sort Big To Small", "4) View Result", "5) Demo", "6) Escape" };
    static int select;
    static void Main()
    {
    Start:
        Console.Write("Input array size: ");
        size = Convert.ToInt32(Console.ReadLine());
        if (size <= 5)
        {
            Console.WriteLine("Please add more number into your data!");
            goto Start;
        }
        if (size > 10)
        {
            Console.WriteLine("The maximum is 10, please re-enter your data!");
            goto Start;
        }
        input(arr, size);

        Console.Write("Your Input: ");
        output(arr, size);
        Thread.Sleep(1000);
        Console.Clear();

        select = 0;
        int x = 0;
        int y = 1;
        Console.WriteLine("Menu: ");
        ConsoleKeyInfo ky = new ConsoleKeyInfo();
        while (!Console.KeyAvailable && ky.Key != ConsoleKey.Escape)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.ForegroundColor = select == i ? ConsoleColor.Red : ConsoleColor.White;
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine($"{menu[i]}");
            }
            ky = Console.ReadKey(true);
            switch (ky.Key)
            {
                case ConsoleKey.DownArrow:
                    select += 1;
                    if (select >= menu.Length)
                    {
                        select = 0;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    select -= 1;
                    if (select < 0)
                    {
                        select = menu.Length - 1;
                    }
                    break;

                case ConsoleKey.Enter:
                    if (select == 0)
                    {
                        Console.Clear();
                        goto Start;
                    }
                    if (select == 1)
                    {
                        sort(arr, size, 1);
                    }
                    if (select == 2)
                    {
                        sort(arr, size, 0);
                    }
                    if (select == 3)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 9);
                        Console.WriteLine();
                        Console.Write("Your Result: ");
                        output(arr, size);
                    }
                    if (select == 4)
                    {
                        Console.WriteLine();
                        Console.Write("Your Input: ");
                        output(arr, size);
                        Console.SetCursorPosition(0, 9);
                        Console.Write("\nNew result: ");
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"    {arr[i]}      ");
                        }

                        for (int i = 0; i < size - 1; i++)
                        {
                            for (int j = i + 1; j < size; j++)
                            {
                                if (arr[i] > arr[j])
                                {
                                    int temp = arr[i];
                                    arr[i] = arr[j];
                                    arr[j] = temp;
                                }
                            }
                        }
                        Console.SetCursorPosition(6, 9);
                        Console.Write("\nNew result: ");
                        for (int z = 0; z < size; z++)
                        {
                            Console.Write($"    {arr[z]}      ");
                            Thread.Sleep(1000);
                        }
                    }
                    if (select == 5)
                    {
                        Console.SetCursorPosition(x, y + 10);
                        System.Environment.Exit(0);
                    }
                    break;
            }
        }
    }
        private static void input(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Input n[{i}]: ");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        private static void output(int[] b, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"    {b[i]}      ");
            }
        }
        private static void sort(int[] a, int n, int order)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (order == 1 && a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                    if (order == 0 && arr[i] < arr[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }
    }
