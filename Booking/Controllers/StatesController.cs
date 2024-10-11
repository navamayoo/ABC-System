using AutoMapper;
using Booking.DTO.States;
using Booking.Models;
using Booking.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStatesRepository _statesRepository;
        private readonly IMapper _mapper;

        public StatesController(IStatesRepository statesRepository, IMapper mapper)
        {
            _statesRepository = statesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult <IEnumerable<StatesDTO>>> GetAllStates() 
        { 
            var statesList = await _statesRepository.GetAllStates();
            var statesDto = _mapper.Map<List<StatesDTO>>(statesList);
            if(statesList ==null)
            {
                return NoContent();
            }
            return Ok(statesDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<StatesDTO>> GetbyId(int id)
        {
            var states = await _statesRepository.GetStatesById(id);
            var statesDto = _mapper.Map<StatesDTO>(states);
            if(statesDto == null)
            {
                return NotFound();
            }
            return Ok(statesDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateStatesDTO>> Create([FromBody] CreateStatesDTO createStatesDTO)
        {
            var result = _statesRepository.IsStatesExsist(createStatesDTO.Name);
            if(result)
            {
                return Conflict("States Already exsites"); 
            }
            var states = _mapper.Map<States>(createStatesDTO);
            await _statesRepository.CreateStates(states);
            return Ok();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<States>> Update(int id, [FromBody] UpdateStatesDTO updateStatesDTO)
        {
            if(updateStatesDTO == null || id != updateStatesDTO.Id)
            {
                return BadRequest();
            }
            var states =_mapper.Map<States>(updateStatesDTO);
            await _statesRepository.UpdateStates(states);
            return NoContent();
            
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            var states =await _statesRepository.GetStatesById(id);
            if(states == null)
            {
                return NotFound();
            }
            await _statesRepository.DeleteStates(states);
            return NoContent();
            
        }
    }
}
