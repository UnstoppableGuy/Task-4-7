
using System;
using System.Globalization;

namespace Task_3_5_6_8
{
    enum TrackBrend
    {
        MAZ,
        BelAZ,
        ERF,
        Dongfeng,
        Volvo
    }
    class Tracks : Auto, IPeaceInfo, IComparable<Tracks>, IFormattable
    {
        public delegate void MethodContainer();

        public event MethodContainer CanGoAbroad; 

        private int maxLoad;
        private int cost;
        private string carNumber;
        public TrackBrend Brend { get; set; }
        public int MaxLoad
        {
            get { return maxLoad; }
            set
            {
                if (value < 0)
                    maxLoad = 0;
                else if (value > 2 * Weight)
                    maxLoad = 2 * Weight;
                else
                    maxLoad = value;
            }
        }
        public int Cost
        {
            get { return cost; }
            set
            {
                if (value < 300000)
                    cost = 300000;
                else
                    cost = value;
            }
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
        public Tracks(int maxspeed,
                      int weight,
                      Color color,
                      DateTime dateTime,
                      TrackBrend brend,
                      int maxload,
                      int value,
                      string carnumber) : base(maxspeed, weight, color, dateTime)
        {
            CarNumber = carnumber;
            Cost = value;
            Brend = brend;
            MaxLoad = maxload;
        }

        public void PeaceInfo()
        {
            base.ShowPeaceInfo();
            Console.WriteLine($"" +
                $"Maximum load: {MaxLoad}\n" +
                $"Brend: {Brend}");
            if (CarNumber == "NaN")
                CanGoAbroad?.Invoke();
        }

        public int CompareTo(Tracks track) => Cost.CompareTo(track.Cost);

        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
                format = "R";
            if (provider == null)
                provider = CultureInfo.CurrentCulture;
            switch (format.ToUpperInvariant())
            {
                case "R":
                    return (Cost * 73).ToString(provider) + " Rubles";
                case "D":
                    return Cost.ToString(provider) + " $";
                case "E":
                    return (Cost * 0.9).ToString(provider) + " Euro";
                default:
                    throw new FormatException(string.Format("Unknown format.", format));
            }
        }
    }
}
