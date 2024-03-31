namespace FamilyScorer.Interfaces
{
    public interface IFamilyMember
    {
        DateOnly BirthDay { get; set; }
        string Id { get; set; }
        int Income { get; set; }
        bool IsSuitor { get; set; }
        string Name { get; set; }
    }
}