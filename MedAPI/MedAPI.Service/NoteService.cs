using System.Collections.Generic;
using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;

namespace MedAPI.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public bool DeleteNoteById(long id)
        {
            return noteRepository.DeleteNoteById(id);
        }

        public List<Note> GetAllNote()
        {
            return noteRepository.GetAllNote();
        }

        public Note GetNoteById(long id)
        {
            return noteRepository.GetNoteById(id);
        }
    }
}
