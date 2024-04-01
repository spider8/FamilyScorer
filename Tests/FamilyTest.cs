using FamilyScorer.Interfaces;
using FamilyScorer.Model;
using FluentAssertions;

namespace FamilyScorer.Tests
{
    public class FamilyTest
    {
        [Fact]
        public void ShouldhrowAExceptionIfNoListOfMembersIsPassedToTheConstructor()
        {
            Family family;
            List<IFamilyMember> Members = [];

            Action action = () => { family = new Family(Members); };
            action.Should().Throw<ArgumentException>().WithMessage("Families must have at least 2 members");
        }

        [Fact]
        public void ShouldThrowAExceptionIfAnyMemberIsASuitor()
        {
            Family family;
            List<IFamilyMember> Members =
            [
                new FamilyMember { Id = "1", Name = "Pedro",BirthDay = new DateOnly(1990, 10, 10)},
                new FamilyMember { Id = "2", Name = "Bia", BirthDay = new DateOnly(1990, 9, 9), Role = FamilyRole.Spouse},
            ];

            Action action = () => { family = new Family(Members); };
            action.Should().Throw<ArgumentException>().WithMessage("Families must have a suitor");
        }

        [Fact]
        public void ShouldThrowAExceptionIfAnyMemberIsASpouse()
        {
            Family family;
            List<IFamilyMember> Members =
            [
                new FamilyMember { Id = "1", Name = "Pedro",BirthDay = new DateOnly(1990, 10, 10), Role = FamilyRole.Suitor},
                new FamilyMember { Id = "2", Name = "Bia", BirthDay = new DateOnly(1990, 9, 9)},
            ];

            Action action = () => { family = new Family(Members); };
            action.Should().Throw<ArgumentException>().WithMessage("Families must have a spouse");
        }

        [Fact]
        public void ShouldHaveDistinctMembersIds()
        {
            Family family;
            List<IFamilyMember> Members =
            [
                new FamilyMember { Id = "1", Name = "Pedro",BirthDay = new DateOnly(1990, 10, 10), Role = FamilyRole.Spouse},
                new FamilyMember { Id = "1", Name = "Bia", BirthDay = new DateOnly(1990, 9, 9), Role = FamilyRole.Suitor },
            ];

            Action action = () => { family = new Family(Members); };
            action.Should().Throw<ArgumentException>().WithMessage("Members of the family must have distincts Ids");
        }

        [Fact]
        public void ShouldBePossibleCalculateTheFamilyIncome() 
        {

            List<IFamilyMember> Members =
            [
                new FamilyMember { Id = "1", Name = "Pedro", Income = 10, Role = FamilyRole.Suitor},
                new FamilyMember { Id = "2", Name = "Bia", Income = 20, Role = FamilyRole.Spouse},
            ];

            Family Family = new (Members);
            Family.CalculateIncome().Should().Be(30);
        }

        [Fact]
        public void ShouldReturnAListOfMinorsDependentFamilyMembers()
        {

            List<IFamilyMember> Members =
            [
                new FamilyMember { Id = "1", Name = "Pedro", BirthDay = new DateOnly(1990, 10, 10), Role = FamilyRole.Spouse},
                new FamilyMember { Id = "2", Name = "Bia", BirthDay = new DateOnly(1995, 12, 12), Role = FamilyRole.Suitor},

                new FamilyMember { Id = "3", Name = "Caio", BirthDay = new DateOnly(2003, 1, 1)},

                // This member is a minor dependent
                new FamilyMember { Id = "4", Name = "Ana", BirthDay = new DateOnly(2020, 8, 8)},

            ];

            Family Family = new(Members);
            Family.GetMinorsDependents().Should().Equal(Members.Where(member => member.Name == "Ana"));
        }

        [Fact]
        public void ShouldCreateACompleteFamilyWithASuitorName()
        {            
            Family Family = new(SuitorName: "Bianca", NumberOfDependents: 3, Income: 1400, NumberOfMinorsDependents:1);

            Family.GetMinorsDependents().Count.Should().Be(1);
            Family.FamilyMembers.Should().HaveCount(6);
            Family.GetSuitor().Name.Should().Be("Bianca");
            Family.CalculateIncome().Should().Be(1400);
        }
    }
}