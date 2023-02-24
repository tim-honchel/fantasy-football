using FantasyFootballDraftGuide.Data.Data;
using FantasyFootballDraftGuide.Data.Entities;

namespace FantasyFootballDraftGuide.Data.Repositories
{
    public class RulesRepository : IRulesRepository
    {

        public async Task SaveRules(Rules rules)
        {
            UserData.Rules = rules;
        }

        public async Task<bool> ValidateRules(Rules rules)
        {
            if (rules == null) { return false; }
            if (rules.Budget == null || rules.Defenses == null || rules.Flexes == null || rules.Kickers == null || rules.PlayoffTeams == null || rules.Quarterbacks == null || rules.Reserves == null || rules.RunningBacks == null || rules.Teams == null || rules.TightEnds == null || rules.WideReceivers == null) { return false; }
            
            if (rules.Teams < Constants.minTeams || rules.Teams > Constants.maxTeams) { return false; }
            if (rules.PlayoffTeams < Constants.minPlayoffTeams || rules.PlayoffTeams > Constants.maxPlayoffTeams || rules.PlayoffTeams > rules.Teams) { return false; }
            if (rules.Budget < Constants.minBudget || rules.Budget > Constants.maxBudget) { return false; }
            if (rules.Quarterbacks < Constants.minQB || rules.Quarterbacks > Constants.maxQB) { return false; }
            if (rules.RunningBacks < Constants.minRB || rules.RunningBacks > Constants.maxRB) { return false; }
            if (rules.WideReceivers < Constants.minWR || rules.WideReceivers > Constants.maxWR) { return false; }
            if (rules.TightEnds < Constants.minTE || rules.TightEnds > Constants.maxTE) { return false; }
            if (rules.Flexes < Constants.minFLEX || rules.Flexes > Constants.maxFLEX) { return false; }
            if (rules.Kickers < Constants.minK || rules.Kickers > Constants.maxK) { return false; }
            if (rules.Defenses < Constants.minDEF || rules.Defenses > Constants.maxDEF) { return false; }
            if (rules.Reserves < Constants.minReserves || rules.Reserves > Constants.maxReserves) { return false; }

            return true;
        }
    }
}
