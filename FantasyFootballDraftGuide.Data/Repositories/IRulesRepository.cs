using FantasyFootballDraftGuide.Data.Entities;

namespace FantasyFootballDraftGuide.Data.Repositories
{
    public interface IRulesRepository
    {
        Task SaveRules(Rules rules);
        Task<bool> ValidateRules(Rules rules);
    }
}
