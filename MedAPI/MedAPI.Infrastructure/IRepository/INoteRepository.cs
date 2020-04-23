using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IRepository
{
   public interface INoteRepository
    {
        List<Note> GetAllNote();
        bool DeleteNoteById(long id);
        Note GetNoteById(long id);
    }
}
