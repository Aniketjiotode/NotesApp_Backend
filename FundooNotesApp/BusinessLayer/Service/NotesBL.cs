using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class NotesBL:InotesBL
    {
        private readonly InotesRL inotesRL;

        public NotesBL(InotesRL inotesRL)
        {
            this.inotesRL = inotesRL;
        }

        public NotesModel CreateNote(NotesModel notesModel, long UserId)
        {
            try
            {
                return inotesRL.CreateNote(notesModel, UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetNote(long NoteId)
        {
            try
            {
                return inotesRL.GetNotes(NoteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool RemoveNote(long NoteId ,long UserId)
        {
            try
            {
                return inotesRL.RemoveNote(NoteId, UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UpdateNoteModel UpdateNote(UpdateNoteModel updateNoteModel, long UserId)
        {
            try
            {
                return inotesRL.UpdateNote(updateNoteModel, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<NotesEntity> GetallNotesbyuser(long userid)
        {
            try
            {
                return inotesRL.GetallNotesbyuser(userid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Updatetrash(long UserId ,long NotedID)
        {
            try
            {
                return inotesRL.Updatetrash(UserId,NotedID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Updatepin(long UserId ,long NotedID)
        {
            try
            {
                return inotesRL.Updatepin(UserId,NotedID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Updatearchive(long UserId ,long NotedID)
        {
            try
            {
                return inotesRL.Updatearchive(UserId,NotedID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdateColor(long UserId ,NoteColorModel noteColorModel)
        {
            try
            {
                return inotesRL.UpdateColor(UserId, noteColorModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool  UpdateImage(long UserId ,long NoteId,IFormFile Image)
        {
            try
            {
                return inotesRL.UpdateImage(UserId,NoteId,Image);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<NotesEntity> Getmacthingdata(string input,long UserId)
        {
            try
            {
                return inotesRL.Getmatchingdata(input,UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
