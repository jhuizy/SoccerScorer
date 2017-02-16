using SoccerScorer.Models;

namespace SoccerScorer.Repository
{

    public interface IPlayerRepository : IBaseRepository<Player> 
    {

    }
    public class PlayerRepository : InMemoryRepo<Player>, IPlayerRepository
    {
        
    }
}