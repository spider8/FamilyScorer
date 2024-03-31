namespace FamilyScorer.Interfaces
{
    public interface IFamily
    {
        List<IFamilyMember> FamilyMembers { get; set; }

        int CalculateIncome();
        List<IFamilyMember> GetDependents();
    }
}