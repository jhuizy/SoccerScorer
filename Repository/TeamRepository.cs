using SoccerScorer.Models;

namespace SoccerScorer.Repository
{
    public interface ITeamRepository : IBaseRepository<Team> 
    {

    }
    public class TeamRepository : InMemoryBaseRepository<Team>, ITeamRepository
    {
        
    }
}