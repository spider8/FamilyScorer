using FamilyScorer.Interfaces;

namespace FamilyScorer.Model
{
    public class FamilyRank : IFamilyRank
    {
        public FamilyRank() {
            throw new ArgumentException("A list of families and ranking criteria are required");
        }

        public List<IFamilyMember> RankFamilies(List<IFamily> Families, List<IRankingCriteria> RankingCriterias)
        {
            throw new NotImplementedException();
        }
    }
}
