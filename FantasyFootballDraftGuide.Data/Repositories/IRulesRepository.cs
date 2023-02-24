using FantasyFootballDraftGuide.Data.Entities;

namespace FantasyFootballDraftGuide.Data.Repositories
{
    public interface IRulesRepository
    {
        void SaveRules(Rules rules);
        bool ValidateRules(Rules rules);
    }
}
