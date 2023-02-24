using FantasyFootballDraftGuide.Data.Data;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballDraftGuide.API.ViewModels
{
    public class RulesViewModel
    {
        [Required]
        [Range(Constants.minTeams, Constants.maxTeams, ErrorMessage = "Outside of allowable range")]
        public int Teams { get; set; }

        [Required]
        [Range(Constants.minPlayoffTeams, Constants.maxPlayoffTeams, ErrorMessage = "Outside of allowable range")]
        public int PlayoffTeams { get; set; }

        [Required]
        [Range(Constants.minBudget, Constants.maxBudget, ErrorMessage = "Outside of allowable range")]
        public int Budget { get; set; }

        [Required]
        [Range(Constants.minQB, Constants.maxQB, ErrorMessage = "Outside of allowable range")]
        public int Quarterbacks { get; set; }

        [Required]
        [Range(Constants.minRB, Constants.maxRB, ErrorMessage = "Outside of allowable range")]
        public int RunningBacks { get; set; }

        [Required]
        [Range(Constants.minWR, Constants.maxWR, ErrorMessage = "Outside of allowable range")]
        public int WideReceivers { get; set; }

        [Required]
        [Range(Constants.minTE, Constants.maxTE, ErrorMessage = "Outside of allowable range")]
        public int TightEnds { get; set; }

        [Required]
        [Range(Constants.minFLEX, Constants.maxFLEX, ErrorMessage = "Outside of allowable range")]
        public int Flexes { get; set; }

        [Required]
        [Range(Constants.minK, Constants.maxK, ErrorMessage = "Outside of allowable range")]
        public int Kickers { get; set; }

        [Required]
        [Range(Constants.minDEF, Constants.maxDEF, ErrorMessage = "Outside of allowable range")]
        public int Defenses { get; set; }

        [Required]
        [Range(Constants.minReserves, Constants.maxReserves, ErrorMessage = "Outside of allowable range")]
        public int Reserves { get; set; }
    }
}
