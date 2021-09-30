using AutoMapper;
using notebook.microservice.api.dtos;
using notebook.microservice.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notebook.microservice.api.helper
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<AddOrUpdateNoteDto, Note>();
        }
    }
}
