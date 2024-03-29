using FamilyScorer.Model;
using FluentAssertions;

namespace FamilyScore.Tests
{
    public class FamilyMemberTest
    {
        [Fact]
        public void ShouldCreateANewMember()
        {
            var Id = "123";
            var Name = "Pedro";
            var BirthDay = new DateOnly(1990, 2, 22);
            var IsHeadOfFamily = true;

            FamilyMember familyMember = new(Id, Name, BirthDay, IsHeadOfFamily);

            familyMember.Id.Should().Be(Id);
            familyMember.Name.Should().Be(Name);
            familyMember.BirthDay.Should().Be(BirthDay);
            familyMember.IsHeadOfFamily.Should().Be(IsHeadOfFamily);
        }

        [Fact]
        public void ShouldThrowAExceptiononWhenPassAInvalidId()
        {
            var Name = "Pedro";
            var BirthDay = new DateOnly(1990, 2, 22);
            var IsHeadOfFamily = true;


            FamilyMember familyMember;
            Action action = () => { familyMember = new FamilyMember(Id: string.Empty, Name, BirthDay, IsHeadOfFamily); };

            action.Should().Throw<ArgumentException>().WithMessage("The id param should be valid");
        }

        [Fact]
        public void ShouldThrowAExceptiononWhenPassAEmptyName()
        {
            var Id = "123";
            var BirthDay = new DateOnly(1990, 2, 22);
            var IsHeadOfFamily = true;


            FamilyMember familyMember;
            Action action = () => { familyMember = new FamilyMember(Id, Name: string.Empty, BirthDay, IsHeadOfFamily); };

            action.Should().Throw<ArgumentException>().WithMessage("The name param must not be empty");
        }
    }

}