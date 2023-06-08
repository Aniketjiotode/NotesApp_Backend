using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class LabelBL:IlabelBL
    {
        private readonly IlabelRL ilabelRL;
        public LabelBL(IlabelRL ilabelRL)
        {
           this.ilabelRL = ilabelRL;
        }

        public LabelModel CreateLabel(LabelModel labelModel,long UserId)
        {
            try
            {
                return ilabelRL.CreateLabel(labelModel,UserId);
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
                return ilabelRL.GetLabels(UserId);

            }
            catch (Exception)
            {

                throw;
            }        
        }

        public LabelModel Updatelabel(LabelModel labelModel,int LabelId, long UserId)
        {
            try
            {
                return ilabelRL.Updatelabel(labelModel,LabelId,UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Removelabel(int LabelId, long UserId)
        {
            try
            {
                return ilabelRL.RemoveLabel(LabelId,UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
