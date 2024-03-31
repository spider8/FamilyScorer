using FamilyScorer.Interfaces;

namespace FamilyScorer.Model
{
    public class Family : IFamily
    {
        public List<IFamilyMember> FamilyMembers { get; set; }
        public int Adulthood = 18;

        public Family(List<IFamilyMember> FamilyMembers)
        {
            if (FamilyMembers.Count < 2)
            {
                throw new ArgumentException("Families must have at least 2 members");
            }

            bool haveOneSuitor = FamilyMembers.Count(person => person.IsSuitor) == 1;

            if (!haveOneSuitor)
            {
                throw new ArgumentException("Families must have a suitor");
            }

            bool hasDistinctIds = FamilyMembers.Select(person => person.Id).Distinct().Count() == FamilyMembers.Count;

            if (!hasDistinctIds)
            {
                throw new ArgumentException("Members of the family must have distincts Ids");
            }

            this.FamilyMembers = FamilyMembers;
        }

        public int CalculateIncome()
        {
            return FamilyMembers.Sum(person => person.Income);
        }

        public List<IFamilyMember> GetDependents()
        {
            var CurrentYear = DateTime.Today.Year;

            return FamilyMembers.Where(Member => (CurrentYear - Member.BirthDay.Year) <= Adulthood).ToList();
        }
    }
}
