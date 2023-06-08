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
    public class LabelRL : IlabelRL
    {
        private readonly FundooContext fundooContext;


        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public LabelModel CreateLabel(LabelModel labelModel,long UserId)
        {
            try
            {
                var Note_result = fundooContext.notesEntities.Where(a => a.NoteID == labelModel.NoteId).FirstOrDefault();
                if (Note_result != null)
                {
                    LabelEntity labelEntity = new LabelEntity();
                    labelEntity.LabelName = labelModel.LabelName;
                    labelEntity.NoteID = labelModel.NoteId;
                    labelEntity.UserId = UserId;
                    fundooContext.labelEntities.Add(labelEntity);
                    var result = fundooContext.SaveChanges();
                    if (result != 0)
                    {
                        return labelModel;
                    }
                    else return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<LabelEntity> GetLabels(long UserId)
        {
            try
            {
                var result = fundooContext.labelEntities.Where(a => a.UserId == UserId);
                if (result != null)
                {
                    return result;
                }
                else return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LabelModel Updatelabel(LabelModel labelModel,int LabelId,long UserId)
        {
            try
            {
                var result = fundooContext.labelEntities.Where(a => a.LabelId == LabelId && a.UserId==UserId).FirstOrDefault();
                if (result != null)
                {
                    result.NoteID = labelModel.NoteId;
                    result.LabelName = labelModel.LabelName;
                    var data = fundooContext.SaveChanges();
                    if (data != 0)
                    {
                        return labelModel;
                    }
                    return null;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveLabel(int LabelId,long UserId)
        {
            try
            {
                var result = fundooContext.labelEntities.Where(a => a.LabelId == LabelId && a.UserId==UserId).FirstOrDefault();
                if (result != null)
                {
                    fundooContext.labelEntities.Remove(result);
                    int _result = fundooContext.SaveChanges();
                    if (_result != 0)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}
