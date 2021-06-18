using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Repository
{
    public class DevTeamRepository
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }

        public void AddDevTeam(DevTeam newTeam)
        {
            _devTeams.Add(newTeam);
        }

        public DevTeam GetTeamByID(int teamID)
        {
            foreach (DevTeam team in _devTeams)
            {
                if (team.TeamID == teamID)
                {
                    return team;
                }
            }

            return null;
        }

        public bool RemoveTeam(DevTeam team)
        {
            bool result = _devTeams.Remove(team);
            return result;
        }

        public bool RemoveTeamByID(int teamID)
        {
            DevTeam team = GetTeamByID(teamID);
            bool result = _devTeams.Remove(team);
            return result;
        }

    }
}
