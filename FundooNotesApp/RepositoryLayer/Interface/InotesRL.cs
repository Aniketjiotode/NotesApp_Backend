using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface InotesRL
    {
        public NotesModel CreateNote(NotesModel notesModel, long UserId);

        public string GetNotes(long Userid);

        public bool RemoveNote(long NoteId, long Userid);
        public UpdateNoteModel UpdateNote(UpdateNoteModel updateNoteModel, long Userid);
        public IEnumerable<NotesEntity> GetallNotesbyuser(long userid);
        public bool Updatetrash(long userid,long NoteID);
        public bool Updatepin(long userid, long NoteId);
        public bool Updatearchive(long userid, long NoteId);
        public string UpdateColor(long userid, NoteColorModel noteColorModel);
        public bool UpdateImage(long userid, long NoteId, IFormFile Image);
        public IEnumerable<NotesEntity> Getmatchingdata(string Input,long UserId);




    }
}
