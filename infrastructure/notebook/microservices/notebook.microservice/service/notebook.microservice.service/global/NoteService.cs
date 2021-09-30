using notebook.core.data;
using notebook.microservice.data.models;
using notebook.microservice.data.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace notebook.microservice.service.global
{
    public class NoteService : IService<Note>
    {
        GenericRepository<Note> noteRepo = new GenericRepository<Note>();

        public void AddOrUpdate(Note entity)
        {
            if (entity.ID > 0)
            {
                var updatedNote = noteRepo.Get(entity.ID);
                updatedNote.NoteTypeID = entity.NoteTypeID;
                updatedNote.Description = entity.Description;
                noteRepo.Update(updatedNote);
            }
            else
            {
                noteRepo.Add(entity);
            }
        }

        public void Delete(long id)
        {
            var deletedNote = noteRepo.Get(id);
            noteRepo.Delete(deletedNote);
        }

        public Note Get(long id)
        {
            return noteRepo.Get(id);
        }

        public List<Note> GetList()
        {
            return noteRepo.GetList();
        }


    }
}
