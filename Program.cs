using System;
using System.Collections.Generic;

namespace TigerSoccerClub
{
    class Player
    {
        public string Name { get; set; }
        public string RegistrationType { get; set; }
        public string JerseyChoice { get; set; }
        public double TotalFee { get; set; }

        public Player(string name, string regType, string jersey, double fee)
        {
            Name = name;
            RegistrationType = regType;
            JerseyChoice = jersey;
            TotalFee = fee;
        }
    }

    class Program
    {
        const int InitialKids = 150;
        const int InitialAdult = 230;
        const int JerseyFee = 100;
        const double DiscountRate = 0.05;

        static double CalculateFee(string registration, string jersey, bool discount)
        {
            // registration and jersey expected in lower case: "kids"/"adult", "yes"/"no"
            double baseFee = (registration == "kids") ? InitialKids : InitialAdult;

            if (jersey == "yes")
                baseFee += JerseyFee;

            if (discount)
                baseFee -= baseFee * DiscountRate;

            return baseFee;
        }

        static void Main(string[] args)
        {
            int i = 0;
            double total = 0;
            string Name = "";
            string Registration = "";
            string Jersey = "";

            List<Player> players = new List<Player>();

            //these lines of codes are for aligning items to center and contains heading portion
            string s = "*****Welcome to TigerSoccerClub*****";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            Console.Write("Enter the number of players per registrations: ");
            int Players = Convert.ToInt32(Console.ReadLine());

            if (Players > 4 || Players < 1)
            {
                Console.WriteLine("Invalid number, Please enter the registration number betweeen 1 to 4");
            }
            else
            {
                bool discount = (Players > 1); // 5% discount for more than one player

                if (Players == 1)
                {
                    Console.Write("Enter name: ");
                    Name = Console.ReadLine();

                    Console.Write("Registration type (Kids/Adult): ");
                    Registration = Console.ReadLine().Trim().ToLower();

                    Console.Write("Enter Yes/No to indicate whether you want jersey: ");
                    Jersey = Console.ReadLine().Trim().ToLower();

                    total = CalculateFee(Registration, Jersey, discount);

                    Console.Write("Total price from " + Name + " is: " + total);
                    Console.WriteLine("\n");

                    players.Add(new Player(Name, Registration, Jersey, total));
                }
                else
                {
                    for (i = 0; i < Players; i++)
                    {
                        Console.Write("Enter name: ");
                        Name = Console.ReadLine();

                        Console.Write("Registration type (Kids/Adult): ");
                        Registration = Console.ReadLine().Trim().ToLower();

                        Console.Write("Enter Yes/No to indicate whether you want jersey: ");
                        Jersey = Console.ReadLine().Trim().ToLower();

                        total = CalculateFee(Registration, Jersey, discount);

                        Console.Write("Total price from " + Name + " is: " + total);
                        Console.WriteLine("\n");

                        players.Add(new Player(Name, Registration, Jersey, total));
                    }
                }

                // summary printed once at the end
                string s2 = "Summary of Registrations";
                Console.SetCursorPosition((Console.WindowWidth - s2.Length) / 2, Console.CursorTop);
                Console.WriteLine(s2);
                Console.WriteLine("******************************************************************************************************");
                Console.WriteLine("Name\tType\tJersey\tTotal");

                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Name}\t{p.RegistrationType}\t{p.JerseyChoice}\t{p.TotalFee}");
                }

                Console.WriteLine();
            }
        }
    }
}
