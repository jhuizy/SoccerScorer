using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoccerScorer.Repository;
using SoccerScorer.Models;
using System.Threading.Tasks;

namespace SoccerScorer.Controllers
{

    [Route("api/[controller]")]
    public class PlayersController : Controller
    {

        ILogger<PlayersController> _logger;
        private IPlayerRepository _playerRepository;

        public PlayersController(ILogger<PlayersController> logger, IPlayerRepository playerRepository)
        {
            _logger = logger;
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await _playerRepository.Insert(
                "ID",
                new Player
                {
                    Id = "ID",
                    FirstName = "Jordan",
                    LastName = "Huizenga"
                }
            );

            var players = await _playerRepository.GetAll();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var player = await _playerRepository.FindById(id);
            if (player == null)
            {
                return BadRequest("player not found");
            }
            else
            {
                return Ok(player);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player model)
        {
            await _playerRepository.Insert(model.Id, model);
            return Ok();
        }
    }
}