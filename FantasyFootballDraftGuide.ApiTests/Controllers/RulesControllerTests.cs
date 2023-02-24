using FantasyFootballDraftGuide.API.Controllers;
using FantasyFootballDraftGuide.Data.Entities;
using FantasyFootballDraftGuide.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace FantasyFootballDraftGuide.ApiTests.Controllers
{
    [TestFixture]
    internal class RulesControllerTests
    {
        private Mock<IRulesRepository> _mockRepository;
        private RulesController _controller;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mockRepository = new Mock<IRulesRepository>();
            _controller = new RulesController(_mockRepository.Object);
        }

        [Test]
        public void SubmitLeagueRules_ReturnsBadRequest_GivenInvalidRules()
        {
            Rules invalidRules = new() { Teams = 10, PlayoffTeams = 12, Budget = 200, Quarterbacks = 1, RunningBacks = 2, WideReceivers = 3, TightEnds = 1, Flexes = 1, Kickers = 1, Defenses = 1, Reserves = 7 };
            _mockRepository.Setup(repository => repository.ValidateRules(invalidRules)).Returns(false);

            var response = _controller.SubmitLeagueRules(invalidRules);

            response.ShouldBeOfType<BadRequestResult>();
        }

        [Test]
        public void SubmitLeagueRules_ReturnsOk_GivenValidRules()
        {
            Rules validRules = new() { Teams = 10, PlayoffTeams = 4, Budget = 200, Quarterbacks = 1, RunningBacks = 2, WideReceivers = 3, TightEnds = 1, Flexes = 1, Kickers = 1, Defenses = 1, Reserves = 7 };
            _mockRepository.Setup(repository => repository.ValidateRules(validRules)).Returns(true);
            
            var response = _controller.SubmitLeagueRules(validRules);

            response.ShouldBeOfType<OkResult>();
        }

    }
}
