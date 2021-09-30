using notebook.core.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace notebook.microservice.data.models
{
    public class Note : BaseEntity
    {
        [StringLength(1000)]
        public string Description { get; set; }
        public long NoteTypeID { get; set; }

        [ForeignKey("NoteTypeID")]
        public virtual NoteType NoteType { get; set; }


    }
}
