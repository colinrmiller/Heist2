using System;

namespace Heist2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public string Specialty { get { return "Hacker"; } }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            Console.WriteLine($"{Name} is Disabeling the Alarms\n AlarmScore Decreased by {SkillLevel}");

            bank.IncrementSecurityScore("Alarm Score", -SkillLevel);

            if (bank.GetSecurityScore("Alarm Score") <= 0) Console.WriteLine($"{Name} has Successfully Disabled the Security!");

        }
    }
}