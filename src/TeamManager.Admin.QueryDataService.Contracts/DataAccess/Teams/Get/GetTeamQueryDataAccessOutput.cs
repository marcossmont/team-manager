namespace TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get
{
    public class GetTeamQueryDataAccessOutput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CreateSharePointSite { get; set; }
        public bool CreateTeamsChannel { get; set; }
    }
}