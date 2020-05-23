using System;
using System.Globalization;

namespace Lab7
{
    class FractionalNumber : IFormattable, IEquatable<FractionalNumber>, IComparable<FractionalNumber>
    {
        public int Denomitor { get; }
        public int Numerator { get; }
        public FractionalNumber(int numerator, int denomitor)
        {
            int somenumber = Greatest(numerator, denomitor);

            if (denomitor > 0)
                Denomitor = denomitor / somenumber;
            else
                throw new Exception("Знаменатель не может быть равен 0");

            Numerator = numerator / somenumber;
        }
        public static FractionalNumber operator +(FractionalNumber group1, FractionalNumber group2)
            => new FractionalNumber(
                group1.Numerator * group2.Denomitor + group2.Numerator * group1.Denomitor,
                group1.Denomitor * group2.Denomitor);

        public static FractionalNumber operator -(FractionalNumber group1, FractionalNumber group2)
            => new FractionalNumber(
                group1.Numerator * group2.Denomitor - group2.Numerator * group1.Denomitor,
                group1.Denomitor * group2.Denomitor);

        public static FractionalNumber operator *(FractionalNumber group1, FractionalNumber group2)
            => new FractionalNumber(
                group1.Numerator * group2.Numerator,
                group1.Denomitor * group2.Denomitor);

        public static FractionalNumber operator /(FractionalNumber group1, FractionalNumber group2)
            => new FractionalNumber(
                group1.Numerator * group2.Denomitor,
                group1.Denomitor * group2.Numerator);

        public static bool operator >(FractionalNumber group1, FractionalNumber group2)
            => group1.Numerator * group2.Denomitor > group2.Numerator * group1.Denomitor;

        public static bool operator <(FractionalNumber group1, FractionalNumber group2)
            => group1.Numerator * group2.Denomitor < group2.Numerator * group1.Denomitor;

        public int CompareTo(FractionalNumber group)
            => (Numerator * group.Denomitor).CompareTo(group.Numerator * Denomitor);

        public bool Equals(FractionalNumber group)
        {
            if (group == null)
                return false;
            else
                return Numerator * group.Denomitor == group.Numerator * Denomitor;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
                format = "1";
            switch (format.ToUpperInvariant())
            {
                case "1":
                    return $"{Numerator}/{Denomitor}";
                case "2":
                    return $"{(double)Numerator / Denomitor}";
                case "3":
                    return $"{Numerator}\n-\n{Denomitor}";
                default:
                    throw new Exception("Неопознанный формат");
            }
        }

        private static int Greatest(int number1, int number2)
        {
            if (number2 == 0)
                return number1;
            else
                return Greatest(number2, number1 % number2);
        }

        public override string ToString()
        {
            if (Numerator % Denomitor == 0)
                return $"{Numerator / Denomitor}";
            else
                return ((IFormattable)this).ToString("1", CultureInfo.CurrentCulture);
        }

        public string ToString(string format) 
            => ((IFormattable)this).ToString(format, CultureInfo.CurrentCulture);

        public static implicit operator FractionalNumber(int group) => new FractionalNumber(group, 1);

        public static explicit operator int(FractionalNumber group) => group.Numerator / group.Denomitor;

        public static explicit operator double(FractionalNumber group) 
            => (double)group.Numerator / group.Denomitor;
    }
}
