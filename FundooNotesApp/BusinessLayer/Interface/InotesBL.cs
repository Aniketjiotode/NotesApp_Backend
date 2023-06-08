using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface InotesBL
    {
        public NotesModel CreateNote(NotesModel notesModel, long UserId);
        public string GetNote(long NotesId);
        public bool RemoveNote(long NoteId, long UserId);
        public IEnumerable<NotesEntity> GetallNotesbyuser(long userid);
        public UpdateNoteModel UpdateNote(UpdateNoteModel updateNoteModel, long UserId);
        public bool Updatetrash(long UserId, long NotedID);
        public bool Updatepin(long UserId, long NotedID);
        public bool Updatearchive(long UserId, long NotedID);
        public string UpdateColor(long UserId, NoteColorModel noteColorModel);
        public bool UpdateImage(long UserId, long NoteId, IFormFile Image);
        public IEnumerable<NotesEntity> Getmacthingdata(string input, long UserId);
    }
}
