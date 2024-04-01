namespace FamilyScorer.Interfaces
{
    public interface IFamilyRank
    {
        List<IFamily> RankFamilies(List<IFamily> Families, List<IRankingCriteria> RankingCriterias);
    }
}