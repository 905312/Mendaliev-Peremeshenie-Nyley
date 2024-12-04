using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Для поддержки цветного вывода
        Console.Title = "Перемещение нулей в конец массива";

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Добро пожаловать в программу перемещения нулей в конец!   ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("Доступные команды:");
            Console.WriteLine("1. Введите 'help' для вывода инструкции.");
            Console.WriteLine("2. Введите 'example' для вывода примера правильного ввода.");
            Console.WriteLine("3. Введите элементы массива через запятую без пробелов.");
            Console.WriteLine("-----------------------------------------------------------");

            Console.Write("Введите команду или элементы массива: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "help")
            {
                ShowHelp();
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                continue;
            }
            else if (input.ToLower() == "example")
            {
                ShowExample();
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                continue;
            }

            // Проверка корректности ввода
            if (!IsValidInput(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Некорректный ввод. Пожалуйста, введите числа через запятую без пробелов.");
                Console.ResetColor();
                Console.WriteLine("Нажмите любую клавишу для повторного ввода...");
                Console.ReadKey();
                continue;
            }

            // Преобразуем введенную строку в массив целых чисел
            int[] nums = input.Split(',')
                              .Select(int.Parse)
                              .ToArray();

            // Вызов функции для перемещения нулей в конец массива
            MoveZerosToEnd(nums);

            // Вывод результата
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Результат: [{string.Join(",", nums)}]");
            Console.ResetColor();

            Console.WriteLine("Нажмите любую клавишу для повторного ввода или Esc для выхода...");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    static void ShowHelp()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ Инструкция:                                                ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine("1. Введите элементы массива через запятую без пробелов.");
        Console.WriteLine("2. Программа переместит все нули в конец массива, сохраняя относительный порядок ненулевых элементов.");
        Console.WriteLine("-----------------------------------------------------------");
    }

    static void ShowExample()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ Пример правильного ввода:                                  ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine("Для получения результата [1,3,12,0,0], введите: 0,1,0,3,12");
        Console.WriteLine("-----------------------------------------------------------");
    }

    static bool IsValidInput(string input)
    {
        // Проверка на наличие запятых и отсутствие пробелов
        return input.All(c => c == ',' || char.IsDigit(c));
    }

    static void MoveZerosToEnd(int[] nums)
    {
        int nonZeroIndex = 0;

        // Перемещаем все ненулевые элементы в начало массива
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[nonZeroIndex++] = nums[i];
            }
        }

        // Заполняем оставшиеся позиции нулями
        for (int i = nonZeroIndex; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }
}