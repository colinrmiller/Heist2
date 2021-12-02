using System;

namespace Heist2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public string Specialty { get { return "Lock Specialist"; } }

        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            Console.WriteLine($"{Name} is Picking the Locks\nVaultScore Decreased by {SkillLevel}");

            bank.IncrementSecurityScore("Lock Score", -SkillLevel);

            if (bank.GetSecurityScore("Lock Score") <= 0) Console.WriteLine($"{Name} has Successfully Unlocked the Vault!");
        }
    }
}