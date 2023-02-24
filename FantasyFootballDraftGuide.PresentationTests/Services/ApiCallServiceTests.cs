using FantasyFootballDraftGuide.API.ViewModels;
using FantasyFootballDraftGuide.Presentation.Services;
using Moq;
using Moq.Protected;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyFootballDraftGuide.PresentationTests.Services
{
    [TestFixture]
    public class ApiCallServiceTests
    {
        private ApiCallService _service;
        private Mock<HttpMessageHandler> _mockHandler;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _service = new ApiCallService(_mockHandler.Object);
        }

        [Test]
        public void SubmitLeagueRules_DoesNotThrowException_GivenOkRequest()
        {
            RulesViewModel rulesToSave = new() { Teams = 10, PlayoffTeams = 4, Budget = 200, Quarterbacks = 1, RunningBacks = 2, WideReceivers = 3, TightEnds = 1, Flexes = 1, Kickers = 1, Defenses = 1, Reserves = 7 };
            _mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            _service = new ApiCallService(_mockHandler.Object);

            Should.NotThrow(async () => await _service.SubmitLeagueRules(rulesToSave));
        }

        [Test]
        public void SubmitLeagueRules_ThrowsArgumentOutOfRangeException_GivenBadRequest()
        {
            RulesViewModel rulesToSave = new() { Teams = 10, PlayoffTeams = 12, Budget = 200, Quarterbacks = 1, RunningBacks = 2, WideReceivers = 3, TightEnds = 1, Flexes = 1, Kickers = 1, Defenses = 1, Reserves = 7 };
            _mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest });
            _service = new ApiCallService(_mockHandler.Object);

            Should.Throw<ArgumentOutOfRangeException>(async () => await _service.SubmitLeagueRules(rulesToSave));
        }
    }
}
