using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.interfaces;
using ProductsApi.Interfaces;
using ProductsApi.Models;

namespace ProductsApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController(
        IPokemonRepository pokemonRepository,
        IReviewRepository reviewRepository,
        IMapper mapper
    ) : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository = pokemonRepository;
        private readonly IReviewRepository _reviewRepository = reviewRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{PokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int PokeId)
        {
            if (!_pokemonRepository.PokemonExists(PokeId))
                return NotFound();
            var Pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(PokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(Pokemon);
        }

        [HttpGet("{PokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int PokeId)
        {
            if (!_pokemonRepository.PokemonExists(PokeId))
            {
                return NotFound();
            }
            var rating = _pokemonRepository.GetPokemonRating(PokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon(
            [FromQuery] int ownerId,
            [FromQuery] int catId,
            [FromBody] PokemonDto pokemonCreate
        )
        {
            if (pokemonCreate == null)
                return BadRequest(ModelState);

            var pokemons = _pokemonRepository
                .GetPokemons()
                .FirstOrDefault(c =>
                    c.Name.Trim()
                        .Equals(
                            pokemonCreate.Name.TrimEnd(),
                            StringComparison.CurrentCultureIgnoreCase
                        )
                );

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Pokemon already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);

            if (!_pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return StatusCode(200, "created Successfully");
        }

        [HttpPut("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon(
            [FromQuery] int ownerId,
            [FromQuery] int catId,
            [FromQuery] int pokeId,
            [FromBody] PokemonDto updatedPokemonDto
        )
        {
            if (updatedPokemonDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return BadRequest(ModelState);
            }
            updatedPokemonDto.Id = pokeId;
            var pokemonMap = _mapper.Map<Pokemon>(updatedPokemonDto);

            if (_pokemonRepository.UpdatePokemon(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong when updating pokemon");
            }

            return StatusCode(200, "Updated Successfully");
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }

            var reviewsToDelete = _reviewRepository.GetReviewsOfAPokemon(pokeId);
            var pokemonToDelete = _pokemonRepository.GetPokemon(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }

            if (!_pokemonRepository.DeletePokemon(pokemonToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
