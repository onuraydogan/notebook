using notebook.core.data;
using notebook.core.models;
using notebook.microservice.data.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace notebook.microservice.data.repository
{
    public class GenericRepository<TEntity> : IRepositoryBase<TEntity, NoteBookDbContext> where TEntity : class, IEntity, new()
    {
    }

}
