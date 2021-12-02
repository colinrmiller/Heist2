using System.Collections.Generic;

namespace Heist2
{
    class Program
    {
        static void Main()
        {

            List<IRobber> rolodex = new List<IRobber>
            {
                new Hacker(){
                    Name = "Mr Robot",
                    SkillLevel = 90,
                    PercentageCut = 30
                },
                new Muscle(){
                    Name = "Olive",
                    SkillLevel = 3,
                    PercentageCut = 25
                },
                new LockSpecialist(){
                    Name = "Buster",
                    SkillLevel = 75,
                    PercentageCut = 10
                },
                new Hacker(){
                    Name = "Mr Pink",
                    SkillLevel = 75,
                    PercentageCut = 10
                },
                new Muscle(){
                    Name = "Mr Bojangles",
                    SkillLevel = 99,
                    PercentageCut = 2
                },
            };

            while (true)
            {
                Console.WriteLine($"Number of Operatives in the rolodex: {rolodex.Count}");

                Console.Write($"Enter the Name of a New Crew Member: ");
                string newName = Console.ReadLine();
                if (newName == "")
                {
                    break;
                }

                Console.WriteLine(@$"1) Hacker (Disables alarms)
2) Muscle (Disarms guards)
3) Lock Specialist (cracks vault)");
                Console.WriteLine($"Choose Your Operative's Class: ");
                int newClassChoice = int.Parse(Console.ReadLine());

                Console.Write($"Enter your Operatives Skill Level (0-100): ");
                int newSkillLevel = int.Parse(Console.ReadLine());

                Console.Write($"Enter your Operatives Percentage Cut (0-100): ");
                int newPercentageCut = int.Parse(Console.ReadLine());


                rolodex = AddOperative(newClassChoice, newName, newSkillLevel, newPercentageCut, rolodex);

            }
            Bank bank = new Bank();

            Console.WriteLine($"Bank:");
            Console.WriteLine($"\tMost Secure System: {bank.MostSecureSystem}");
            Console.WriteLine($"\tLeast Secure System: {bank.LeastSecureSystem}");

            Crew crew = new Crew();
            crew.AddCrewMembers(rolodex);

            crew.PerformBankHeist(bank);
        }
        public static void DisplayRolodex(List<IRobber> rolodex)
        {
            for (int i = 0; i < rolodex.Count; i++)
            {
                var robber = rolodex[i];
                Console.WriteLine($"{(i + 1)}> {robber.Name}");
                Console.WriteLine($"\t Specialty:   {robber.Specialty}");
                Console.WriteLine($"\t Skill Level: {robber.SkillLevel}");
                Console.WriteLine($"\t % Cut Level: {robber.PercentageCut}");
            }
        }

        public static List<IRobber> AddOperative(int choice, string name, int skillLevel, int percentageCut, List<IRobber> rolodex)
        {
            IRobber newOperative;
            if (choice == 1)
            {
                newOperative = new Hacker()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                };
                rolodex.Add(newOperative);
            }
            else if (choice == 2)
            {
                newOperative = new Hacker()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                };
                rolodex.Add(newOperative);
            }
            else if (choice == 2)
            {
                newOperative = new Hacker()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                };
                rolodex.Add(newOperative);
            }
            return rolodex;
        }
    }


}