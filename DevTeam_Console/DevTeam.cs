using System;
using System.Collections.Generic;

namespace DevTeam_Console
{
    internal class DevTeam
    {
        private int teamID;
        private object teamName;

        public DevTeam(int teamID, object teamName)
        {
            this.teamID = teamID;
            this.teamName = teamName;
        }

        public int TeamID { get; internal set; }
        public string TeamName { get; internal set; }

        internal void AddTeamMember(Developer newDeveloper)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Developer> GetTeamMembers()
        {
            throw new NotImplementedException();
        }

        internal void RemoveTeamMemberByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}