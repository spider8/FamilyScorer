using FamilyScorer.Interfaces;

namespace FamilyScorer.Model
{
    public class FamilyMember() : IFamilyMember
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateOnly BirthDay { get; set; }
        public FamilyRole Role { get; set; } = FamilyRole.Dependent;
        public int Income { get; set; }

        public FamilyMember(string Id, string Name, DateOnly BirthDay, FamilyRole Role, int Income = 0) : this()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new ArgumentException("The id param should be valid");
            }

            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("The name param must not be empty");
            }

            this.Id = Id;
            this.Name = Name;
            this.BirthDay = BirthDay;
            this.Role = Role;
            this.Income = Income;

        }
    }
}