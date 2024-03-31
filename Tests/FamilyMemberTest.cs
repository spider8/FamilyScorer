using FamilyScorer.Interfaces;
using FamilyScorer.Model;
using FluentAssertions;

namespace FamilyScorer.Tests
{
    public class FamilyMemberTest
    {
        [Fact]
        public void ShouldCreateANewMember()
        {
            var Id = "123";
            var Name = "Pedro";
            var BirthDay = new DateOnly(1990, 2, 22);

            FamilyMember familyMember = new(Id, Name, BirthDay, FamilyRole.Suitor);

            familyMember.Id.Should().Be(Id);
            familyMember.Name.Should().Be(Name);
            familyMember.BirthDay.Should().Be(BirthDay);
            familyMember.Role.Should().Be(FamilyRole.Suitor);
        }

        [Fact]
        public void ShouldThrowAExceptiononWhenPassAInvalidId()
        {
            var Name = "Pedro";
            var BirthDay = new DateOnly(1990, 2, 22);

            FamilyMember familyMember;
            Action action = () => { familyMember = new FamilyMember(Id: string.Empty, Name, BirthDay, FamilyRole.Suitor); };

            action.Should().Throw<ArgumentException>().WithMessage("The id param should be valid");
        }

        [Fact]
        public void ShouldThrowAExceptiononWhenPassAEmptyName()
        {
            var Id = "123";
            var BirthDay = new DateOnly(1990, 2, 22);

            FamilyMember familyMember;
            Action action = () => { familyMember = new FamilyMember(Id, Name: string.Empty, BirthDay, FamilyRole.Suitor); };

            action.Should().Throw<ArgumentException>().WithMessage("The name param must not be empty");
        }
    }

}