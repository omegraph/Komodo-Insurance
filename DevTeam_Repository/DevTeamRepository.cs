using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Repository
{
    public class DevTeam
    {
        private readonly List<Developer> _teamMembers = new List<Developer>();

        public int TeamID { get; set; }
        public string TeamName { get; set; }

        public DevTeam() { }
        public DevTeam(int id, string name)
        {
            TeamID = id;
            TeamName = name;
        }
        public DevTeam(int id, string name, List<Developer> teamMembers)
            : this(id, name)
        {
            _teamMembers = teamMembers;
        }

        public bool AddTeamMember(Developer developer)
        {
            int initialMemberCount = _teamMembers.Count;

            _teamMembers.Add(developer);

            if (_teamMembers.Count > initialMemberCount)
                return true;

            return false;
        }

        public List<Developer> GetTeamMembers()
        {
            return _teamMembers;
        }

        public Developer GetDeveloperByID(int id)
        {
            foreach (Developer member in _teamMembers)
            {
                if (member.DeveloperID = id)
                {
                    return member;
                }
            }
            return null;
        }

        public bool RemoveTeamMember(Developer member)
        {
            bool result = _teamMembers.Remove(member);

            return result;
        }

        public bool RemoveTeamMemberByID(int devID)
        {
            Developer oldMember = GetDeveloperByID(devID);

            bool result = _teamMembers.Remove(oldMember);

            return result;

        }

    }
}

