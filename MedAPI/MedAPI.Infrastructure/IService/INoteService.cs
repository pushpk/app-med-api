using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface INoteService
    {
        List<Note> GetAllNote();
        Note GetNoteById(long id);
        bool DeleteNoteById(long id);
    }
}
