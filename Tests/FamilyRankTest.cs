using FamilyScorer.Interfaces;
using FamilyScorer.Model;
using FamilyScorer.Strategies;
using FluentAssertions;

namespace FamilyScorer.Tests
{
    public class FamilyRankTest
    {
        [Fact]
        public void MustGenerateAnOrderedListOfPeopleEligibleToReceiveAHouseGivenTheirFamilyIncomeOfUpTo900()
        {
            List<IFamilyMember> Members1 =
            [
                new FamilyMember { Id = "1", Name = "Pedro", Income = 400, Role = FamilyRole.Suitor},
                new FamilyMember { Id = "2", Name = "Bia", Income = 400, Role = FamilyRole.Spouse},
            ];

            Family Family1 = new(Members1);

            List<IFamilyMember> Members2 =
            [
                new FamilyMember { Id = "1", Name = "Lucas", Income = 1000, Role = FamilyRole.Suitor},
                new FamilyMember { Id = "2", Name = "Fernanda", Income = 200, Role = FamilyRole.Spouse},
            ];

            Family Family2 = new(Members2);

            List<IFamilyMember> Members3 =
           [
               new FamilyMember { Id = "1", Name = "Marcos", Income = 400, Role = FamilyRole.Suitor},
               new FamilyMember { Id = "2", Name = "Luiza", Income = 500, Role = FamilyRole.Spouse},
            ];

            Family Family3 = new(Members3);

            FamilyRank FamilyRank = new();

            List<string> ExpectedNamesOfElegibles = ["Pedro", "Marcos","Lucas"];
            
            var ListOfFamiliesElegiblesToReceiveTheBenefit = FamilyRank.RankFamilies([Family1, Family2, Family3], [new FamiliesWithIncomeUpTo900()]);

            List<string> NamesOfElegibles = ListOfFamiliesElegiblesToReceiveTheBenefit.Select(family => family.GetSuitor().Name).ToList(); ;

            Console.WriteLine(ExpectedNamesOfElegibles);
            NamesOfElegibles.Should().Equal(ExpectedNamesOfElegibles);

        }
    }
}