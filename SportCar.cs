
using System;
using System.Globalization;

namespace Task_3_5_6_8
{
    public enum CarBrend
    {
        Audi,
        BMW,
        Bugatti,
        Koenigsegg,
        Tesla,
        Lamborghini
    }
    class SportCar : Auto, IPeaceInfo, IComparable<SportCar>, IFormattable
    {
        public delegate void MethodContainer();

        static public event MethodContainer StealingCar;

        private int enginePower;
        private string carNumber;
        private int cost;
        public CarBrend Brend { get; set; }
        public SportCar(int maxspeed,
                        int weight,
                        Color color,
                        DateTime yearofissue,
                        int enginepower,
                        string carnumber,
                        CarBrend brend,
                        int value) : base(maxspeed, weight, color, yearofissue)
        {
            Brend = brend;
            CarNumber = carnumber;
            EnginePower = enginepower;
            Cost = value;
        }
        public int Cost
        {

            set
            {
                if (value < 250000)
                    cost = 0;
                else
                    cost = value;
            }
            get { return cost; }
        }
        public string CarNumber
        {
            set
            {
                if (value.Length > 10)
                    carNumber = "NaN";
                else
                    carNumber = value;
            }
            get
            {
                return carNumber;
            }
        }
        public int EnginePower
        {
            set
            {
                if (value < 0 || value > 2000)
                    enginePower = 0;
                else
                    enginePower = value;
            }
            get { return enginePower; }
        }
        public void PeaceInfo()
        {
            base.ShowPeaceInfo();
            Console.WriteLine($"Brend: {Brend}\n" +
                $"Car number: {CarNumber}\n" +
                $"Engine Power: {EnginePower}");
            if (CarNumber == "NaN" || Cost == 0)
                StealingCar?.Invoke();
        }
        public int CompareTo(SportCar car) => Cost.CompareTo(car.Cost);

        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
                format = "D";
            if (provider == null)
                provider = CultureInfo.CurrentCulture;
            switch (format.ToUpperInvariant())
            {
                case "D":
                    return Cost.ToString(provider) + " Dollars";
                case "R":
                    return (Cost * 73).ToString(provider) + " Rubles";
                case "E":
                    return (Cost * 0.9).ToString(provider) + " Euro";
                default:
                    throw new FormatException(string.Format("Unknown format.", format));
            }
        }
    }
}

