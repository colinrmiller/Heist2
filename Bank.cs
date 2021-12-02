using System;
using System.Collections.Generic;
namespace Heist2
{
    public class Bank
    {
        public Bank()
        {
            var rand = new Random();
            _securityScores = new List<SecurityScore> {
                new SecurityScore(){
                    Name = "Alarm Score",
                    Value = rand.Next(101)
                },
                new SecurityScore(){
                    Name = "Security Score",
                    Value = rand.Next(101)
                },
                new SecurityScore(){
                    Name = "Lock Score",
                    Value = rand.Next(101)
                }
            };
            CashAtHand = rand.Next(50_000, 1_000_000);
        }

        private List<SecurityScore> _securityScores;

        public int CashAtHand { get; }
        public void IncrementSecurityScore(string securityName, int incrementValue)
        {
            var systemScore = _securityScores.FirstOrDefault(system => system.Name == securityName);
            systemScore.Value = systemScore.Value + incrementValue;
        }
        public int GetSecurityScore(string securityName)
        {
            return _securityScores.FirstOrDefault(system => system.Name == securityName).Value;
        }
        public string MostSecureSystem
        {
            get
            {
                return _securityScores.OrderByDescending(score => score.Value).First().Name;
            }
        }
        public string LeastSecureSystem
        {
            get
            {
                return _securityScores.OrderBy(score => score.Value).First().Name;
            }
        }

        public bool IsSecure
        {
            get
            {
                foreach (var score in _securityScores)
                {
                    if (score.Value > 0) return true;
                }
                return false;
            }
        }
    }
}