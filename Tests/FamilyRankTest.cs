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
            Family Family1 = new(SuitorName: "Pedro", Income: 800);
            Family Family2 = new(SuitorName: "Lucas", Income: 1200);
            Family Family3 = new(SuitorName: "Marcos", Income: 900);

            FamilyRank FamilyRank = new();

            List<string> ExpectedNamesOfElegibles = ["Pedro", "Marcos", "Lucas"];

            var ListOfFamiliesElegiblesToReceiveTheBenefit 
                = FamilyRank.RankFamilies(
                    Families: [Family1, Family2, Family3],
                    RankingCriterias: [new FamiliesWithIncomeUpTo900()]);

            List<string> NamesOfElegibles = ListOfFamiliesElegiblesToReceiveTheBenefit.Select(family => family.GetSuitor().Name).ToList(); ;

            NamesOfElegibles.Should().Equal(ExpectedNamesOfElegibles);
        }

        [Fact]
        public void MustGenerateAnOrderedListOfPeopleEligibleToReceiveAHouseGivenTheirFamilyIncomeFrom901To1500()
        {
            Family Family1 = new(SuitorName: "Maiza", Income: 1000);
            Family Family2 = new(SuitorName: "Lucas", Income: 120);
            Family Family3 = new(SuitorName: "Tatiane", Income: 900);
            Family Family4 = new(SuitorName: "José", Income: 1600);
            Family Family5 = new(SuitorName: "Maria", Income: 1200);

            FamilyRank FamilyRank = new();

            List<string> ExpectedNamesOfElegibles = ["Maiza", "Maria", "Lucas", "Tatiane", "José"];

            var ListOfFamiliesElegiblesToReceiveTheBenefit
                = FamilyRank.RankFamilies(
                    Families: [Family1, Family2, Family3, Family4, Family5],
                    RankingCriterias: [new FamiliesWithIncomeFrom901To1500()]);

            List<string> NamesOfElegibles = ListOfFamiliesElegiblesToReceiveTheBenefit.Select(family => family.GetSuitor().Name).ToList(); ;

            NamesOfElegibles.Should().Equal(ExpectedNamesOfElegibles);
        }

        [Fact]
        public void MustGenerateAnOrderedListOfPeopleEligibleToReceiveAHouseGivenTheirFamilyWith1Or2Dependents()
        {
            Family Family1 = new(SuitorName: "Maiza", NumberOfMinorsDependents:4);
            Family Family2 = new(SuitorName: "Lucas", NumberOfMinorsDependents: 1);
            Family Family3 = new(SuitorName: "Tatiane", NumberOfMinorsDependents:2);
            Family Family4 = new(SuitorName: "José", NumberOfMinorsDependents:3);
            Family Family5 = new(SuitorName: "Maria", NumberOfMinorsDependents:2);

            FamilyRank FamilyRank = new();

            List<string> ExpectedNamesOfElegibles = ["Lucas", "Tatiane", "Maria", "Maiza", "José"];

            var ListOfFamiliesElegiblesToReceiveTheBenefit
                = FamilyRank.RankFamilies(
                    Families: [Family1, Family2, Family3, Family4, Family5],
                    RankingCriterias: [new FamiliesWith1Or2Dependents()]);

            List<string> NamesOfElegibles = ListOfFamiliesElegiblesToReceiveTheBenefit.Select(family => family.GetSuitor().Name).ToList(); ;

            NamesOfElegibles.Should().Equal(ExpectedNamesOfElegibles);
        }

        [Fact]
        public void MustGenerateAnOrderedListOfPeopleEligibleToReceiveAHouseGivenTheirFamilyWith3OrMoreDependents()
        {
            Family Family1 = new(SuitorName: "Maiza", NumberOfMinorsDependents: 4);
            Family Family2 = new(SuitorName: "Lucas", NumberOfMinorsDependents: 1);
            Family Family3 = new(SuitorName: "Tatiane", NumberOfMinorsDependents: 2);
            Family Family4 = new(SuitorName: "José", NumberOfMinorsDependents: 3);
            Family Family5 = new(SuitorName: "Maria", NumberOfMinorsDependents: 2);

            FamilyRank FamilyRank = new();

            List<string> ExpectedNamesOfElegibles = ["Maiza", "José", "Lucas", "Tatiane", "Maria"];

            var ListOfFamiliesElegiblesToReceiveTheBenefit
                = FamilyRank.RankFamilies(
                    Families: [Family1, Family2, Family3, Family4, Family5],
                    RankingCriterias: [new FamiliesWith3OrMoreDependents()]);

            List<string> NamesOfElegibles = ListOfFamiliesElegiblesToReceiveTheBenefit.Select(family => family.GetSuitor().Name).ToList(); ;

            NamesOfElegibles.Should().Equal(ExpectedNamesOfElegibles);
        }

        [Fact]
        public void MustGenerateAnOrderedListOfPeopleEligibleToReceiveAHouseGivenTheirFamilyWithAllCriterias()
        {
            Family Family1 = new(SuitorName: "Maiza", NumberOfMinorsDependents: 4, Income: 2000);
            Family Family2 = new(SuitorName: "Lucas", NumberOfMinorsDependents: 1, Income:800);
            Family Family3 = new(SuitorName: "Tatiane", NumberOfMinorsDependents: 2, Income:1200);
            Family Family4 = new(SuitorName: "José", NumberOfMinorsDependents: 3, Income: 400);
            Family Family5 = new(SuitorName: "Maria", NumberOfMinorsDependents: 2, Income: 760);

            FamilyRank FamilyRank = new();

            /*
            José =>     5 + 3
            Lucas =>    5 + 2
            Maria =>    5 + 2
            Tatiane =>  3 + 2
            Maiza =>    0 + 3
             */
            List<string> ExpectedNamesOfElegibles = ["José", "Lucas", "Maria", "Tatiane", "Maiza"];

            var ListOfFamiliesElegiblesToReceiveTheBenefit
                = FamilyRank.RankFamilies(
                    Families: [Family1, Family2, Family3, Family4, Family5],
                    RankingCriterias: [new FamiliesWith3OrMoreDependents(), new FamiliesWith1Or2Dependents(), new FamiliesWithIncomeUpTo900(), new FamiliesWithIncomeFrom901To1500()]);

            Console.WriteLine(ListOfFamiliesElegiblesToReceiveTheBenefit);

            List<string> NamesOfElegibles = ListOfFamiliesElegiblesToReceiveTheBenefit.Select(family => family.GetSuitor().Name).ToList(); ;

            NamesOfElegibles.Should().Equal(ExpectedNamesOfElegibles);
        }
    }
}