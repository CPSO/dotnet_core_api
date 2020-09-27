using System.Collections.Generic;
using AutoMapper;
using coreapi.Data;
using coreapi.DTOS;
using coreapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreapi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));

        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null )
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }

            return NotFound();

        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDTO);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var CommandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            //Returns a 201 created with route to the created element
            return CreatedAtRoute(nameof(GetCommandById), new{Id = CommandReadDTO.Id}, CommandReadDTO);

            //return Ok(CommandReadDTO);
        }
    }
}