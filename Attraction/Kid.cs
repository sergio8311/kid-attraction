using System;

namespace Attraction
{
    class Kid
    {
        public int Height { get; set; }
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int LevelOfHappines { get; set; }
        public decimal Money { get; set; }

        public Kid()
        {
            
        }

        public Kid(int height, Gender gender, string name, int levelOfHappines, decimal money)
        {
            Height = height;
            Gender = gender;
            Name = name;
            LevelOfHappines = levelOfHappines;
            Money = money;
        }

        public void Cry()
        {
            Console.WriteLine("Wha-Wha!!!");
            Height = Height + 2;
            LevelOfHappines--;
        }

        public void Ride()
        {
            if (Money - AttractionSettings.GetAttractionsCost() >= 0)
            {
                Money = Money - AttractionSettings.GetAttractionsCost();
                LevelOfHappines++;
            }
                            
            else
            {
                Console.WriteLine($"{Name} don't allowed to attraction, due to low balance {Money}");
            }
        }

    }
}
