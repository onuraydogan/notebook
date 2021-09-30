using notebook.core.data;
using notebook.core.definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace notebook.core.models
{
    public class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            AfterConstruction();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public long CreateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UpdateUserID { get; set; }

        public virtual void AfterConstruction()
        {

        }
    }

}
