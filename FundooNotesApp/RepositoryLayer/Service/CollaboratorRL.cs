using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class CollaboratorRL : IcollaboratorRL
    {
        private readonly FundooContext fundooContext;
        private readonly IConfiguration configuration;

        public CollaboratorRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration = configuration;
        }

        public ColaboratorModel CreateCollaborator(long UserId, ColaboratorModel colaboratorModel)
        {
            try
            {
                var Note_result = fundooContext.notesEntities.Where(a => a.NoteID == colaboratorModel.NoteId).FirstOrDefault();
                var Email_result = fundooContext.userEntities.Where(a => a.Email == colaboratorModel.EmailId).FirstOrDefault();
                if (Note_result != null && Email_result != null)
                {
                    CollaboratorEntity collaboratorEntity = new CollaboratorEntity();
                    collaboratorEntity.UserId = UserId;
                    collaboratorEntity.EmailId = Email_result.Email;
                    collaboratorEntity.NoteID = Note_result.NoteID;
                    fundooContext.collaboratorsEntities.Add(collaboratorEntity);
                    int result = fundooContext.SaveChanges();
                    if (result != 0)
                    {
                        return colaboratorModel;
                    }
                    else { return null; }
                }
                else return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<CollaboratorEntity> GetCollaborator()
        {
            try
            {
                var result = fundooContext.collaboratorsEntities.Select(a => a);
                if (result != null)
                {
                    return result;
                }
                else return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool RemoveCollaborator(int collaboratorId)
        {
            var result = fundooContext.collaboratorsEntities.FirstOrDefault(a => a.ColaboratorId == collaboratorId);
            try
            {
                if (result != null)
                {
                    fundooContext.collaboratorsEntities.Remove(result);
                    int _result = fundooContext.SaveChanges();
                    if (_result != 0)
                    {
                        return true;
                    }
                    else return false;
                }
                else { return false; }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
