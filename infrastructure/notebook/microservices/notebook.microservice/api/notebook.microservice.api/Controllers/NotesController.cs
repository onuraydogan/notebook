using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using notebook.core.data;
using notebook.core.models;
using notebook.microservice.api.dtos;
using notebook.microservice.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notebook.microservice.api.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : BaseController
    {
        IResult _result;
        IService<Note> _service;
        private readonly IMapper _mapper;

        public NotesController(IService<Note> service, IResult result, IMapper mapper)
        {
            _result = result;
            _service = service;
            _mapper = mapper;
        }

        public JsonResult GetList()
        {
            _result.Data = _service.GetList();
            return new JsonResult(_result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            _result.Data = _service.Get(id);
            return new JsonResult(_result);
        }

        [HttpPost]
        public JsonResult AddOrUpdate([FromBody] AddOrUpdateNoteDto noteDto)
        {
            Note note = _mapper.Map<Note>(noteDto);
            _service.AddOrUpdate(note);
            return new JsonResult(_result);
        }

    }
}
