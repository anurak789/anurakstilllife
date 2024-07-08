using AnurakStillLife.API.Dtos;
using AutoMapper;
using Core;
using Core.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnurakStillLife.API.Controllers
{
    public class ArtsController : BaseApiController
    {
        private readonly IArtWorkRepository artWorkRepository;
        private readonly IMapper mapper;

        public ArtsController(IArtWorkRepository artWorkRepository, IMapper mapper)
        {
            this.artWorkRepository = artWorkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ArtWork>>> GetArts()
        {
            var arts = await artWorkRepository.GetArtworksAsync();
            return Ok(this.mapper.Map<IReadOnlyList<ArtWork>, IReadOnlyList<ArtWorkDto>>(arts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtWork>> GetArts(int id)
        {
            var art = await this.artWorkRepository.GetArtworkByIdAsync(id);

            return Ok(this.mapper.Map<ArtWork, ArtWorkDto>(art));
        }
    }
}
