using System;

namespace Heist2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public string Specialty { get { return "Muscle"; } }

        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            Console.WriteLine($"{Name} is Working the Security\n SecurityGuard Decreased by {SkillLevel}");

            bank.IncrementSecurityScore("Security Score", -SkillLevel);

            if (bank.GetSecurityScore("Security Score") <= 0) Console.WriteLine($"{Name} has Successfully Disabled the Security!");

        }
    }
}