using System;

namespace Task_3_5_6_8
{
    enum Color
    {
        Black,
        Red,
        White,
        Grey,
        Green
    }
    abstract class Auto
    {
        private int maxSpeed;
        private int currentWeight;        
        public DateTime YearOfIssue;
        public Color Color { get; set; }
        public Auto(int maxspeed, int weight, Color color, DateTime yearofissue)
        {
            MaxSpeed = maxspeed;
            Weight = weight;
            Color = color;
            YearOfIssue = yearofissue;
        }
        public int MaxSpeed
        {
            set
            {
                if (value <= 100)
                    maxSpeed = 100;
                else if (value > 600)
                    maxSpeed = 600;
                else
                    maxSpeed = value;
            }
            get
            {
                return maxSpeed;
            }
        }
        public int Weight
        {
            set
            {
                if (value <= 600)
                    currentWeight = 600;
                else
                    currentWeight = value;
            }
            get
            {
                return currentWeight;
            }
        }
        virtual public void ShowPeaceInfo()
        {
            Console.WriteLine($"Max Speed :{MaxSpeed}\n" +
                $"Weight: {Weight}\n" +
                $"Color: {Color}\n" +
                $"Year of issue: {YearOfIssue}");
        }
    }
}