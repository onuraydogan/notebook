using notebook.core.definitions;
using System;


namespace notebook.core.models
{
    public interface IEntity
    {
        public long ID { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public long CreateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

}
