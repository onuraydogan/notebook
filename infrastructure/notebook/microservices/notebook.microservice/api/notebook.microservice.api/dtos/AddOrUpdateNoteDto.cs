using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notebook.microservice.api.dtos
{
    public class AddOrUpdateNoteDto
    {
        public long? Id { get; set; }
        public long NoteTypeId { get; set; }
        public string Description { get; set; }
    }
}
