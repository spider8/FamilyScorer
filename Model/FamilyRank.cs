using FamilyScorer.Interfaces;

namespace FamilyScorer.Model
{
    public class FamilyRank : IFamilyRank
    {

        public List<IFamily> RankFamilies(List<IFamily> Families, List<IRankingCriteria> RankingCriterias)
        {
            Dictionary<IFamily, int> FamiliesScores = [];

            foreach (var Familiy in Families)
            {
                int score = 0;
                
                foreach (var RankingCriteria in RankingCriterias)
                {
                    score +=  (RankingCriteria.Rank(Familiy));
                }

                FamiliesScores.Add(Familiy, score);
            }

            List<IFamily> OrderedRankFamilies = (List<IFamily>)(from entry in FamiliesScores orderby entry.Value descending select entry.Key).ToList();
            return OrderedRankFamilies;
        }
    }
}
