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
                new FamilyMember { Id = "2", Name = "Bia", BirthDay = new DateOnly(1990, 9, 9)},
            ];

            Action action = () => { family = new Family(Members); };
            action.Should().Throw<ArgumentException>().WithMessage("Families must have a suitor");
        }

        [Fact]
        public void ShouldHaveDistinctMembersIds()
        {
            Family family;
            List<IFamilyMember> Members =
            [
                new FamilyMember { Id = "1", Name = "Pedro",BirthDay = new DateOnly(1990, 10, 10), IsSuitor = true},
                new FamilyMember { Id = "1", Name = "Bia", BirthDay = new DateOnly(1990, 9, 9) },
            ];

            Action action = () => { family = new Family(Members); };
            action.Should().Throw<ArgumentException>().WithMessage("Members of the family must have distincts Ids");
        }

        [Fact]
        public void ShouldBePossibleCalculateTheFamilyIncome() 
        {

            List<IFamilyMember> Members =
            [
                new FamilyMember { Id = "1", Name = "Pedro", Income = 10, IsSuitor = true},
                new FamilyMember { Id = "2", Name = "Bia", Income = 20},
            ];

            Family Family = new (Members);
            Family.CalculateIncome().Should().Be(30);
        }

        [Fact]
        public void ShouldReturnAListOfDependentFamilyMembers()
        {

            List<IFamilyMember> Members =
            [
                new FamilyMember { Id = "1", Name = "Pedro", BirthDay = new DateOnly(1990, 10, 10)},
                new FamilyMember { Id = "2", Name = "Bia", BirthDay = new DateOnly(1995, 12, 12), IsSuitor = true},

                // This member is a dependent
                new FamilyMember { Id = "3", Name = "Ana", BirthDay = new DateOnly(2020, 8, 8)},

            ];

            Family Family = new(Members);
            Family.GetDependents().Should().Equal(Members.Where(member => member.Name == "Ana"));

        }
    }
}