using notebook.core.models;
using System.ComponentModel.DataAnnotations;

namespace notebook.microservice.data.models
{
    public class NoteType : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

    }
}
