using System;
using System.Reflection.Metadata.Ecma335;

namespace Attraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Kid kid = new Kid()
            {
                Gender = Gender.Male,
                Height = 145,
                LevelOfHappines = 100,
                Money = 99,
                Name = "John"
            };

            AttractionManager manager = new AttractionManager(0);

            Park(manager, kid);

            ShowKidAfterAttractionClosing(kid);

            //Kid kid = new Kid();
            //int height;
            //Gender gender;
            //WeekDay weekDay;
            //Attractions attraction;

            //Console.WriteLine("Enter kid height in cm: ");
            //while (!int.TryParse(Console.ReadLine(), out height))
            //{
            //    Console.WriteLine("Height is not a number");
            //}

            //kid.Height = height;

            //Console.WriteLine("Choose Week Day (Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday): ");
            //while (!Enum.TryParse(Console.ReadLine(), out weekDay))
            //{
            //    Console.WriteLine("Enter Week Day in right format: Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday");
            //}          

            //Console.WriteLine("Choose kid gender (Male, Female): ");
            //while (!Enum.TryParse(Console.ReadLine(), out gender))
            //{
            //    Console.WriteLine("Uknown gender. Please choose one of: Male, Female");
            //}          

            //kid.Gender = gender;

            //Console.WriteLine("Enter Kid Name: ");
            //kid.Name = Console.ReadLine();

            //Console.WriteLine("Which Attraction kid want to visit (Batman, Swan, Pony): ");
            //while (!Enum.TryParse(Console.ReadLine(), out attraction))
            //{
            //    Console.WriteLine("Uknown Attraction name. Please choose one of: Batman, Swan, Pony.");
            //}

            //KidAllowedToAttractions(weekDay, kid, attraction);

            Console.ReadKey();
        }

        static bool IsAttractionOpened(WeekDay weekDay, Attractions attraction)
        {
            switch (attraction)
            {
                case Attractions.Batman:
                    if (WeekDay.Monday == weekDay || WeekDay.Wednesday == weekDay || WeekDay.Friday == weekDay)
                        return true;
                    break;

                case Attractions.Swan:
                    if (weekDay == WeekDay.Tuesday || weekDay == WeekDay.Wednesday || weekDay == WeekDay.Thursday)
                        return true;
                    break;

                case Attractions.Pony:
                    if (weekDay != WeekDay.Sunday)
                        return true;
                    break;

                default:
                        return false;
            }

            return false;
        }

        static bool IsKidAllowed(Attractions attraction, Kid kid)
        {
            if (attraction == Attractions.Batman & kid.Height > AttractionSettings.GetMinimumHeightForBatman() & kid.Gender == Gender.Male)
                return true;
            if (attraction == Attractions.Swan & kid.Gender == Gender.Female & (kid.Height > AttractionSettings.GetMinimumHeightForSwan() & kid.Height < AttractionSettings.GetMaximumHeightForSwan()))
                return true;
            if (attraction == Attractions.Swan & kid.Gender == Gender.Male & kid.Height < AttractionSettings.GetMaximumHeightForSwan())
                return true;
            if (attraction == Attractions.Pony)
                return true;
            return false;
        }

        static void KidAllowedToAttractions(WeekDay weekDay, Kid kid, Attractions attractions)
        {
            if (IsAttractionOpened(weekDay, attractions) & IsKidAllowed(attractions, kid))
            {
                Console.WriteLine($"Kid Name: {kid.Name}");
                Console.WriteLine($"Attraction Name: {attractions}");
            }
                
            else
                Console.WriteLine($"{kid.Name} is not allowed to {attractions} attraction");
        }

        static void Park(AttractionManager manager, Kid kid)
        {

            while (manager.CheckCash())
            {
                bool isAllowed;
                Console.WriteLine($"Is {kid.Name} allowed to ride (true, false)");
                while (!bool.TryParse(Console.ReadLine(), out isAllowed))
                    Console.WriteLine("Uknown format, pleas enter: true or false");

                manager.IsKidAllowedToRide(isAllowed, kid);
            }
        }

        static void ShowKidAfterAttractionClosing(Kid kid)
        {
            Console.WriteLine($"{kid.Name}  {kid.LevelOfHappines} {kid.Money}");
        }

    }
}
