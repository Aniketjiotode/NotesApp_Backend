using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class NotesRL:InotesRL
    {
        private readonly FundooContext fundooContext;
        private readonly IConfiguration configuration;
  

        public NotesRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration = configuration;
        }



        public NotesModel CreateNote(NotesModel notesModel, long UserId)
        {
            try
            {
                NotesEntity notesEntity = new NotesEntity();
                notesEntity.UserId = UserId;
                notesEntity.Title = notesModel.Title;
                notesEntity.Description = notesModel.Description;
                notesEntity.Color = notesModel.Color;
                notesEntity.Archive = notesModel.Archive;
                notesEntity.Trash = notesModel.Trash;
                notesEntity.Created = DateTime.Now;
                notesEntity.Updated = DateTime.Now;
                notesEntity.Pin = notesModel.Pin;
                notesEntity.Image = notesModel.Image;
                fundooContext.notesEntities.Add(notesEntity);
                int result = fundooContext.SaveChanges();
                if (result != 0)
                {
                    return notesModel;
                }
                else { return null; }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetNotes(long Noteid)
        {
            var result=fundooContext.notesEntities.Where(a=>a.NoteID==Noteid).Select(a=>new { a.Title, a.Description }).FirstOrDefault().ToString();
            if (result != null)
            {
                return result;
            }else return null;
        }

        public bool RemoveNote(long NoteId, long Userid)
        {
            var result = fundooContext.notesEntities.Where(a => a.UserId == Userid && a.NoteID == NoteId).FirstOrDefault();
            try
            {
            if (result != null)
            {
                fundooContext.notesEntities.Remove(result);
                int _result = fundooContext.SaveChanges();
                if (_result != 0)
                {
                    return true;
                }
                else return false;
            }else { return false; }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UpdateNoteModel UpdateNote(UpdateNoteModel updateNoteModel,long Userid)
        {
            var result = fundooContext.notesEntities.Where(a => a.UserId == Userid && a.NoteID == updateNoteModel.Noteid).FirstOrDefault();
            try
            {
                if(result != null)
                {
                    result.Title= updateNoteModel.Title;
                    result.Description= updateNoteModel.Description;
                    result.Color= updateNoteModel.Color;
                    result.Image= updateNoteModel.Image;
                    result.Updated = DateTime.Now;
                    int _result = fundooContext.SaveChanges();
                    if (_result != 0)
                    {
                        return updateNoteModel;
                    }
                    else return null;
                }else return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<NotesEntity> GetallNotesbyuser (long userid)
        {
            var result = fundooContext.notesEntities.Where(a => a.UserId == userid);

            List<NotesEntity> data = new  List<NotesEntity>();
            if (result != null)
            {
                foreach (var item in result)
                {         
                        data.Add(item);
                }
                return data;
            }
            else return null;
        }

        public bool Updatetrash (long userid,long NoteId)
        {
            var result = fundooContext.notesEntities.Where(a => a.UserId == userid && a.NoteID==NoteId).FirstOrDefault();
            if(result.Trash!=true)
            {
                    result.Trash = true;
                fundooContext.SaveChanges();  
                return true;
            }else  return false;
        }
        public bool Updatepin (long userid,long NoteId)
        {
            var result = fundooContext.notesEntities.Where(a => a.UserId == userid && a.NoteID==NoteId).FirstOrDefault();
            if(result.Pin!=true)
            {
                    result.Pin = true;
                fundooContext.SaveChanges();  
                return true;
            }else  return false;
        }
        public bool Updatearchive (long userid,long NoteId)
        {
            var result = fundooContext.notesEntities.Where(a => a.UserId == userid && a.NoteID==NoteId).FirstOrDefault();
            if(result.Archive!=true)
            {
                    result.Archive = true;
                fundooContext.SaveChanges();  
                return true;
            }else  return false;
        }
        public string UpdateColor (long userid,NoteColorModel noteColorModel)
        {
            var result = fundooContext.notesEntities.Where(a => a.UserId == userid && a.NoteID== noteColorModel.NoteId).FirstOrDefault();
            if(result.Color!=null)
            {
                    result.Color = noteColorModel.color;
                fundooContext.SaveChanges();  
                return result.Color;
            }else  return null;
        }

        public bool UpdateImage(long userid,long NoteId,IFormFile Image)
        {
            var result = fundooContext.notesEntities.Where(a => a.UserId == userid && a.NoteID == NoteId).FirstOrDefault();
            if(result != null)
            {
                Account account = new Account(
                    configuration["CloudinarySetting:cloud_name"],
                    configuration["CloudinarySetting:api_key"],
                    configuration["CloudinarySetting:api_secret"]

                    );
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadparameter = new ImageUploadParams()
                {
                    File = new FileDescription(Image.FileName, Image.OpenReadStream()),
                    PublicId = Image.FileName
                };
                var uploadresult = cloudinary.Upload(uploadparameter);
                string imagepath = uploadresult.Url.ToString(); 
                result.Image= imagepath;
                fundooContext.SaveChanges();
                return true;
            }else { return false; }
        }

        public IEnumerable<NotesEntity> Getmatchingdata(string Input ,long UserId)
        {
            var result = fundooContext.notesEntities.Where(a=>a.UserId==UserId);
            List<NotesEntity>data = null;
            if (result != null)
            {
                foreach (var item in result)
                {
                    if (item.Title.ToLower().Contains(Input.ToLower()) || item.Description.ToLower().Contains(Input.ToLower()))
                    {
                        data.Add(item);
                    }
                }
                return data;
            }
            else return null;
        }
    }
}
