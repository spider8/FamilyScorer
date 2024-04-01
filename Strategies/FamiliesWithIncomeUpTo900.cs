using FamilyScorer.Interfaces;

namespace FamilyScorer.Strategies
{
    public class FamiliesWithIncomeUpTo900 : IRankingCriteria
    {
        int points = 5;

        public int Rank(IFamily Family)
        {
            int familyIncome = Family.CalculateIncome();

            if (familyIncome <= 900)
            {
                return points;
            }

            return 0;
        }
    }

}
