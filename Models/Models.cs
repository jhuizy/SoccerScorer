using System.Collections.Generic;

namespace SoccerScorer.Models
{

    public class Player
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }

    }

}