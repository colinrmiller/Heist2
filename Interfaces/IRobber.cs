namespace Heist2
{
    public interface IRobber
    {
        string Specialty { get; }
        string Name { get; set; }
        int SkillLevel { get; set; }
        int PercentageCut { get; set; }
        void PerformSkill(Bank bank);
    }
}