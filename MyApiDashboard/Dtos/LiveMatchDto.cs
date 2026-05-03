namespace MyApiDashboard.Dtos
{
    public class LiveMatchDto
    {
        public string? HomeTeam { get; set; }
        public string? AwayTeam { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
