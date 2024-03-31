namespace FamilyScorer.Interfaces
{
    public interface IFamilyRank
    {
        List<IFamilyMember> RankFamilies(List<IFamily> Families, List<IRankingCriteria> RankingCriterias);
    }
}