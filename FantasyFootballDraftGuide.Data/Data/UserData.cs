using FantasyFootballDraftGuide.Data.Entities;

namespace FantasyFootballDraftGuide.Data.Data
{
    public static class UserData
    {
        public static Rules Rules { get; set; }

        public static void ClearAll()
        {
            Rules = new Rules();
        }
        
    }
}
