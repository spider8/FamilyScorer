namespace FamilyScorer.Interfaces
{
    public enum FamilyRole { Suitor, Spouse, Dependent };

    public interface IFamilyMember
    {
        DateOnly BirthDay { get; set; }
        string Id { get; set; }
        int Income { get; set; }
        FamilyRole Role { get; set; }

        string Name { get; set; }
    }
}