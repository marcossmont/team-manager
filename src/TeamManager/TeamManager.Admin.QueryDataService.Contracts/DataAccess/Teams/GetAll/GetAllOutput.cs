using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.GetAll
{
    public class GetAllOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool CreateSharePointSite { get; set; }
        public bool CreateTeamsChannel { get; set; }
    }
}
