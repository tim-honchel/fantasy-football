using FantasyFootballDraftGuide.API.ViewModels;

namespace FantasyFootballDraftGuide.Presentation.Services
{
    public interface IApiCallService
    {
        Task SubmitLeagueRules(RulesViewModel rules);
    }
}
