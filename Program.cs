using System;
using System.Collections.Generic;


namespace Task_3_5_6_8
{
    class Program
    {
        /// <summary>
        /// Input integer number higher then zero
        /// </summary>
        /// <returns></returns>
        public static int Input()
        {
            string number = Console.ReadLine();
            if (!int.TryParse(number, out int x))
            {
                Console.WriteLine("Error, Try again");
                return Input();
            }
            else
            {
                if (x < 0)
                {
                    Console.WriteLine("Error, Try again");
                    return Input();
                }
                else return x;
            }
        }
        /// <summary>
        /// Input correct color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color Input(out Color color)
        {
            while (true)
            {
                if (Color.TryParse(Console.ReadLine(), true, out color))
                    return color;
                Console.WriteLine("Enter correct brend:");
                Console.WriteLine($"Variants : Black, Red, White, Grey, Green");
            }
        }
        /// <summary>
        /// Input correct Brend for Sport Cars
        /// </summary>
        /// <param name="carbrend"></param>
        /// <returns></returns>
        public static CarBrend Input(out CarBrend carbrend)
        {
            while (true)
            {
                if (CarBrend.TryParse(Console.ReadLine(), true, out carbrend))
                    return carbrend;
                Console.WriteLine("Enter correct brend:");
                Console.WriteLine($"Variants : Audi, BMW, Bugatti, Koenigsegg, Tesla, Lamborghini");
            }
        }
        /// <summary>
        /// Input correct Brend for Tracks
        /// </summary>
        /// <param name="brend"></param>
        /// <returns></returns>
        public static TrackBrend Input(out TrackBrend brend)
        {
            while (true)
            {
                if (TrackBrend.TryParse(Console.ReadLine(), true, out brend))
                    return brend;
                Console.WriteLine("Enter correct brend:");
                Console.WriteLine($"Variants : MAZ, BelAZ, ERF, Dongfeng, Volvo");
            }
        }
        /// <summary>
        /// Input year of issue
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Input(out DateTime date)
        {
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    return date;
                Console.WriteLine("Enter correct date:");
            }
        }
        /// <summary>
        /// Resolution for something
        /// </summary>
        /// <param name="resolution"></param>
        /// <returns></returns>
        public static bool Input(out bool resolution)
        {
            while (true)
            {
                string temp = Console.ReadLine();
                if (temp.ToLower() == "yes")
                {
                    resolution = true;
                    return resolution;
                }
                else if (temp.ToLower() == "no")
                {
                    resolution = false;
                    return resolution;
                }
                else
                {
                    Console.WriteLine("You need to Enter Yes or No");
                }
            }
        }
        public static void ShowAll(List<SportCar> cars)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            SportCar.StealingCar += () => Console.WriteLine("Warning! This car can be stolen");
            Console.WriteLine("Cost machine format?(R - Rubles, D - Dollars, E - Euro)");
            for (int i = 0; i < cars.Count; i++)
            {
                
                string format = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\t\t{i + 1} strcuture");
                Console.ForegroundColor = ConsoleColor.Yellow;
                cars[i].PeaceInfo();
                Console.WriteLine($"Cost : {cars[i].Cost.ToString(format)}");
                Console.WriteLine("-----------------------");
            }
        }
        public static void EditInfo(List<SportCar> cars, int index)
        {
            bool resolution = true;
            while (resolution)
            {
                Console.WriteLine("You can edit\n" +
                    "1: Max speed\n" +
                    "2: Engine Power\n" +
                    "3: Color\n" +
                    "4: Weight\n");
                int point = Input();
                switch (point)
                {
                    case 1:
                        Console.WriteLine("Input new max speed: ");
                        cars[index].MaxSpeed = Input(); 
                        break;
                    case 2:
                        Console.WriteLine("Input new engine power: ");
                        cars[index].EnginePower = Input(); 
                        break;
                    case 3:
                        Console.WriteLine("Input new color: ");
                        cars[index].Color = Input(out Color _); 
                        break;
                    case 4:
                        Console.WriteLine("Input new weight: ");
                        cars[index].Weight = Input(); 
                        break;
                    default: Console.WriteLine("Bad input"); 
                        break;
                }
                Console.WriteLine("Would you like to coutinue?");
                resolution = Input(out bool _);
            }
        }
        public static void ShowAll(List<Tracks> cars)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Tracks.CanGoAbroad += () => Console.WriteLine("Warning! This car can't go abroad");
            Console.WriteLine("Cost machine format?(R - Rubles, D - Dollars, E - Euro)");
            for (int i = 0; i < cars.Count; i++)
            {
                
                string format = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\t\t{i + 1} strcuture");
                Console.ForegroundColor = ConsoleColor.Yellow;
                cars[i].PeaceInfo();
                Console.WriteLine($"Cost : {cars[i].Cost.ToString(format)}");
                Console.WriteLine("-----------------------");
            }
        }
        public static void EditInfo(List<Tracks> cars, int index)
        {
            bool resolution = true;
            while (resolution)
            {
                Console.WriteLine("You can edit\n" +
                    "1: Max speed\n" +
                    "2: Max load\n" +
                    "3: Color\n" +
                    "4: Weight\n");
                int point = Input();
                switch (point)
                {
                    case 1:
                        Console.WriteLine("Input new max speed: ");
                        cars[index].MaxSpeed = Input();
                        break;
                    case 2:
                        Console.WriteLine("Input new max load: ");
                        cars[index].MaxLoad = Input();
                        break;
                    case 3:
                        Console.WriteLine("Input new color: ");
                        cars[index].Color = Input(out Color _);
                        break;
                    case 4:
                        Console.WriteLine("Input new weight: ");
                        cars[index].Weight = Input();
                        break;
                    default:
                        Console.WriteLine("Bad input");
                        break;
                }
                Console.WriteLine("Would you like to coutinue?");
                resolution = Input(out bool _);
            }
        }
        static int MainSportCar()
        {
            Console.Clear();
            Console.WriteLine("How many sport cars do you want to enter");
            int length = Input();
            List<SportCar> sportcars = new List<SportCar>(1);
            for (int i = 0; i < length; i++)
            {
                sportcars.Add(NewCar());
            }
            bool resolution = true;
            while (resolution)
            {
                Console.WriteLine($"1: Add\n" +
                    $"2: Delete\n" +
                    $"3: Change\n" +
                    $"4: Show All\n");
                int point = Input();
                switch (point)
                {
                    case 1:
                        Console.Clear();
                        sportcars.Add(NewCar());
                        break;
                    case 2:
                        int index = 0;
                        while (index < 1 || index > sportcars.Count + 1)
                        {
                            Console.WriteLine("Choose a structure");
                            index = Input();
                        }
                        sportcars.RemoveAt(index);
                        break;
                    case 3:
                        Console.Clear();
                        ShowAll(sportcars);
                        index = 0;
                        while (index < 1 || index > sportcars.Count + 1)
                        {
                            Console.WriteLine("Choose a structure");
                            index = Input();
                        }
                        index--;
                        EditInfo(sportcars,index);
                        break;
                    case 4:
                        Console.Clear();
                        ShowAll(sportcars);
                        break;
                    default: Console.WriteLine("Bad input"); break;
                }
                Console.WriteLine("Would you like to coutinue?");
                resolution = Input(out bool _);
            }
            return 0;
        }
        static int MainTracks()
        {
            Console.Clear();
            Console.WriteLine("How many tracks do you want to enter");
            int length = Input();
            List<Tracks> tracks = new List<Tracks>(1);
            for (int i = 0; i < length; i++)
            {
                tracks.Add(NewTrack());
            }
            bool resolution = true;
            while (resolution)
            {
                Console.WriteLine($"1: Add\n" +
                    $"2: Delete\n" +
                    $"3: Change\n" +
                    $"4: Show All\n");
                int point = Input();
                switch (point)
                {
                    case 1:
                        Console.Clear();
                        tracks.Add(NewTrack());
                        break;
                    case 2:
                        int index = Input();
                        index--;
                        tracks.RemoveAt(index);
                        break;
                    case 3:
                        Console.Clear();
                        ShowAll(tracks);
                        index = 0;
                        while (index < 1 || index > tracks.Count + 1)
                        {
                            Console.WriteLine("Choose a structure");
                            index = Input();
                        }
                        index--;
                        EditInfo(tracks, index);
                        break;
                    case 4:
                        Console.Clear();
                        ShowAll(tracks);
                        break;
                    default: Console.WriteLine("Bad input"); break;
                }
                Console.WriteLine("Would you like to coutinue?");
                resolution = Input(out bool _);
            }
            return 0;
        }
        static int Main(string[] args)
        {
            Console.Title = ("С#");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            int point = 0;
            Console.WriteLine("What class do you want to work with\n" +
                "1: Sport car\n" +
                "2: Tracks\n" +
                "3: Exit");
            while (point < 1 || point > 3)
            {
                point = Input();
            }
            switch (point)
            {
                case 1:
                    MainSportCar();
                    break;
                case 2:
                    MainTracks(); break;
                case 3: return 0;
            }
            return 0;
        }

        private static SportCar NewCar()
        {
            Console.WriteLine("You need to enter : Max Speed, Weight, Color, Year of Issue, Engine Power, " +
                "Car number, Car brend, Cost");
            return new SportCar(
                                Input(),
                                Input(),
                                Input(out Color _),
                                Input(out DateTime _),
                                Input(),
                                Console.ReadLine(),
                                Input(out CarBrend _),
                                Input());
        }
        private static Tracks NewTrack()
        {
            Console.WriteLine("You need to enter : Max Speed, Weight, Color, Year of Issue, Brend, " +
                "Max load, Cost, Car number");
            return new Tracks(
                                Input(),
                                Input(),
                                Input(out Color _),
                                Input(out DateTime _),
                                Input(out TrackBrend _),
                                Input(),
                                Input(),
                                Console.ReadLine());
        }
    }
}
