using FamilyScorer.Interfaces;

namespace FamilyScorer.Model
{
    public class Family : IFamily
    {
        public List<IFamilyMember> FamilyMembers { get; set; } = [];
        int counterId = 0;
        public int Adulthood = 18;

        public Family(List<IFamilyMember> FamilyMembers)
        {
            if (FamilyMembers.Count < 2)
            {
                throw new ArgumentException("Families must have at least 2 members");
            }

            bool haveOneSuitor = FamilyMembers.Count(person => person.Role == FamilyRole.Suitor) == 1;

            if (!haveOneSuitor)
            {
                throw new ArgumentException("Families must have a suitor");
            }

            bool haveOneSpouse = FamilyMembers.Count(person => person.Role == FamilyRole.Spouse) == 1;

            if (!haveOneSpouse)
            {
                throw new ArgumentException("Families must have a spouse");
            }

            bool hasDistinctIds = FamilyMembers.Select(person => person.Id).Distinct().Count() == FamilyMembers.Count;

            if (!hasDistinctIds)
            {
                throw new ArgumentException("Members of the family must have distincts Ids");
            }

            this.FamilyMembers = FamilyMembers;
        }
        string GenerateANewId() 
        { 
            return counterId++.ToString();
        }

        public Family(string SuitorName, int NumberOfDependents = 0, int Income = 0, int NumberOfMinorsDependents = 0)
        {
            // Create a suitor
            FamilyMembers.Add(new FamilyMember() { Name = SuitorName, Id = GenerateANewId(), Income = Income, Role = FamilyRole.Suitor, });

            // Create a Spouse
            FamilyMembers.Add(new FamilyMember() { Id = GenerateANewId(), Role = FamilyRole.Spouse });


            for (int index = 0; index < NumberOfDependents; index++)
            {
                FamilyMembers.Add(new FamilyMember() { Id = GenerateANewId(), Role = FamilyRole.Dependent });
            }

            for (int index = 0; index < NumberOfMinorsDependents; index++)
            {
                FamilyMembers.Add(new FamilyMember() { Id = GenerateANewId(), Role = FamilyRole.Dependent, BirthDay = new DateOnly(2020, 10, 11)});
            }

        }

        public int CalculateIncome()
        {
            return FamilyMembers.Sum(person => person.Income);
        }

        public List<IFamilyMember> GetMinorsDependents()
        {
            var CurrentYear = DateTime.Today.Year;

            return FamilyMembers.Where(Member => (CurrentYear - Member.BirthDay.Year) <= Adulthood).ToList();
        }

        public IFamilyMember GetSuitor()
        {
            return FamilyMembers.Where(family => family.Role == FamilyRole.Suitor).ToList().First();
        }
    }
}
