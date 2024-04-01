using FamilyScorer.Interfaces;

namespace FamilyScorer.Strategies
{
    public class FamiliesWith3OrMoreDependents : IRankingCriteria
    {
        readonly int points = 3;

        public int Rank(IFamily Family)
        {
            int familyDepedents = Family.GetMinorsDependents().Count;

            if (familyDepedents > 2)
            {
                return points;
            }

            return 0;
        }
    }

}
