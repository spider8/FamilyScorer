using FamilyScorer.Model;
using FluentAssertions;

namespace FamilyScorer.Tests
{
    public class FamilyRankTest
    {
        [Fact]
        public void ShouldThrowAExceptionIfAnyArgumentsWasPassed()
        {
            FamilyRank FamilyRank;
            Action Action = () => { FamilyRank = new FamilyRank(); };

            Action.Should().Throw<ArgumentException>().WithMessage("A list of families and ranking criteria are required");
        }

        [Fact]
        public void ShouldThrowAExceptionIfAnyFamiliesWasPassed()
        {
            FamilyRank FamilyRank;
            Action Action = () => { FamilyRank = new FamilyRank(); };

            Action.Should().Throw<ArgumentException>().WithMessage("A list of families are required");
        }
    }
}