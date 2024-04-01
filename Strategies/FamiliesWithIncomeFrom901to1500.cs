using FamilyScorer.Interfaces;

namespace FamilyScorer.Strategies
{
    public class FamiliesWithIncomeFrom901To1500 : IRankingCriteria
    {
        readonly int points = 3;

        public int Rank(IFamily Family)
        {
            int familyIncome = Family.CalculateIncome();

            if (familyIncome > 900 && familyIncome <= 1500)
            {
                return points;
            }

            return 0;
        }
    }

}
