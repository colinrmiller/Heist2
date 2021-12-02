using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist2
{
    public class Crew
    {
        private List<IRobber> _crewList = new List<IRobber>();
        private int _takePercentageClaimed = 0;

        public void AddCrewMembers(List<IRobber> rolodex)
        {
            // filter out crew members who require more cut than is available
            rolodex = rolodex.Where(crew => crew.PercentageCut <= 100 - _takePercentageClaimed).ToList();

            Program.DisplayRolodex(rolodex);
            Console.Write("Select Operative to Add > ");
            int selection = int.Parse(Console.ReadLine());
            if (selection > 0 && selection <= rolodex.Count)
            {
                _crewList.Add(rolodex[selection - 1]);
                _takePercentageClaimed += rolodex[selection - 1].PercentageCut;

                rolodex.RemoveAt(selection - 1);

                if (rolodex.Count > 0) AddCrewMembers(rolodex);
            }
        }

        public void PerformBankHeist(Bank bank)
        {
            foreach (var crew in _crewList)
            {
                crew.PerformSkill(bank);
            }

            if (!bank.IsSecure)
            {
                Console.WriteLine($"Successful Heist!");

                int cashHaul = bank.CashAtHand;
                int cashLeft = cashHaul;
                Console.WriteLine($"Cash Take: ");

                foreach (var crew in _crewList)
                {
                    int take = cashHaul * crew.PercentageCut / 100;
                    cashLeft -= take;
                    Console.WriteLine($"{crew.Name}: {take}$");
                    Console.WriteLine($" - {cashLeft}$");
                }
                Console.WriteLine($"You: {cashLeft}");
            }
            else
            {
                Console.WriteLine($"Heist Failed");
            }
        }
    }
}