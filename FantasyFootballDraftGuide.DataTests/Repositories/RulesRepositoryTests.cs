using FantasyFootballDraftGuide.Data.Data;
using FantasyFootballDraftGuide.Data.Entities;
using FantasyFootballDraftGuide.Data.Repositories;
using Shouldly;

namespace FantasyFootballDraftGuide.DataTests.Repositories
{
    internal class RulesRepositoryTests
    {
        private RulesRepository _repository = new();

        [SetUp]
        public void SetUp()
        {
            UserData.ClearAll();
        }

        [Test]
        public async Task SaveRules_AddsRulesUserData()
        {
            Rules rulesToSave = new() { Teams = 10, PlayoffTeams = 4, Budget = 200, Quarterbacks = 1, RunningBacks = 2, WideReceivers = 3, TightEnds = 1, Flexes = 1, Kickers = 1, Defenses = 1, Reserves = 7 };

            _repository.SaveRules(rulesToSave);

            var rulesSaved = UserData.Rules;
            rulesSaved.ShouldBeEquivalentTo(rulesToSave);
        }

        [Test]
        public async Task ValidateRules_ReturnsFalse_GivenEmptyProperties()
        {
            Rules rulesToValidate = new() { PlayoffTeams = 4, Budget = 200, Quarterbacks = 1, RunningBacks = 2, WideReceivers = 3, TightEnds = 1, Flexes = 1, Kickers = 1, Defenses = 1, Reserves = 7 }; // missing Teams

            var rulesValidated = await _repository.ValidateRules(rulesToValidate);

            rulesValidated.ShouldBeFalse();
        }

        [Test]
        public async Task ValidateRules_ReturnsFalse_GivenInvalidProperties()
        {
            Rules rulesToValidate = new() { Teams = 10, PlayoffTeams = 12, Budget = 200, Quarterbacks = 1, RunningBacks = 2, WideReceivers = 3, TightEnds = 1, Flexes = 1, Kickers = 1, Defenses = 1, Reserves = 7 }; // Playoff Teams > Teams

            var rulesValidated = await _repository.ValidateRules(rulesToValidate);

            rulesValidated.ShouldBeFalse();
        }

        [Test]
        public async Task ValidateRules_ReturnsTrue_GivenValidProperties()
        {
            Rules rulesToValidate = new() { Teams = 10, PlayoffTeams = 4, Budget = 200, Quarterbacks = 1, RunningBacks = 2, WideReceivers = 3, TightEnds = 1, Flexes = 1, Kickers = 1, Defenses = 1, Reserves = 7 };

            var rulesValidated = await _repository.ValidateRules(rulesToValidate);

            rulesValidated.ShouldBeTrue();
        }
    }
}
