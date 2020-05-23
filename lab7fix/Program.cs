using System;

namespace Lab7
{
    class Program
    {
        public static int Input()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.Write("Вы ввели неверное значение, попробуйте заново");
            }
        }

        public static void NewFormats(FractionalNumber number1, FractionalNumber number2)
        {
            Console.WriteLine($"Ваши числа {number1:1} {number2:1}");
            Console.WriteLine($"Ваши числа {number1:2} {number2:2}");
            Console.WriteLine($"Ваши числа\n{number1:3}\n----------\n{number2:3}");
        }

        public static void Comparison(FractionalNumber number1, FractionalNumber number2)
        {
            if (((IEquatable<FractionalNumber>)number1).Equals(number2))
                Console.WriteLine("Равны");
            else if (number1 > number2)
                Console.WriteLine($"{number1} > {number2}");
            else
                Console.WriteLine($"{number1} < {number2}");
        }

        public static void Sort(FractionalNumber group1, FractionalNumber group2)
        {
            Console.WriteLine("Отсортированные числа:");

            Array.Sort(new FractionalNumber[] { group1, group2 });

            foreach (var number in new FractionalNumber[] { group1, group2 })
            {
                Console.WriteLine(number);
            }
        }

        public static void NumberInfo(FractionalNumber number)
        {
            Console.WriteLine($"Число в виде дроби: {number}");
            Console.WriteLine($"Число с плавающей точкой: {(double)number}");
            Console.WriteLine($"Число в целом виде: {(int)number}");
        }

        public static void DoubleInput(out FractionalNumber group1, out FractionalNumber group2)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите  целый чистлитель и натуральный знаменеметель:");

                    group1 = new FractionalNumber(Input(), Input());

                    Console.WriteLine("Введите  целый чистлитель и натуральный знаменеметель:");

                    group2 = new FractionalNumber(Input(), Input());

                    return;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            
            FractionalNumber number1 = null;
            FractionalNumber number2 = null;
            DoubleInput(out number1, out number2);
            NewFormats(number1, number2);
            while (true)
            {
                Console.WriteLine("1 +\n2 -\n3 *\n4 /\n5 - выход");
                switch (Input())
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"{number1} + {number2}  = {number1 + number2}");
                        Comparison(number1, number2);
                        Sort(number1, number2);
                        NumberInfo(number1);
                        NumberInfo(number2);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"{number1} - {number2}  = {number1 - number2}");
                        Comparison(number1, number2);
                        Sort(number1, number2);
                        NumberInfo(number1);
                        NumberInfo(number2);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"{number1} * {number2}  = {number1 * number2}");
                        Comparison(number1, number2);
                        Sort(number1, number2);
                        NumberInfo(number1);
                        NumberInfo(number2);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"{number1} / {number2}  = {number1 / number2}");
                        Comparison(number1, number2);
                        Sort(number1, number2);
                        NumberInfo(number1);
                        NumberInfo(number2);
                        break;
                    case 5:
                        return;
                }
            }
        }
    }
}
