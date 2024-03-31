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
            var IsSuitor = true;

            FamilyMember familyMember = new(Id, Name, BirthDay, IsSuitor);

            familyMember.Id.Should().Be(Id);
            familyMember.Name.Should().Be(Name);
            familyMember.BirthDay.Should().Be(BirthDay);
            familyMember.IsSuitor.Should().Be(IsSuitor);
        }

        [Fact]
        public void ShouldThrowAExceptiononWhenPassAInvalidId()
        {
            var Name = "Pedro";
            var BirthDay = new DateOnly(1990, 2, 22);
            var IsSuitor = true;


            FamilyMember familyMember;
            Action action = () => { familyMember = new FamilyMember(Id: string.Empty, Name, BirthDay, IsSuitor); };

            action.Should().Throw<ArgumentException>().WithMessage("The id param should be valid");
        }

        [Fact]
        public void ShouldThrowAExceptiononWhenPassAEmptyName()
        {
            var Id = "123";
            var BirthDay = new DateOnly(1990, 2, 22);
            var IsSuitor = true;


            FamilyMember familyMember;
            Action action = () => { familyMember = new FamilyMember(Id, Name: string.Empty, BirthDay, IsSuitor); };

            action.Should().Throw<ArgumentException>().WithMessage("The name param must not be empty");
        }
    }

}