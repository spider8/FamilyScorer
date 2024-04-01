using FamilyScorer.Interfaces;

namespace FamilyScorer.Strategies
{
    public class FamiliesWith1Or2Dependents : IRankingCriteria
    {
        readonly int points = 2;

        public int Rank(IFamily Family)
        {
            int familyDepedents = Family.GetMinorsDependents().Count;

            if (familyDepedents > 0 && familyDepedents <= 2)
            {
                return points;
            }

            return 0;
        }
    }

}
